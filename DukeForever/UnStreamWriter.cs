namespace DukeForever;

public sealed class UnStreamWriter : UnSerializer
{
    public Stream BaseStream { get; }

    public UnStreamWriter(Stream stream)
        : base(isSaving: true)
    {
        BaseStream = stream;
    }

    public override void Serialize(Span<byte> data)
    {
        BaseStream.Write(data);
    }

    public override void Serialize(ReadOnlySpan<byte> data)
    {
        BaseStream.Write(data);
    }

    public override long Tell()
    {
        return BaseStream.Position;
    }

    public override void Seek(long offset)
    {
        BaseStream.Position = offset;
    }
}
