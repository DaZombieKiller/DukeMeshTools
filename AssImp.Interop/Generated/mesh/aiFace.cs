namespace AssImp.Interop;

public unsafe partial struct aiFace
{
    [NativeTypeName("unsigned int")]
    public uint mNumIndices;

    [NativeTypeName("unsigned int *")]
    public uint* mIndices;
}
