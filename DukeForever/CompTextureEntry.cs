namespace DukeForever;

public sealed class CompTextureEntry : IUnSerializable
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

        if (ar.Version > 2)
        {
            ulong unknown = 0;
            ar.Serialize(ref unknown);
        }

        ar.Serialize(ref FileOffset);
    }
}
