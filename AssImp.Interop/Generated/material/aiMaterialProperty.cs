namespace AssImp.Interop;

public unsafe partial struct aiMaterialProperty
{
    [NativeTypeName("struct aiString")]
    public aiString mKey;

    [NativeTypeName("unsigned int")]
    public uint mSemantic;

    [NativeTypeName("unsigned int")]
    public uint mIndex;

    [NativeTypeName("unsigned int")]
    public uint mDataLength;

    [NativeTypeName("enum aiPropertyTypeInfo")]
    public aiPropertyTypeInfo mType;

    [NativeTypeName("char *")]
    public sbyte* mData;
}
