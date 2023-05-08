namespace AssImp.Interop;

public unsafe partial struct aiMetadata
{
    [NativeTypeName("unsigned int")]
    public uint mNumProperties;

    [NativeTypeName("struct aiString *")]
    public aiString* mKeys;

    [NativeTypeName("struct aiMetadataEntry *")]
    public aiMetadataEntry* mValues;
}
