namespace DukeForever;

public sealed class SkinMeshBoneInfo : IUnSerializable
{
    public readonly List<BoneTriangleInfo> TriangleInfo = new();

    public bool Used;

    public BoundingBox BoundingBox;

    public void Serialize(UnSerializer ar)
    {
        int infoCount = TriangleInfo.Count;
        ar.Serialize(ref infoCount);
        TriangleInfo.EnsureCount(infoCount);

        for (int i = 0; i < infoCount; i++)
        {
            var info = TriangleInfo[i];
            info.Serialize(ar);
            TriangleInfo[i] = info;
        }

        ar.Serialize(ref Used);
        BoundingBox.Serialize(ar);
    }
}
