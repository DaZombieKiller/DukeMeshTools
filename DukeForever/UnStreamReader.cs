namespace DukeForever;

public sealed class UnStreamReader : UnSerializer
{
    public Stream BaseStream { get; }

    public UnStreamReader(Stream stream)
        : base(isSaving: false)
    {
        BaseStream = stream;
    }

    public override void Serialize(Span<byte> data)
    {
        BaseStream.ReadExactly(data);
    }

    public override void Serialize(ReadOnlySpan<byte> data)
    {
        throw new InvalidOperationException();
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
