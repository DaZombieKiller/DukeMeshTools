namespace DukeForever;

public sealed class LazyDataWriter
{
    private long _offset;

    private ArraySegment<byte> _data;

    private UnSerializer? _archive;

    private bool _prefix;

    public LazyDataWriter()
    {
    }

    public void Initialize(UnSerializer ar, ArraySegment<byte> data, bool lengthPrefixed)
    {
        _archive = ar;
        _offset  = ar.Tell();
        _data    = data;
        _prefix  = lengthPrefixed;
    }

    public void Commit()
    {
        var dataOffset = (int)_archive!.Tell();

        if (_prefix)
        {
            var length = new CompactIndex(_data.Count);
            length.Serialize(_archive);
        }

        _archive.Serialize(_data);
        var endOffset = _archive.Tell();
        _archive.Seek(_offset);
        _archive.Serialize(ref dataOffset);
        _archive.Seek(endOffset);
    }
}
