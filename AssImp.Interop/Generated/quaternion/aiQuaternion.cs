namespace AssImp.Interop;

public partial struct aiQuaternion
{
    [NativeTypeName("ai_real")]
    public float w;

    [NativeTypeName("ai_real")]
    public float x;

    [NativeTypeName("ai_real")]
    public float y;

    [NativeTypeName("ai_real")]
    public float z;
}
