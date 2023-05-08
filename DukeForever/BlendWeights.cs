using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace DukeForever;

public struct BlendWeights
{
    public float Weight0;

    public float Weight1;

    public float Weight2;

    public float Weight3;

    [UnscopedRef]
    public ref float this[int index]
    {
        get
        {
            if ((uint)index >= 4u)
                throw new IndexOutOfRangeException();

            return ref Unsafe.Add(ref Weight0, index);
        }
    }
}
