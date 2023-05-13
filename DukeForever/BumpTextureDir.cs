namespace DukeForever;

public sealed class BumpTextureDir : IUnSerializable
{
    public int Tag = ('B' << 24) | ('D' << 16) | ('I' << 8) | 'R';

    public int Version = 4;

    public int Unknown0;

    public int Unknown1;

    public readonly List<CompiledBumpPackage> Packages = new();

    public readonly List<BumpTextureEntry> Textures = new();

    public readonly List<string> PathSegments = new();

    public void Serialize(UnSerializer ar)
    {
        ar.Serialize(ref Tag);
        ar.Serialize(ref Version);
        ar.Version = Version;

        if (Version < 5)
        {
            ar.Serialize(ref Unknown0);
            ar.Serialize(ref Unknown1);
            ar.Serialize(Packages);
            ar.Serialize(Textures);
            int count = PathSegments.Count;
            ar.Serialize(ref count);
            ar.Serialize(PathSegments, count);
        }
    }
}
