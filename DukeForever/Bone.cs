using System.Numerics;

namespace DukeForever;

public sealed class Bone : IUnSerializable
{
    public string Name = "";

    public byte Index;

    public byte Parent = 0xFF;

    public Vector3 Scale = Vector3.One;

    public Vector3 Translate;

    public Quaternion Rotate = Quaternion.Identity;

    public Matrix4x4 LocalMatrix = Matrix4x4.Identity;

    public Matrix4x4 WorldMatrix = Matrix4x4.Identity;

    public readonly List<byte> Children = new();

    public void Serialize(UnSerializer ar)
    {
        ushort version = 0;
        ar.Serialize(ref version);
        ar.SerializeFixedString(ref Name, 64);
        ar.Serialize(ref Index);
        ar.Serialize(ref Parent);
        ar.Serialize(ref Scale);
        ar.Serialize(ref Translate);
        ar.Serialize(ref Rotate);
        byte childCount = (byte)Children.Count;
        ar.Serialize(ref childCount);
        Children.EnsureCount(childCount);
        for (int i = 0; i < childCount; i++)
        {
            var value = Children[i];
            ar.Serialize(ref value);
            Children[i] = value;
        }
    }
}
