using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace DukeForever;

public struct BlendIndices
{
    public byte BoneIndex0;

    public byte BoneIndex1;

    public byte BoneIndex2;

    public byte BoneIndex3;

    [UnscopedRef]
    public ref byte this[int index]
    {
        get
        {
            if ((uint)index >= 4u)
                throw new IndexOutOfRangeException();

            return ref Unsafe.Add(ref BoneIndex0, index);
        }
    }
}
