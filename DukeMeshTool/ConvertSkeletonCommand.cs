using System.CommandLine;
using System.CommandLine.Invocation;
using DukeForever;
using AssImp.Interop;
using static AssImp.Interop.AssImp;
using System.Runtime.InteropServices;
using System.Text;
using System.Runtime.CompilerServices;
using System.Numerics;

internal static unsafe class ConvertSkeletonCommand
{
    public static Command Command { get; }

    private static readonly Argument<string> s_InputArgument = new("input");

    private static readonly Argument<string> s_OutputArgument = new("output");

    private static readonly Argument<string> s_FormatArgument = new("format") { Arity = ArgumentArity.ZeroOrOne };

    private static readonly Option<bool> s_BonesOnly = new("--bones-only");

    static ConvertSkeletonCommand()
    {
        Command = new Command("sklconv");
        Command.AddArgument(s_InputArgument);
        Command.AddArgument(s_OutputArgument);
        Command.AddArgument(s_FormatArgument);
        Command.AddOption(s_BonesOnly);
        s_FormatArgument.SetDefaultValue("collada");
        Handler.SetHandler(Command, Execute);
    }

    private static T* Alloc<T>(int count = 1)
        where T : unmanaged
    {
        return (T*)NativeMemory.AllocZeroed((uint)count, (uint)sizeof(T));
    }

    private static void CopyString(string s, out aiString r)
    {
        Unsafe.SkipInit(out r);
        var span = MemoryMarshal.CreateSpan(ref Unsafe.As<sbyte, byte>(ref r.data[0]), 127);
        r.length = (uint)Encoding.UTF8.GetBytes(s, span);
    }

    // dnf -> assimp
    private static aiVector3D SwizzlePosition(Vector3 p)
    {
        aiVector3D r;
        r.x = -p.Y;
        r.y = p.Z;
        r.z = p.X;
        return r;
    }

    // dnf -> assimp
    private static aiVector3D SwizzleScale(Vector3 p)
    {
        aiVector3D r;
        r.x = p.Y;
        r.y = p.Z;
        r.z = p.X;
        return r;
    }

    // dnf -> assimp
    private static aiQuaternion SwizzleQuaternion(Quaternion p)
    {
        aiQuaternion r;
        r.w = -p.W;
        r.x = p.Y;
        r.y = -p.Z;
        r.z = -p.X;
        return r;
    }

    // This leaks memory because I'm lazy
    public static void Execute(InvocationContext context)
    {
        var input    = context.ParseResult.GetValueForArgument(s_InputArgument);
        var output   = context.ParseResult.GetValueForArgument(s_OutputArgument);
        var format   = context.ParseResult.GetValueForArgument(s_FormatArgument);
        var genTris  = !context.ParseResult.GetValueForOption(s_BonesOnly);
        var skeleton = new Skeleton();

        if (string.IsNullOrWhiteSpace(format))
            format = Path.GetExtension(output).TrimStart('.');

        using (var fs = File.OpenRead(input))
        {
            var reader = new UnStreamReader(fs);
            skeleton.Serialize(reader);
            skeleton.ComputeIndices();
        }

        var nodes = (aiNode**)Alloc<nuint>(skeleton.Bones.Count);
        var roots = new List<int>();

        for (int i = 0; i < skeleton.Bones.Count; i++)
        {
            nodes[i] = Alloc<aiNode>();

            if (skeleton.Bones[i].Parent == 0xFF)
            {
                roots.Add(i);
            }
        }

        var rootNodes = (aiNode**)Alloc<nuint>(roots.Count);

        for (int i = 0; i < roots.Count; i++)
            rootNodes[i] = nodes[roots[i]];

        var root = new aiNode
        {
            mNumChildren = (uint)roots.Count,
            mChildren    = rootNodes,
        };

        aiIdentityMatrix4(&root.mTransformation);

        for (int i = 0; i < skeleton.Bones.Count; i++)
        {
            CopyString(skeleton.Bones[i].Name, out nodes[i]->mName);
            var t = SwizzlePosition(skeleton.Bones[i].Translate);
            var r = SwizzleQuaternion(skeleton.Bones[i].Rotate);
            var s = SwizzleScale(skeleton.Bones[i].Scale);
            aiMatrix4FromScalingQuaternionPosition(&nodes[i]->mTransformation, &s, &r, &t);

            if (skeleton.Bones[i].Parent == 0xFF)
                nodes[i]->mParent = &root;
            else
                nodes[i]->mParent = nodes[skeleton.Bones[i].Parent];

            nodes[i]->mNumChildren = (uint)skeleton.Bones[i].Children.Count;
            nodes[i]->mChildren    = (aiNode**)Alloc<nuint>(skeleton.Bones[i].Children.Count);

            for (int j = 0; j < nodes[i]->mNumChildren; j++)
            {
                nodes[i]->mChildren[j] = nodes[skeleton.Bones[i].Children[j]];
            }
        }

        CopyString("<SKL Hierarchy>", out root.mName);

        aiScene scene = new()
        {
            mFlags    = AI_SCENE_FLAGS_INCOMPLETE,
            mRootNode = &root
        };

        CopyString("<SKL Scene>", out scene.mName);

        var builder = new SkeletonMeshBuilder();
        builder.Build(&scene, &root, genTris ? SkeletonMeshGenerationMode.Default : SkeletonMeshGenerationMode.BonesOnly);
        var formatId = Marshal.StringToCoTaskMemUTF8(format);
        var fileName = Marshal.StringToCoTaskMemUTF8(Path.GetFullPath(output));
        var result   = aiExportScene(&scene, (sbyte*)formatId, (sbyte*)fileName, 0);

        if (result != aiReturn.aiReturn_SUCCESS)
        {
            Console.Error.WriteLine("Failed to export skeleton.");
        }
    }

