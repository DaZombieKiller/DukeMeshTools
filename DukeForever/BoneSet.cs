namespace DukeForever;

public sealed class BoneSet : IUnSerializable
{
    public string Name = "";

    public readonly List<string> Bones = new();

    public void Serialize(UnSerializer ar)
    {
        ar.SerializeFixedString(ref Name, 128);
        byte count = 0;
        ar.Serialize(ref count);
        Bones.EnsureCount(count);

        for (int i = 0; i < count; i++)
        {
            var value = Bones[i];
            ar.SerializeFixedString(ref value, 128);
            Bones[i] = value;
        }
    }
}
