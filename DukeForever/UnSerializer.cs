using System.Buffers;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace DukeForever;

public abstract class UnSerializer
{
    private readonly List<LazyDataWriter> _lazyWriters = new();

    protected UnSerializer(bool isSaving)
    {
        IsSaving = isSaving;
    }

    public int Version { get; set; }

    public bool IsSaving { get; }

    public abstract void Serialize(Span<byte> data);

    public abstract void Serialize(ReadOnlySpan<byte> data);

    public abstract long Tell();

    public abstract void Seek(long offset);

    public void Serialize<T>(List<T> values)
        where T : IUnSerializable, new()
    {
        CompactIndex count = values.Count;
        count.Serialize(this);
        Serialize(values, count);
    }

    public void Serialize(List<string> values)
    {
        CompactIndex count = values.Count;
        count.Serialize(this);
        Serialize(values, count);
    }

    public void Serialize(List<int> values)
    {
        CompactIndex count = values.Count;
        count.Serialize(this);
        Serialize(values, count);
    }

    public void Serialize<T>(List<T> values, int count)
        where T : IUnSerializable, new()
    {
        if (!IsSaving)
            values.Clear();

        for (int i = values.Count; i < count; i++)
            values.Add(new T());

        for (int i = 0; i < count; i++)
        {
            T value = values[i];
            value.Serialize(this);
            values[i] = value;
        }
    }

    public void Serialize(List<string> values, int count)
    {
        if (!IsSaving)
            values.Clear();

        for (int i = values.Count; i < count; i++)
            values.Add("");

        for (int i = 0; i < count; i++)
        {
            var value = values[i];
            Serialize(ref value);
            values[i] = value;
        }
    }

    public void Serialize(List<int> values, int count)
    {
        if (!IsSaving)
            values.Clear();

        for (int i = values.Count; i < count; i++)
            values.Add(0);

        for (int i = 0; i < count; i++)
        {
            var value = values[i];
            Serialize(ref value);
            values[i] = value;
        }
    }

    public void AddLazyDataWriter(ArraySegment<byte> data, bool lengthPrefixed)
    {
        var writer = new LazyDataWriter();
        writer.Initialize(this, data, lengthPrefixed);
        _lazyWriters.Add(writer);
    }

    public void Serialize<T>(ref T value)
        where T : unmanaged
    {
        Serialize(MemoryMarshal.AsBytes(new Span<T>(ref value)));
    }

    public void CommitLazyData()
    {
        foreach (var writer in _lazyWriters)
            writer.Commit();

        _lazyWriters.Clear();
    }

    public unsafe void ByteOrderSerialize<T>(ref T value)
        where T : unmanaged
    {
        var bytes = MemoryMarshal.AsBytes(new Span<T>(ref value));

        if (!BitConverter.IsLittleEndian)
        {
            if (sizeof(T) == sizeof(ushort))
            {
                BinaryPrimitives.WriteUInt16LittleEndian(bytes, Unsafe.As<T, ushort>(ref value));
            }
            else if (sizeof(T) == sizeof(uint))
            {
                BinaryPrimitives.WriteUInt32LittleEndian(bytes, Unsafe.As<T, uint>(ref value));
            }
            else if (sizeof(T) == sizeof(ulong))
            {
                BinaryPrimitives.WriteUInt64LittleEndian(bytes, Unsafe.As<T, ulong>(ref value));
            }
        }

        Serialize(bytes);
    }

    public void SerializeFixedString(ref string value, int length)
    {
        var buffer = ArrayPool<byte>.Shared.Rent(length);

        if (IsSaving)
        {
            buffer[^1] = 0;
            Encoding.UTF8.GetBytes(value, buffer.AsSpan(0, length - 1));
        }

        Serialize(buffer.AsSpan(0, length));

        if (!IsSaving)
        {
            var n = buffer.AsSpan(0, length).IndexOf((byte)0);
            value = Encoding.UTF8.GetString(buffer.AsSpan(0, n == -1 ? length : n));
        }
    }

    public void Serialize(ref string value)
    {
        CompactIndex length;

        if (IsSaving)
            ArgumentNullException.ThrowIfNull(value);

        if (IsSaving)
        {
            ushort ter = 0;
            length = new CompactIndex(-value.Length - 1);
            length.Serialize(this);
            Serialize(MemoryMarshal.AsBytes(value.AsSpan()));
            Serialize(ref ter);
            return;
        }

        length = default;
        length.Serialize(this);
        var encoding = Encoding.UTF8;

        if (length.Value < 0)
        {
            length   = int.Max(0, -length.Value) * 2;
            encoding = Encoding.Unicode;
        }

        var buffer = new byte[length];
        Serialize(buffer);
        value = encoding.GetString(buffer).TrimEnd('\0');
    }
}
