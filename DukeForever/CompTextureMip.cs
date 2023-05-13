namespace DukeForever;

public sealed class CompTextureMip : IUnSerializable
{
    public int USize;

    public int VSize;

    public byte[] Data = Array.Empty<byte>();

    public void Serialize(UnSerializer ar)
    {
        if (ar.IsSaving)
        {
            ar.AddLazyDataWriter(Data, true);
        }

        int offset = 0;
        ar.Serialize(ref offset);
        ar.Serialize(ref USize);
        ar.Serialize(ref VSize);

        if (!ar.IsSaving)
        {
            var tmp = ar.Tell();
            ar.Seek(offset);
            CompactIndex count = 0;
            ar.Serialize(ref count);
            Data = new byte[count];
            ar.Serialize(Data);
            ar.Seek(tmp);
        }
    }
}
