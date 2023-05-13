namespace DukeForever;

public sealed class BumpTexture : IUnSerializable
{
    public int USize;

    public int VSize;

    public readonly List<int> Unknown0 = new();

    public readonly List<int> Unknown1 = new();

    public readonly List<int> MipOffsets = new();

    public readonly List<int> Unknown2 = new();

    public void Serialize(UnSerializer ar)
    {
        ar.Serialize(ref USize);
        ar.Serialize(ref VSize);
        int unk0 = 0;
        ar.Serialize(ref unk0);
        int unk1 = 0;
        ar.Serialize(ref unk1);
        float unk2 = 0;
        ar.Serialize(ref unk2);
        int unk3 = 0;
        ar.Serialize(ref unk3);
        int unk4 = 0;
        ar.Serialize(ref unk4);
        int unk5 = 0;
        ar.Serialize(ref unk5);
        int unk6 = 0;
        ar.Serialize(ref unk6);
        int unk7 = 0;
        ar.Serialize(ref unk7);
        int unk8 = 0;
        ar.Serialize(ref unk8);
        byte unk9 = 0;
        ar.Serialize(ref unk9);
        byte unk10 = 0;
        ar.Serialize(ref unk10);
        ar.Serialize(Unknown0);
        ar.Serialize(Unknown1);
        ar.Serialize(MipOffsets);
        ar.Serialize(Unknown2);
    }
}
