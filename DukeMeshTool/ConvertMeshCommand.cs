using System.Text;
using System.Numerics;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;
using DukeForever;
using AssImp.Interop;
using static AssImp.Interop.AssImp;
using System.Runtime.CompilerServices;

internal static unsafe class ConvertMeshCommand
{
    public static Command Command { get; }

    private static readonly Argument<string> s_RootArgument = new("root");

    private static readonly Argument<string> s_InputArgument = new("input");

    private static readonly Argument<string> s_SkeletonArgument = new("skeleton");

    private static readonly Argument<string> s_OutputArgument = new("output");

    private static readonly Option<string> s_FormatOption = new("--format");

    private static readonly Option<string> s_AutoRigOption = new("--auto-rig");

    private static readonly Option<bool> s_NoGlobalScaleOption = new("--no-global-scale");

    static ConvertMeshCommand()
    {
        Command = new Command("convert");
        Command.AddArgument(s_InputArgument);
        Command.AddArgument(s_RootArgument);
        Command.AddArgument(s_SkeletonArgument);
        Command.AddArgument(s_OutputArgument);
        Command.AddOption(s_FormatOption);
        Command.AddOption(s_AutoRigOption);
        Command.AddOption(s_NoGlobalScaleOption);
        Handler.SetHandler(Command, Execute);
    }

    public static void Execute(InvocationContext context)
    {
        var root     = context.ParseResult.GetValueForArgument(s_RootArgument);
        var input    = context.ParseResult.GetValueForArgument(s_InputArgument);
        var output   = context.ParseResult.GetValueForArgument(s_OutputArgument);
        var skelPath = context.ParseResult.GetValueForArgument(s_SkeletonArgument);
        var format   = context.ParseResult.GetValueForOption(s_FormatOption);
        var autoRig  = context.ParseResult.GetValueForOption(s_AutoRigOption);
        var skeleton = new Skeleton();

        using (var fs = File.OpenRead(skelPath))
        {
            var reader = new UnStreamReader(fs);
            skeleton.Serialize(reader);
        }

        skeleton.ComputeIndices();
        skeleton.ComputeMatrices();
        var boneMap = new Dictionary<string, int>();

        for (int i = 0; i < skeleton.Bones.Count; i++)
        {
            boneMap[skeleton.Bones[i].Name] = i;
        }

        var flags =
            aiPostProcessSteps.aiProcess_GenSmoothNormals |
            aiPostProcessSteps.aiProcess_CalcTangentSpace |
            aiPostProcessSteps.aiProcess_Triangulate |
            aiPostProcessSteps.aiProcess_FlipUVs |
            aiPostProcessSteps.aiProcess_FlipWindingOrder |
            aiPostProcessSteps.aiProcess_LimitBoneWeights;

        if (!context.ParseResult.GetValueForOption(s_NoGlobalScaleOption))
            flags |= aiPostProcessSteps.aiProcess_GlobalScale;

        if (!TryImportModel(input, flags, boneMap, out var mesh, out var pScene))
        {
            Console.Error.WriteLine("Failed to import model.");
            return;
        }

        if (autoRig != null)
        {
            if (!boneMap.TryGetValue(autoRig, out int boneIndex))
                Console.Error.WriteLine($"Error: Model does not contain a bone named '{autoRig}'.");
            else
            {
                for (int i = 0; i < mesh.Positions.Count; i++)
                {
                    mesh.BonesPerVertex[i] = 1;
                    mesh.BlendIndices[i]   = new BlendIndices { BoneIndex0 = (byte)boneIndex };
                    mesh.BlendWeights[i]   = new BlendWeights { Weight0    = 1 };
                }
            }
        }

        mesh.NormalizeBoneWeights();
        mesh.ComputeBoneInfo(skeleton);
        mesh.ComputeBoundingBox();

        if (Path.GetDirectoryName(output) is { Length: > 0 } directory)
            Directory.CreateDirectory(directory);

        if (string.IsNullOrEmpty(mesh.Skeleton))
        {
            mesh.Skeleton = Path.GetRelativePath(root, skelPath).Replace('\\', '/');
        }

        if (format != null)
        {
            var pFormat = (sbyte*)Marshal.StringToCoTaskMemUTF8(format);
            var pOutput = (sbyte*)Marshal.StringToCoTaskMemUTF8(output);
            var scene   = new aiScene();
            BuildScene(&scene, skeleton, mesh);
            aiExportScene(&scene, pFormat, pOutput, 0);
        }
        else
        {
            using var fs = File.Open(output, FileMode.Create, FileAccess.Write);
            var writer   = new UnStreamWriter(fs);
            mesh.Serialize(writer);
        }
    }

