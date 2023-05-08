namespace DukeForever;

public sealed class SkinMeshFile : IUnSerializable
{
    public string Path = "";

    public byte[] Data = Array.Empty<byte>();

    public void Serialize(UnSerializer ar)
    {
        ar.SerializeFixedString(ref Path, 128);

        if (ar.IsSaving)
            ar.AddLazyDataWriter(Data, lengthPrefixed: false);

        int offset = 0;
        ar.Serialize(ref offset);
        int length = Data.Length;
        ar.Serialize(ref length);

        if (!ar.IsSaving)
        {
            var temp = ar.Tell();
            ar.Seek(offset);
            Data = new byte[length];
            ar.Serialize(Data);
            ar.Seek(temp);
        }
    }
}
