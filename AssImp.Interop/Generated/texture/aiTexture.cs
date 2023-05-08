namespace AssImp.Interop;

public unsafe partial struct aiTexture
{
    [NativeTypeName("unsigned int")]
    public uint mWidth;

    [NativeTypeName("unsigned int")]
    public uint mHeight;

    [NativeTypeName("char[9]")]
    public fixed sbyte achFormatHint[9];

    [NativeTypeName("struct aiTexel *")]
    public aiTexel* pcData;

    [NativeTypeName("struct aiString")]
    public aiString mFilename;
}
