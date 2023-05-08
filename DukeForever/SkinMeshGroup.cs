namespace DukeForever;

public sealed class SkinMeshGroup : IUnSerializable
{
    public readonly List<int> Indices = new();

    public ushort MinVertex;

    public ushort MaxVertex;

    public void Serialize(UnSerializer ar)
    {
        int count = Indices.Count / 3;
        ar.Serialize(ref count);
        Indices.EnsureCount(count * 3);
        MinVertex = ushort.MaxValue;
        MaxVertex = ushort.MinValue;

        for (int i = 0; i < count * 3; i++)
        {
            ushort value = (ushort)Indices[i];
            ar.Serialize(ref value);
            Indices[i] = value;
            MinVertex = ushort.Min(MinVertex, value);
            MaxVertex = ushort.Max(MaxVertex, value);
        }

        ar.Serialize(ref MinVertex);
        ar.Serialize(ref MaxVertex);
    }
}
