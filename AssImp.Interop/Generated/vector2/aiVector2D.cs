namespace AssImp.Interop;

public partial struct aiVector2D
{
    [NativeTypeName("ai_real")]
    public float x;

    [NativeTypeName("ai_real")]
    public float y;
}
