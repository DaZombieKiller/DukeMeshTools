using System.Numerics;
using System.Runtime.CompilerServices;
using SMatrix4x4 = System.Numerics.Matrix4x4;

namespace DukeForever;

// Referenced from Unity's implementation of Matrix4x4.
// For some reason I can't get System.Numerics.Matrix4x4 to have equivalent behaviour,
// and matrix math is far from my forte. This works, even though it makes me sad.

public struct Matrix4x4
{
    public float M11;
    public float M21;
    public float M31;
    public float M41;
    public float M12;
    public float M22;
    public float M32;
    public float M42;
    public float M13;
    public float M23;
    public float M33;
    public float M43;
    public float M14;
    public float M24;
    public float M34;
    public float M44;

    public Matrix4x4(Vector4 column1, Vector4 column2, Vector4 column3, Vector4 column4)
    {
        M11 = column1.X; M12 = column2.X; M13 = column3.X; M14 = column4.X;
        M21 = column1.Y; M22 = column2.Y; M23 = column3.Y; M24 = column4.Y;
        M31 = column1.Z; M32 = column2.Z; M33 = column3.Z; M34 = column4.Z;
        M41 = column1.W; M42 = column2.W; M43 = column3.W; M44 = column4.W;
    }

    public static unsafe bool Invert(Matrix4x4 matrix, out Matrix4x4 result)
    {
        Unsafe.SkipInit(out result);
        return SMatrix4x4.Invert(*(SMatrix4x4*)&matrix, out Unsafe.As<Matrix4x4, SMatrix4x4>(ref result));
    }

    public static unsafe Matrix4x4 Identity => new(
        new Vector4(1, 0, 0, 0),
        new Vector4(0, 1, 0, 0),
        new Vector4(0, 0, 1, 0),
        new Vector4(0, 0, 0, 1)
    );

    public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs)
    {
        Matrix4x4 m;
        m.M11 = lhs.M11 * rhs.M11 + lhs.M12 * rhs.M21 + lhs.M13 * rhs.M31 + lhs.M14 * rhs.M41;
        m.M12 = lhs.M11 * rhs.M12 + lhs.M12 * rhs.M22 + lhs.M13 * rhs.M32 + lhs.M14 * rhs.M42;
        m.M13 = lhs.M11 * rhs.M13 + lhs.M12 * rhs.M23 + lhs.M13 * rhs.M33 + lhs.M14 * rhs.M43;
        m.M14 = lhs.M11 * rhs.M14 + lhs.M12 * rhs.M24 + lhs.M13 * rhs.M34 + lhs.M14 * rhs.M44;

        m.M21 = lhs.M21 * rhs.M11 + lhs.M22 * rhs.M21 + lhs.M23 * rhs.M31 + lhs.M24 * rhs.M41;
        m.M22 = lhs.M21 * rhs.M12 + lhs.M22 * rhs.M22 + lhs.M23 * rhs.M32 + lhs.M24 * rhs.M42;
        m.M23 = lhs.M21 * rhs.M13 + lhs.M22 * rhs.M23 + lhs.M23 * rhs.M33 + lhs.M24 * rhs.M43;
        m.M24 = lhs.M21 * rhs.M14 + lhs.M22 * rhs.M24 + lhs.M23 * rhs.M34 + lhs.M24 * rhs.M44;

        m.M31 = lhs.M31 * rhs.M11 + lhs.M32 * rhs.M21 + lhs.M33 * rhs.M31 + lhs.M34 * rhs.M41;
        m.M32 = lhs.M31 * rhs.M12 + lhs.M32 * rhs.M22 + lhs.M33 * rhs.M32 + lhs.M34 * rhs.M42;
        m.M33 = lhs.M31 * rhs.M13 + lhs.M32 * rhs.M23 + lhs.M33 * rhs.M33 + lhs.M34 * rhs.M43;
        m.M34 = lhs.M31 * rhs.M14 + lhs.M32 * rhs.M24 + lhs.M33 * rhs.M34 + lhs.M34 * rhs.M44;

        m.M41 = lhs.M41 * rhs.M11 + lhs.M42 * rhs.M21 + lhs.M43 * rhs.M31 + lhs.M44 * rhs.M41;
        m.M42 = lhs.M41 * rhs.M12 + lhs.M42 * rhs.M22 + lhs.M43 * rhs.M32 + lhs.M44 * rhs.M42;
        m.M43 = lhs.M41 * rhs.M13 + lhs.M42 * rhs.M23 + lhs.M43 * rhs.M33 + lhs.M44 * rhs.M43;
        m.M44 = lhs.M41 * rhs.M14 + lhs.M42 * rhs.M24 + lhs.M43 * rhs.M34 + lhs.M44 * rhs.M44;
        return m;
    }

    public Vector3 MultiplyPoint3x4(Vector3 point)
    {
        Vector3 m;
        m.X = M11 * point.X + M12 * point.Y + M13 * point.Z + M14;
        m.Y = M21 * point.X + M22 * point.Y + M23 * point.Z + M24;
        m.Z = M31 * point.X + M32 * point.Y + M33 * point.Z + M34;
        return m;
    }

    public static Matrix4x4 Scale(Vector3 vector)
    {
        Matrix4x4 m;
        m.M11 = vector.X; m.M12 = 0F; m.M13 = 0F; m.M14 = 0F;
        m.M21 = 0F; m.M22 = vector.Y; m.M23 = 0F; m.M24 = 0F;
        m.M31 = 0F; m.M32 = 0F; m.M33 = vector.Z; m.M34 = 0F;
        m.M41 = 0F; m.M42 = 0F; m.M43 = 0F; m.M44 = 1F;
        return m;
    }

    public static Matrix4x4 Translate(Vector3 vector)
    {
        Matrix4x4 m;
        m.M11 = 1F; m.M12 = 0F; m.M13 = 0F; m.M14 = vector.X;
        m.M21 = 0F; m.M22 = 1F; m.M23 = 0F; m.M24 = vector.Y;
        m.M31 = 0F; m.M32 = 0F; m.M33 = 1F; m.M34 = vector.Z;
        m.M41 = 0F; m.M42 = 0F; m.M43 = 0F; m.M44 = 1F;
        return m;
    }

    public static Matrix4x4 Rotate(Quaternion q)
    {
        float x = q.X * 2.0F;
        float y = q.Y * 2.0F;
        float z = q.Z * 2.0F;
        float xx = q.X * x;
        float yy = q.Y * y;
        float zz = q.Z * z;
        float xy = q.X * y;
        float xz = q.X * z;
        float yz = q.Y * z;
        float wx = q.W * x;
        float wy = q.W * y;
        float wz = q.W * z;

        Matrix4x4 m;
        m.M11 = 1.0f - (yy + zz); m.M21 = xy + wz; m.M31 = xz - wy; m.M41 = 0.0F;
        m.M12 = xy - wz; m.M22 = 1.0f - (xx + zz); m.M32 = yz + wx; m.M42 = 0.0F;
        m.M13 = xz + wy; m.M23 = yz - wx; m.M33 = 1.0f - (xx + yy); m.M43 = 0.0F;
        m.M14 = 0.0F; m.M24 = 0.0F; m.M34 = 0.0F; m.M44 = 1.0F;
        return m;
    }
}
