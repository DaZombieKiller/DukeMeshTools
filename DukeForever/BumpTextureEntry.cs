namespace DukeForever;

public sealed class BumpTextureEntry : IUnSerializable
{
    public readonly List<CompactIndex> PathIndices = new();

    public int FileIndex;

    public int FileOffset;

    public void Serialize(UnSerializer ar)
    {
        int count = PathIndices.Count;
        ar.Serialize(ref count);
        ar.Serialize(PathIndices, count);
        ar.Serialize(ref FileIndex);
        ar.Serialize(ref FileOffset);

        if (ar.Version > 2)
        {
            int unknown0 = 0;
            ar.Serialize(ref unknown0);
            int unknown1 = 0;
            ar.Serialize(ref unknown1);
            byte unknown2 = 0;
            ar.Serialize(ref unknown2);
        }

        if (ar.Version > 4)
        {
            ulong unknown = 0;
            ar.Serialize(ref unknown);
        }
    }
}
