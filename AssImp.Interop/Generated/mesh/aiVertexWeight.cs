namespace AssImp.Interop;

public partial struct aiVertexWeight
{
    [NativeTypeName("unsigned int")]
    public uint mVertexId;

    [NativeTypeName("ai_real")]
    public float mWeight;
}
