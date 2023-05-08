namespace AssImp.Interop;

public partial struct aiQuatKey
{
    public double mTime;

    [NativeTypeName("struct aiQuaternion")]
    public aiQuaternion mValue;
}
