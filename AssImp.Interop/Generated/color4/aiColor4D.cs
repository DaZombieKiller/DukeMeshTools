namespace AssImp.Interop;

public partial struct aiColor4D
{
    [NativeTypeName("ai_real")]
    public float r;

    [NativeTypeName("ai_real")]
    public float g;

    [NativeTypeName("ai_real")]
    public float b;

    [NativeTypeName("ai_real")]
    public float a;
}