    private enum SkeletonMeshGenerationMode
    {
        Default,
        KnobsOnly,
        BonesOnly,
    }

    private sealed unsafe class SkeletonMeshBuilder
    {
        private SkeletonMeshGenerationMode mGenerationMode;

        private readonly List<Vector3> mVertices = new();

        private readonly List<aiFace> mFaces = new();

        private readonly List<nuint> mBones = new();

        public void Build(aiScene* pScene, aiNode* root, SkeletonMeshGenerationMode mode)
        {
            mVertices.Clear();
            mFaces.Clear();
            mBones.Clear();

            if (pScene->mNumMeshes > 0 || pScene->mRootNode == null)
                return;

            if (root == null)
                root = pScene->mRootNode;

            mGenerationMode = mode;
            CreateGeometry(root);

            pScene->mNumMeshes = 1;
            pScene->mMeshes    = (aiMesh**)Alloc<nuint>();
            pScene->mMeshes[0] = CreateMesh();

            root->mNumMeshes = 1;
            root->mMeshes    = Alloc<uint>();
            root->mMeshes[0] = 0;

            if (mGenerationMode != SkeletonMeshGenerationMode.BonesOnly && pScene->mNumMaterials == 0)
            {
                pScene->mNumMaterials = 1;
                pScene->mMaterials    = (aiMaterial**)Alloc<nuint>();
                pScene->mMaterials[0] = CreateMaterial();
            }
        }

