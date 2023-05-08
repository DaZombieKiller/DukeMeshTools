namespace DukeForever;

public sealed class Skeleton : IUnSerializable
{
    public readonly List<Bone> Bones = new();

    public readonly List<BoneSet> BoneSets = new();

    public void ComputeMatrices()
    {
        for (int i = 0; i < Bones.Count; i++)
        {
            var rotate = Bones[i].Rotate;

            // TODO: Why is this needed for correct results?
            rotate.W *= -1;

            var t = Matrix4x4.Translate(Bones[i].Translate);
            var r = Matrix4x4.Rotate(rotate);
            var s = Matrix4x4.Scale(Bones[i].Scale);
            Bones[i].LocalMatrix = t * r * s;
        }

        for (int i = 0; i < Bones.Count; i++)
        {
            Bones[i].WorldMatrix = Bones[i].LocalMatrix;

            for (int parent = Bones[i].Parent; parent != 0xFF; parent = Bones[parent].Parent)
            {
                Bones[i].WorldMatrix = Bones[parent].LocalMatrix * Bones[i].WorldMatrix;
            }
        }
    }

    public void ComputeIndices()
    {
        for (int i = 0; i < Bones.Count; i++)
        {
            Bones[i].Index = (byte)i;
            Bones[i].Children.Clear();

            if (Bones[i].Parent != 0xFF)
            {
                Bones[Bones[i].Parent].Children.Add((byte)i);
            }
        }
    }

    public void Serialize(UnSerializer ar)
    {
        ushort version = 0;
        ar.Serialize(ref version);

        switch (version)
        {
        case 0:
            Serialize0(ar);
            break;
        }
    }

    private void Serialize0(UnSerializer ar)
    {
        byte boneCount = 0;
        ar.Serialize(ref boneCount);
        Bones.EnsureCount(boneCount);

        for (int i = 0; i < boneCount; i++)
        {
            Bones[i].Serialize(ar);
        }

        byte boneSetCount = 0;
        ar.Serialize(ref boneSetCount);
        BoneSets.EnsureCount(boneSetCount);

        for (int i = 0; i < boneSetCount; i++)
        {
            BoneSets[i].Serialize(ar);
        }
    }
}
