using System.Text;
using System.Numerics;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;
using DukeForever;
using DukeMeshTool;
using AssImp.Interop;
using static AssImp.Interop.AssImp;

internal static unsafe class ConvertMeshCommand
{
    public static Command Command { get; }

    private static readonly Argument<string> s_RootArgument = new("root");

    private static readonly Argument<string> s_InputArgument = new("input");

    private static readonly Argument<string> s_SkeletonArgument = new("skeleton");

    private static readonly Argument<string> s_OutputArgument = new("output");

    static ConvertMeshCommand()
    {
        Command = new Command("convert");
        Command.AddArgument(s_InputArgument);
        Command.AddArgument(s_RootArgument);
        Command.AddArgument(s_SkeletonArgument);
        Command.AddArgument(s_OutputArgument);
        Handler.SetHandler(Command, Execute);
    }

    public static void Execute(InvocationContext context)
    {
        var root     = context.ParseResult.GetValueForArgument(s_RootArgument);
        var input    = context.ParseResult.GetValueForArgument(s_InputArgument);
        var output   = context.ParseResult.GetValueForArgument(s_OutputArgument);
        var skelPath = context.ParseResult.GetValueForArgument(s_SkeletonArgument);
        var skeleton = new Skeleton();

        using (var fs = File.OpenRead(skelPath))
        {
            var reader = new UnStreamReader(fs);
            skeleton.Serialize(reader);
        }

        skeleton.ComputeIndices();
        skeleton.ComputeMatrices();

        if (!TryImportModel(input, skeleton, out var mesh))
        {
            Console.Error.WriteLine("Failed to import model.");
            return;
        }

        mesh.ComputeBoneInfo(skeleton);
        mesh.NormalizeBoneWeights();

        if (Path.GetDirectoryName(output) is { Length: > 0 } directory)
            Directory.CreateDirectory(directory);

        if (string.IsNullOrEmpty(mesh.Skeleton))
        {
            mesh.Skeleton = Path.GetRelativePath(root, skelPath).Replace('\\', '/');
        }

        using (var fs = File.Open(output, FileMode.Create, FileAccess.Write))
        {
            var writer = new UnStreamWriter(fs);
            mesh.Serialize(writer);
        }
    }

    private static bool TryImportModel(string path, Skeleton skeleton, [NotNullWhen(true)] out SkinMesh? mesh)
    {
        if (Path.GetExtension(path) == ".msh")
        {
            mesh = new SkinMesh();
            
            using var fs = File.OpenRead(path);
            {
                var reader = new UnStreamReader(fs);
                mesh.Serialize(reader);
            }

            return true;
        }

        aiScene* scene;
        var steps = 0
            | aiPostProcessSteps.aiProcess_GenSmoothNormals
            | aiPostProcessSteps.aiProcess_CalcTangentSpace
            | aiPostProcessSteps.aiProcess_Triangulate
            | aiPostProcessSteps.aiProcess_FlipUVs
            | aiPostProcessSteps.aiProcess_FlipWindingOrder
            | aiPostProcessSteps.aiProcess_GlobalScale
            | aiPostProcessSteps.aiProcess_LimitBoneWeights;

        var boneMap = new Dictionary<string, int>();

        for (int i = 0; i < skeleton.Bones.Count; i++)
        {
            boneMap[skeleton.Bones[i].Name] = i;
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
        aiReleaseImport(scene);
        return true;
    }

    private static SkinMesh CreateSkinMesh(aiScene* scene, Dictionary<string, int> boneMap)
    {
        var result        = new SkinMesh();
        ushort baseVertex = 0;

        // Init an invalid bbox
        result.BoundingBox = new BoundingBox
        {
            Min = new Vector3(float.MaxValue),
            Max = new Vector3(float.MinValue),
        };
        
        for (int m = 0; m < scene->mNumMeshes; m++)
        {
            var mesh  = scene->mMeshes[m];
            var group = new SkinMeshGroup();

            for (int i = 0; i < mesh->mNumVertices; i++)
            {
                result.Positions.Add(Swizzle(mesh->mVertices[i]));
                result.Normals.Add(Swizzle(mesh->mNormals[i]));
                result.Tangents.Add(Swizzle(mesh->mTangents[i]));
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
                    result.BoundingBox.Expand(result.Positions[index]);
                }
            }

            baseVertex += checked((ushort)mesh->mNumVertices);
            result.Groups.Add(group);
        }

        return result;
    }

    private static Vector3 Swizzle(aiVector3D v)
    {
        Vector3 r;
        r.X = v.z;
        r.Y = -v.x;
        r.Z = v.y;
        return r;
    }
}
