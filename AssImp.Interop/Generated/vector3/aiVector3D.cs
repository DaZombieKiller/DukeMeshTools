namespace AssImp.Interop;

public partial struct aiVector3D
{
    [NativeTypeName("ai_real")]
    public float x;

    [NativeTypeName("ai_real")]
    public float y;

    [NativeTypeName("ai_real")]
    public float z;
}
