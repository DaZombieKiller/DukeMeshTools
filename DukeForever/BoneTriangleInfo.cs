namespace DukeForever;

public struct BoneTriangleInfo : IUnSerializable
{
    public byte Group;

    public int TriangleIndex;

    public void Serialize(UnSerializer ar)
    {
        ar.Serialize(ref Group);
        ar.Serialize(ref TriangleIndex);
    }
}
