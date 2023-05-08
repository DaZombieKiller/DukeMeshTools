using System.Numerics;

namespace DukeForever;

public sealed class SkinMesh : IUnSerializable
{
    public string Skeleton = "";

    public readonly List<Vector3> Positions = new();

    public readonly List<Vector3> Normals = new();

    public readonly List<Vector3> Tangents = new();

    public readonly List<Vector3> UVs = new();

    public readonly List<byte> BonesPerVertex = new();

    public readonly List<BlendIndices> BlendIndices = new();

    public readonly List<BlendWeights> BlendWeights = new();

    public readonly List<SkinMeshGroup> Groups = new();

    public readonly List<SkinMeshBoneInfo> BoneInfo = new();

    public BoundingBox BoundingBox;

    public int Unknown;

    public void ComputeBoundingBox(float scale = 2)
    {
        BoundingBox = new BoundingBox
        {
            Min = new Vector3(float.PositiveInfinity),
            Max = new Vector3(float.NegativeInfinity),
        };

        for (int i = 0; i < Positions.Count; i++)
        {
            BoundingBox.Expand(Positions[i] * scale);
        }
    }

    public void NormalizeBoneWeights()
    {
        for (int i = 0; i < BlendWeights.Count; i++)
        {
            var weight = BlendWeights[i];
            var total  = weight.Weight0 + weight.Weight1 + weight.Weight2 + weight.Weight3;

            if (total <= 1)
                continue;

            weight.Weight0 /= total;
            weight.Weight1 /= total;
            weight.Weight2 /= total;
            weight.Weight3 /= total;
            BlendWeights[i] = weight;
        }
    }

    public void ComputeBoneInfo(Skeleton skeleton)
    {
        BoneInfo.Clear();
        BoneInfo.EnsureCount(skeleton.Bones.Count);

        var triCount  = 0;
        var influence = new float[skeleton.Bones.Count];

        for (int i = 0; i < Groups.Count; i++)
            triCount += Groups[i].Indices.Count / 3;

        foreach (var info in BoneInfo)
        {
            info.BoundingBox = new BoundingBox
            {
                Min = new Vector3(float.MaxValue),
                Max = new Vector3(float.MinValue),
            };
        }

        // For each triangle, determine which bone has the most influence on it.
        for (int g = 0, offset = 0; g < Groups.Count; g++)
        {
            for (int t = 0; t < Groups[g].Indices.Count / 3; t++)
            {
                Array.Clear(influence, 0, influence.Length);
                
                for (int i = 0; i < 3; i++)
                {
                    var vertex  = Groups[g].Indices[3 * t + i];
                    var weights = BlendWeights[vertex];
                    var indices = BlendIndices[vertex];

                    for (int w = 0; w < 4; w++)
                    {
                        influence[indices[w]] += weights[w];
                    }
                }

                var maxWeight = 0.0f;
                var boneIndex = (byte)0xFF;

                for (int i = 0; i < influence.Length; i++)
                {
                    if (influence[i] > maxWeight)
                    {
                        maxWeight = influence[i];
                        boneIndex = (byte)i;
                    }
                }

                // Expand the bone's local space bounding box to include the vertices of this triangle.
                Matrix4x4.Invert(skeleton.Bones[boneIndex].WorldMatrix, out var inverseBindPose);

                for (int i = 0; i < 3; i++)
                {
                    var vertex = Groups[g].Indices[3 * t + i];
                    BoneInfo[boneIndex].BoundingBox.Expand(inverseBindPose.MultiplyPoint3x4(Positions[vertex]));
                    BoneInfo[boneIndex].Used = true;
                }

                BoneInfo[boneIndex].TriangleInfo.Add(new BoneTriangleInfo
                {
                    Group = (byte)g,
                    TriangleIndex = t
                });
            }

            offset += Groups[g].Indices.Count / 3;
        }

        foreach (var info in BoneInfo)
        {
            if (info.Used)
                continue;

            info.BoundingBox = new BoundingBox
            {
                Min     = new Vector3(-0.5f, -0.5f, -0.5f),
                Max     = new Vector3(0.5f, 0.5f, 0.5f),
                IsValid = true
            };
        }
    }

    public void Serialize(UnSerializer ar)
    {
        ushort version = 3;
        ar.Serialize(ref version);

        switch (version)
        {
        case 1:
            Serialize1(ar);
            break;
        case 2:
        case 3:
            Serialize2(ar);
            break;
        }
    }

    private void Serialize1(UnSerializer ar)
    {
        throw new NotImplementedException();
    }

    private void Serialize2(UnSerializer ar)
    {
        ar.SerializeFixedString(ref Skeleton, 128);
        ushort vertexCount = (ushort)Positions.Count;
        ar.Serialize(ref vertexCount);
        Positions.EnsureCount(vertexCount);
        Normals.EnsureCount(vertexCount);
        Tangents.EnsureCount(vertexCount);
        UVs.EnsureCount(vertexCount);

        for (int i = 0; i < vertexCount; i++)
        {
            var value = Positions[i];
            ar.Serialize(ref value);
            Positions[i] = value;
        }

        for (int i = 0; i < vertexCount; i++)
        {
            var value = Normals[i];
            ar.Serialize(ref value);
            Normals[i] = value;
        }

        for (int i = 0; i < vertexCount; i++)
        {
            var value = Tangents[i];
            ar.Serialize(ref value);
            Tangents[i] = value;
        }

        for (int i = 0; i < vertexCount; i++)
        {
            var value = UVs[i];
            ar.Serialize(ref value);
            UVs[i] = value;
        }

        byte groupCount = (byte)Groups.Count;
        ar.Serialize(ref groupCount);
        Groups.EnsureCount(groupCount);

        for (int i = 0; i < groupCount; i++)
            Groups[i].Serialize(ar);

        BonesPerVertex.EnsureCount(vertexCount);
        BlendIndices.EnsureCount(vertexCount);
        BlendWeights.EnsureCount(vertexCount);

        for (int i = 0; i < vertexCount; i++)
        {
            var value = BonesPerVertex[i];
            ar.Serialize(ref value);
            BonesPerVertex[i] = value;
        }

        for (int i = 0; i < vertexCount; i++)
        {
            var value = BlendIndices[i];
            ar.Serialize(ref value);
            BlendIndices[i] = value;
        }

        for (int i = 0; i < vertexCount; i++)
        {
            var value = BlendWeights[i];
            ar.Serialize(ref value);
            BlendWeights[i] = value;
        }

        byte boneCount = (byte)BoneInfo.Count;
        ar.Serialize(ref boneCount);
        BoneInfo.EnsureCount(boneCount);

        for (int i = 0; i < boneCount; i++)
            BoneInfo[i].Serialize(ar);

        BoundingBox.Serialize(ar);
        ar.Serialize(ref Unknown);
    }
}
