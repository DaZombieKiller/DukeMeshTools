namespace DukeForever;

public sealed class SkinMeshPackage : IUnSerializable
{
    public List<SkinMeshFile> Entries { get; } = new();

    public void Serialize(UnSerializer ar)
    {
        var count = new CompactIndex(Entries.Count);
        count.Serialize(ar);
        Entries.EnsureCount(count);

        for (int i = 0; i < count; i++)
        {
            Entries[i].Serialize(ar);
        }
    }
}
