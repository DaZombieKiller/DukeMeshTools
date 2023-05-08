namespace DukeForever;

public static class MemoryExtensions
{
    public static Span<T> Terminate<T>(this Span<T> span, T value)
        where T : IEquatable<T>
    {
        int index = span.IndexOf(value);

        if (index == -1)
            return span;

        return span[..index];
    }

    public static ReadOnlySpan<T> Terminate<T>(this ReadOnlySpan<T> span, T value)
        where T : IEquatable<T>
    {
        int index = span.IndexOf(value);

        if (index == -1)
            return span;

        return span[..index];
    }
}