        private void CreateGeometry(aiNode* pNode)
        {
            var vertexStartIndex = mVertices.Count;

            if (pNode->mNumChildren > 0 && mGenerationMode == SkeletonMeshGenerationMode.KnobsOnly)
            {
                for (uint a = 0; a < pNode->mNumChildren; a++)
                {
                    var childTransform  = &pNode->mChildren[a]->mTransformation;
                    Vector3 childPos    = new(childTransform->a4, childTransform->b4, childTransform->c4);
                    var distanceToChild = childPos.Length();

                    if (distanceToChild < ai_epsilon)
                        continue;

                    Vector3 up   = Vector3.Normalize(childPos);
                    Vector3 orth = Vector3.UnitX;

                    if (float.Abs(Vector3.Dot(up, orth)) > 0.99f)
                        orth = Vector3.UnitY;

                    Vector3 front = Vector3.Normalize(Vector3.Cross(up, orth));
                    Vector3 side  = Vector3.Normalize(Vector3.Cross(front, up));

                    int localVertexStart = mVertices.Count;
                    mVertices.Add(-front * distanceToChild * 0.1f);
                    mVertices.Add(childPos);
                    mVertices.Add(-side * distanceToChild * 0.1f);
                    mVertices.Add(-side * distanceToChild * 0.1f);
                    mVertices.Add(childPos);
                    mVertices.Add(front * distanceToChild * 0.1f);
                    mVertices.Add(front * distanceToChild * 0.1f);
                    mVertices.Add(childPos);
                    mVertices.Add(side * distanceToChild * 0.1f);
                    mVertices.Add(side * distanceToChild * 0.1f);
                    mVertices.Add(childPos);
                    mVertices.Add(-front * distanceToChild * 0.1f);

                    for (uint i = 0; i < 4; i++)
                    {
                        aiFace face;
                        face.mNumIndices = 3;
                        face.mIndices    = Alloc<uint>(3);
                        face.mIndices[0] = (uint)localVertexStart + 3 * i;
                        face.mIndices[1] = (uint)localVertexStart + 3 * i + 1;
                        face.mIndices[2] = (uint)localVertexStart + 3 * i + 2;
                        mFaces.Add(face);
                    }
                }
            }
            else if (mGenerationMode != SkeletonMeshGenerationMode.BonesOnly)
            {
                Vector3 ownPos   = new(pNode->mTransformation.a4, pNode->mTransformation.b4, pNode->mTransformation.c4);
                var sizeEstimate = ownPos.Length() * 0.18f;

                mVertices.Add(new(-sizeEstimate, 0, 0));
                mVertices.Add(new(0, sizeEstimate, 0));
                mVertices.Add(new(0, 0, -sizeEstimate));
                mVertices.Add(new(0, sizeEstimate, 0));
                mVertices.Add(new(sizeEstimate, 0, 0));
                mVertices.Add(new(0, 0, -sizeEstimate));
                mVertices.Add(new(sizeEstimate, 0, 0));
                mVertices.Add(new(0, -sizeEstimate, 0));
                mVertices.Add(new(0, 0, -sizeEstimate));
                mVertices.Add(new(0, -sizeEstimate, 0));
                mVertices.Add(new(-sizeEstimate, 0, 0));
                mVertices.Add(new(0, 0, -sizeEstimate));

                mVertices.Add(new(-sizeEstimate, 0, 0));
                mVertices.Add(new(0, 0, sizeEstimate));
                mVertices.Add(new(0, sizeEstimate, 0));
                mVertices.Add(new(0, sizeEstimate, 0));
                mVertices.Add(new(0, 0, sizeEstimate));
                mVertices.Add(new(sizeEstimate, 0, 0));
                mVertices.Add(new(sizeEstimate, 0, 0));
                mVertices.Add(new(0, 0, sizeEstimate));
                mVertices.Add(new(0, -sizeEstimate, 0));
                mVertices.Add(new(0, -sizeEstimate, 0));
                mVertices.Add(new(0, 0, sizeEstimate));
                mVertices.Add(new(-sizeEstimate, 0, 0));

                for (uint i = 0; i < 8; i++)
                {
                    aiFace face;
                    face.mNumIndices = 3;
                    face.mIndices    = Alloc<uint>(3);
                    face.mIndices[0] = (uint)vertexStartIndex + 3 * i;
                    face.mIndices[1] = (uint)vertexStartIndex + 3 * i + 1;
                    face.mIndices[2] = (uint)vertexStartIndex + 3 * i + 2;
                    mFaces.Add(face);
                }
            }

            var numVertices = mVertices.Count - vertexStartIndex;

            if (mGenerationMode == SkeletonMeshGenerationMode.BonesOnly || numVertices > 0)
            {
                var bone = Alloc<aiBone>();
                mBones.Add((nuint)bone);
                bone->mName = pNode->mName;
                bone->mOffsetMatrix = pNode->mTransformation;

                for (aiNode* parent = pNode->mParent; parent != null; parent = parent->mParent)
                {
                    var temp = parent->mTransformation;
                    aiMultiplyMatrix4(&temp, &bone->mOffsetMatrix);
                    bone->mOffsetMatrix = temp;
                }

                aiMatrix4Inverse(&bone->mOffsetMatrix);
                bone->mNumWeights = (uint)numVertices;
                bone->mWeights    = Alloc<aiVertexWeight>(numVertices);

                for (uint a = 0; a < numVertices; a++)
                {
                    bone->mWeights[a] = new aiVertexWeight
                    {
                        mVertexId = a,
                        mWeight   = 1
                    };
                }

                var boneToMeshTransform = bone->mOffsetMatrix;
                aiMatrix4Inverse(&boneToMeshTransform);

                for (int a = vertexStartIndex; a < mVertices.Count; a++)
                {
                    var vertex = mVertices[a];
                    aiTransformVecByMatrix4((aiVector3D*)&vertex, &boneToMeshTransform);
                    mVertices[a] = vertex;
                }
            }

            for (uint a = 0; a < pNode->mNumChildren; a++)
            {
                CreateGeometry(pNode->mChildren[a]);
            }
        }

