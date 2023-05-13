namespace DukeForever;

public sealed class CompTexture : IUnSerializable
{
    public ETextureFormat Format;

    public readonly List<CompTextureMip> Mips = new();

    public readonly List<int> Unknown = new();

    public void Serialize(UnSerializer ar)
    {
        int unknown0 = 0;
        ar.Serialize(ref unknown0);
        ar.Serialize(ref Format);

        if (unknown0 > 1)
        {
            byte unknown1 = 0;
            ar.Serialize(ref unknown1);
            int unknown2 = 0;
            ar.Serialize(ref unknown2);
            int unknown3 = 0;
            ar.Serialize(ref unknown3);
        }

        if (unknown0 > 0)
        {
            ar.Serialize(Mips);
        }
        else
        {
            ar.Serialize(Unknown);
        }

        if (unknown0 < 2)
        {
            byte unknown1 = 0;
            ar.Serialize(ref unknown1);
            int unknown2 = 0;
            ar.Serialize(ref unknown2);
        }
    }
}
