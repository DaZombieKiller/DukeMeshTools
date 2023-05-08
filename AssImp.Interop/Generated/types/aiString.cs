namespace AssImp.Interop;

public unsafe partial struct aiString
{
    [NativeTypeName("ai_uint32")]
    public uint length;

    [NativeTypeName("char[1024]")]
    public fixed sbyte data[1024];
}
