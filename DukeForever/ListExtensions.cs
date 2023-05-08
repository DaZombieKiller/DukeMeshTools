namespace DukeForever;

public static class ListExtensions
{
    public static void EnsureCount<T>(this List<T> list, int count)
        where T : new()
    {
        list.EnsureCapacity(count);

        for (int i = list.Count; i < count; i++)
        {
            list.Add(new T());
        }
    }

    public static void EnsureCount(this List<string> list, int count)
    {
        list.EnsureCapacity(count);

        for (int i = list.Count; i < count; i++)
        {
            list.Add("");
        }
    }
}
