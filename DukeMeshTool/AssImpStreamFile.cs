namespace DukeMeshTool;

public sealed class AssImpStreamFile : AssImpFile
{
    private bool _leaveOpen;

    public Stream BaseStream { get; }

    public AssImpStreamFile(Stream stream, bool leaveOpen)
    {
        BaseStream = stream;
        _leaveOpen = leaveOpen;
    }

    public override nuint FileSize()
    {
        return (nuint)BaseStream.Length;
    }

    public override void Flush()
    {
        BaseStream.Flush();
    }

    public override nuint Tell()
    {
        return (nuint)BaseStream.Position;
    }

    public override int Read(Span<byte> data)
    {
        return BaseStream.Read(data);
    }

    public override void Write(ReadOnlySpan<byte> data)
    {
        BaseStream.Write(data);
    }

    public override void Seek(nuint offset, SeekOrigin origin)
    {
        switch (origin)
        {
        case SeekOrigin.Current:
            BaseStream.Position += (long)offset;
            break;
        case SeekOrigin.End:
            BaseStream.Position = BaseStream.Length - (long)offset;
            break;
        case SeekOrigin.Begin:
            BaseStream.Position = (long)offset;
            break;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && !_leaveOpen)
        {
            BaseStream.Dispose();
        }
    }
}