    private static Dictionary<string, nuint> BuildNodeMap(aiScene* scene)
    {
        var nodeMap  = new Dictionary<string, nuint>();
        var rootNode = scene->mRootNode;

        if (rootNode != null)
        {
            AddNodes(rootNode);
        }

        void AddNodes(aiNode* node)
        {
            var name = node->mName;
            var span = new Span<byte>(name.data, (int)name.length);
            var str  = Encoding.UTF8.GetString(span);
            nodeMap.Add(str, (nuint)rootNode);

            for (uint i = 0; i < node->mNumChildren; i++)
            {
                AddNodes(node->mChildren[i]);
            }
        }

        return nodeMap;
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

    private static void BuildScene(aiScene* scene, Skeleton skeleton, SkinMesh skinMesh)
    {
        scene->mNumMeshes = (uint)skinMesh.Groups.Count;
        scene->mMeshes    = (aiMesh**)Alloc<nuint>(skinMesh.Groups.Count);
        CopyString("<Scene>", out scene->mName);

        scene->mNumMaterials = scene->mNumMeshes;
        scene->mMaterials    = (aiMaterial**)Alloc<nuint>((int)scene->mNumMaterials);

        for (int i = 0; i < scene->mNumMaterials; i++)
            scene->mMaterials[i] = Alloc<aiMaterial>();
        
        for (uint i = 0; i < skinMesh.Groups.Count; i++)
        {
            var group                 = skinMesh.Groups[(int)i];
            var mesh                  = Alloc<aiMesh>();
            scene->mMeshes[i]         = mesh;
            mesh->mMaterialIndex      = i;
            mesh->mNumVertices        = (uint)((group.MaxVertex + 1) - group.MinVertex);
            mesh->mVertices           = Alloc<aiVector3D>((int)mesh->mNumVertices);
            mesh->mNormals            = Alloc<aiVector3D>((int)mesh->mNumVertices);
            mesh->mTangents           = Alloc<aiVector3D>((int)mesh->mNumVertices);
            mesh->mTextureCoords[0]   = Alloc<aiVector3D>((int)mesh->mNumVertices);
            mesh->mNumUVComponents[0] = 3;
            mesh->mNumFaces           = (uint)group.Indices.Count / 3;
            mesh->mFaces              = Alloc<aiFace>((int)mesh->mNumFaces);
            CopyString($"Group {i}", out mesh->mName);

            for (int v = 0; v < mesh->mNumVertices; v++)
            {
                mesh->mVertices[v] = SwizzlePosition(skinMesh.Positions[group.MinVertex + v]);
                mesh->mNormals[v]  = SwizzlePosition(skinMesh.Normals[group.MinVertex + v]);
                mesh->mTangents[v] = SwizzlePosition(skinMesh.Tangents[group.MinVertex + v]);
                *(Vector3*)&mesh->mTextureCoords[0][v] = skinMesh.UVs[group.MinVertex + v];
                mesh->mTextureCoords[0][v].y = 1 - mesh->mTextureCoords[0][v].y;
            }

            for (int f = 0; f < mesh->mNumFaces; f++)
            {
                mesh->mFaces[f].mNumIndices = 3;
                mesh->mFaces[f].mIndices    = Alloc<uint>(3);
                mesh->mFaces[f].mIndices[0] = (uint)(group.Indices[3 * f + 0] - group.MinVertex);
                mesh->mFaces[f].mIndices[2] = (uint)(group.Indices[3 * f + 1] - group.MinVertex);
                mesh->mFaces[f].mIndices[1] = (uint)(group.Indices[3 * f + 2] - group.MinVertex);
            }
        }

        scene->mRootNode             = Alloc<aiNode>();
        scene->mRootNode->mNumMeshes = scene->mNumMeshes;
        scene->mRootNode->mMeshes    = Alloc<uint>((int)scene->mNumMeshes);
        CopyString("<RootNode>", out scene->mRootNode->mName);

        for (uint i = 0; i < scene->mNumMeshes; i++)
            scene->mRootNode->mMeshes[i] = i;

        aiIdentityMatrix4(&scene->mRootNode->mTransformation);

        // Produces bad models that crash Blender. Need to investigate.
        //var nodes = BuildSceneNodes(scene, skeleton);
        //BuildBoneEntries(scene, nodes, skeleton, skinMesh);
    }

    private static void BuildBoneEntries(aiScene* scene, aiNode** nodes, Skeleton skeleton, SkinMesh skinMesh)
    {
        for (uint i = 0; i < scene->mNumMeshes; i++)
        {
            var bones = (aiBone**)Alloc<nuint>(skeleton.Bones.Count);

            for (int j = 0; j < skeleton.Bones.Count; j++)
            {
                bones[j] = Alloc<aiBone>();
                bones[j]->mNode = nodes[j];
                bones[j]->mName = nodes[j]->mName;
                bones[j]->mOffsetMatrix = nodes[j]->mTransformation;

                for (aiNode* parent = nodes[j]->mParent; parent != null; parent = parent->mParent)
                {
                    var temp = parent->mTransformation;
                    aiMultiplyMatrix4(&temp, &bones[j]->mOffsetMatrix);
                    bones[j]->mOffsetMatrix = temp;
                }

                aiMatrix4Inverse(&bones[j]->mOffsetMatrix);
                // todo: weights
            }

            scene->mMeshes[i]->mNumBones = (uint)skeleton.Bones.Count;
            scene->mMeshes[i]->mBones    = bones;
        }
    }

    private static aiNode** BuildSceneNodes(aiScene* scene, Skeleton skeleton)
    {
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

        scene->mRootNode->mNumChildren = (uint)roots.Count;
        scene->mRootNode->mChildren    = rootNodes;

        for (int i = 0; i < skeleton.Bones.Count; i++)
        {
            CopyString(skeleton.Bones[i].Name, out nodes[i]->mName);
            var t = SwizzlePosition(skeleton.Bones[i].Translate);
            var r = SwizzleQuaternion(skeleton.Bones[i].Rotate);
            var s = SwizzleScale(skeleton.Bones[i].Scale);
            aiMatrix4FromScalingQuaternionPosition(&nodes[i]->mTransformation, &s, &r, &t);

            if (skeleton.Bones[i].Parent == 0xFF)
                nodes[i]->mParent = scene->mRootNode;
            else
                nodes[i]->mParent = nodes[skeleton.Bones[i].Parent];

            nodes[i]->mNumChildren = (uint)skeleton.Bones[i].Children.Count;
            nodes[i]->mChildren    = (aiNode**)Alloc<nuint>(skeleton.Bones[i].Children.Count);

            for (int j = 0; j < nodes[i]->mNumChildren; j++)
            {
                nodes[i]->mChildren[j] = nodes[skeleton.Bones[i].Children[j]];
            }
        }

        return nodes;
    }

    private static bool TryImportModel(string path, aiPostProcessSteps steps, Dictionary<string, int> boneMap, [NotNullWhen(true)] out SkinMesh? mesh, out aiScene* scene)
    {
        if (Path.GetExtension(path).Equals(".msh", StringComparison.OrdinalIgnoreCase))
        {
            mesh = new SkinMesh();
            
            using var fs = File.OpenRead(path);
            {
                var reader = new UnStreamReader(fs);
                mesh.Serialize(reader);
            }

            scene = null;
            return true;
        }

        var pPath = Marshal.StringToCoTaskMemUTF8(path);
        scene     = aiImportFile((sbyte*)pPath, (uint)steps);
        Marshal.FreeCoTaskMem(pPath);

        if (scene == null)
        {
            Console.Error.WriteLine(Marshal.PtrToStringUTF8((nint)aiGetErrorString()));
            mesh = null;
            return false;
        }

        mesh = CreateSkinMesh(scene, boneMap);
        return true;
    }

    private static SkinMesh CreateSkinMesh(aiScene* scene, Dictionary<string, int> boneMap)
    {
        var result        = new SkinMesh();
        ushort baseVertex = 0;
        
        for (int m = 0; m < scene->mNumMeshes; m++)
        {
            var mesh  = scene->mMeshes[m];
            var group = new SkinMeshGroup();

            for (int i = 0; i < mesh->mNumVertices; i++)
            {
                result.Positions.Add(SwizzlePosition(mesh->mVertices[i]));
                result.Normals.Add(SwizzlePosition(mesh->mNormals[i]));
                result.Tangents.Add(SwizzlePosition(mesh->mTangents[i]));
                result.UVs.Add(*(Vector3*)&mesh->mTextureCoords[0][i]);
                result.BonesPerVertex.Add(0);
                result.BlendIndices.Add(new BlendIndices());
                result.BlendWeights.Add(new BlendWeights());
            }

            for (int i = 0; i < mesh->mNumBones; i++)
            {
                var bone = mesh->mBones[i];
                var name = bone->mName;
                var span = new Span<byte>(name.data, (int)name.length);
                
                if (!boneMap.TryGetValue(Encoding.UTF8.GetString(span), out int index))
                    continue;

                for (int w = 0; w < bone->mNumWeights; w++)
                {
                    var weight = bone->mWeights[w];
                    var vertex = checked((ushort)(baseVertex + weight.mVertexId));
                    var count  = result.BonesPerVertex[vertex];

                    if (weight.mWeight == 0)
                        continue;

                    if (count == 4)
                        continue;

                    var blendIndices = result.BlendIndices[vertex];
                    var blendWeights = result.BlendWeights[vertex];

                    blendIndices[count] = checked((byte)index);
                    blendWeights[count] = weight.mWeight;

                    result.BlendIndices[vertex] = blendIndices;
                    result.BlendWeights[vertex] = blendWeights;
                    result.BonesPerVertex[vertex]++;
                }
            }

            for (int i = 0; i < mesh->mNumFaces; i++)
            {
                var face = mesh->mFaces[i];

                for (int j = 0; j < face.mNumIndices; j++)
                {
                    ushort index    = checked((ushort)(baseVertex + face.mIndices[j]));
                    group.MinVertex = ushort.Min(group.MinVertex, index);
                    group.MinVertex = ushort.Max(group.MaxVertex, index);
                    group.Indices.Add(index);
                }
            }

            baseVertex += checked((ushort)mesh->mNumVertices);
            result.Groups.Add(group);
        }

        return result;
    }

    // assimp -> dnf
    private static Vector3 SwizzlePosition(aiVector3D v)
    {
        Vector3 r;
        r.X = v.z;
        r.Y = -v.x;
        r.Z = v.y;
        return r;
    }

    // assimp -> dnf
    private static Vector3 SwizzleScale(aiVector3D v)
    {
        Vector3 r;
        r.X = v.z;
        r.Y = v.x;
        r.Z = v.y;
        return r;
    }

    // assimp -> dnf
    private static Quaternion SwizzleQuaternion(aiQuaternion p)
    {
        Quaternion r;
        r.W = -p.w;
        r.X = -p.z;
        r.Y = p.x;
        r.Z = -p.y;
        return r;
    }
}
