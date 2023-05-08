namespace DukeForever;

public struct CompactIndex : IUnSerializable
{
    public int Value { get; set; }

    public static implicit operator int(CompactIndex index) => index.Value;

    public static implicit operator CompactIndex(int value) => new(value);

    public CompactIndex(int value)
    {
        Value = value;
    }

    public unsafe void Serialize(UnSerializer ar)
    {
        var v = Math.Abs(Value);
        var b = (byte)(v & 0x3F);

        // continuation bit
        if (v >= 0x40) b |= 0x40;

        // sign bit
        if (Value < 0) b |= 0x80;

        ar.Serialize(ref b);
        var sign = (b & 0x80) != 0;
        Value    = b & 0x3F;

        if ((b & 0x40) != 0)
        {
            int shift = 6;

            do
            {
                b = (byte)((v >> shift) & 0x7F);
                
                if ((v >> shift) >= 0x80)
                    b |= 0x80;

                ar.Serialize(ref b);
                Value |= (b & 0x7F) << shift;
                shift += 7;

            } while ((b & 0x80) != 0 && shift < 28);
        }

        if (sign) Value = -Value;
    }
}
