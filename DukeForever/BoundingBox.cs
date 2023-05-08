using System.Numerics;

namespace DukeForever;

public struct BoundingBox : IUnSerializable
{
    public Vector3 Min;

    public Vector3 Max;

    public bool IsValid;

    public void Serialize(UnSerializer ar)
    {
        ar.Serialize(ref Min.X);
        ar.Serialize(ref Min.Y);
        ar.Serialize(ref Min.Z);
        ar.Serialize(ref Max.X);
        ar.Serialize(ref Max.Y);
        ar.Serialize(ref Max.Z);
        ar.Serialize(ref IsValid);
    }

    public void Expand(Vector3 point)
    {
        Min = Vector3.Min(Min, point);
        Max = Vector3.Max(Max, point);
        IsValid = true;
    }
}
