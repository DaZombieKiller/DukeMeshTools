namespace AssImp.Interop;

public unsafe partial struct aiMaterial
{
    [NativeTypeName("struct aiMaterialProperty **")]
    public aiMaterialProperty** mProperties;

    [NativeTypeName("unsigned int")]
    public uint mNumProperties;

    [NativeTypeName("unsigned int")]
    public uint mNumAllocated;
}