        private aiMesh* CreateMesh()
        {
            aiMesh* mesh = Alloc<aiMesh>();

            if (mGenerationMode != SkeletonMeshGenerationMode.BonesOnly)
            {
                // add points
                mesh->mNumVertices = (uint)mVertices.Count;
                mesh->mVertices    = Alloc<aiVector3D>(mVertices.Count);
                mesh->mNormals     = Alloc<aiVector3D>(mVertices.Count);
                CollectionsMarshal.AsSpan(mVertices).CopyTo(new Span<Vector3>(mesh->mVertices, mVertices.Count));

                // add faces
                mesh->mNumFaces = (uint)mFaces.Count;
                mesh->mFaces    = Alloc<aiFace>(mFaces.Count);

                for (uint a = 0; a < mesh->mNumFaces; a++)
                {
                    var face   = mFaces[(int)a];
                    var normal = Vector3.Cross(
                        mVertices[(int)face.mIndices[2]] - mVertices[(int)face.mIndices[0]],
                        mVertices[(int)face.mIndices[1]] - mVertices[(int)face.mIndices[0]]
                    );

                    if (normal.Length() < 1e-5f)
                        normal = Vector3.UnitX;

                    for (uint n = 0; n < 3; n++)
                        mesh->mNormals[face.mIndices[n]] = *(aiVector3D*)&normal;

                    mesh->mFaces[a] = face;
                }
            }

            // add the bones
            mesh->mNumBones = (uint)mBones.Count;
            mesh->mBones    = (aiBone**)Alloc<nuint>(mBones.Count);
            CollectionsMarshal.AsSpan(mBones).CopyTo(new Span<nuint>(mesh->mBones, mBones.Count));

            // default
            mesh->mMaterialIndex = 0;
            return mesh;
        }

        private aiMaterial* CreateMaterial()
        {
            aiMaterial* matHelper     = Alloc<aiMaterial>();
            matHelper->mProperties    = (aiMaterialProperty**)Alloc<nuint>(2);
            matHelper->mNumProperties = 2;
            matHelper->mNumAllocated  = matHelper->mNumProperties;

            // Name
            CopyString("SkeletonMaterial", out var matName);
            matHelper->mProperties[0] = CreateProperty(&matName, "?mat.name");

            // Prevent backface culling
            int no_cull = 1;
            matHelper->mProperties[1] = CreateProperty(&no_cull, 1, "$mat.twosided");
            
            return matHelper;
        }

        private aiMaterialProperty* CreateProperty(aiString* matName, string key)
        {
            return CreateBinaryProperty(matName, matName->length + 4 + 1, key, 0, 0, aiPropertyTypeInfo.aiPTI_String);
        }

        private aiMaterialProperty* CreateProperty(int* pInput, uint pNumValues, string key)
        {
            return CreateBinaryProperty(pInput, pNumValues * 4, key, 0, 0, aiPropertyTypeInfo.aiPTI_Integer);
        }

        private aiMaterialProperty* CreateBinaryProperty(void* pInput, uint pSizeInBytes, string key, uint type, uint index, aiPropertyTypeInfo pType)
        {
            var property = Alloc<aiMaterialProperty>();
            property->mType = pType;
            property->mSemantic = type;
            property->mIndex = index;
            property->mDataLength = pSizeInBytes;
            property->mData = (sbyte*)NativeMemory.Alloc(pSizeInBytes);
            CopyString(key, out property->mKey);
            var src = new Span<byte>(pInput, (int)pSizeInBytes);
            var dst = new Span<byte>(property->mData, (int)pSizeInBytes);
            src.CopyTo(dst);
            return property;
        }
    }
}