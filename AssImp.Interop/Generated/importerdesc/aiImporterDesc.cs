namespace AssImp.Interop;

public unsafe partial struct aiImporterDesc
{
    [NativeTypeName("const char *")]
    public sbyte* mName;

    [NativeTypeName("const char *")]
    public sbyte* mAuthor;

    [NativeTypeName("const char *")]
    public sbyte* mMaintainer;

    [NativeTypeName("const char *")]
    public sbyte* mComments;

    [NativeTypeName("unsigned int")]
    public uint mFlags;

    [NativeTypeName("unsigned int")]
    public uint mMinMajor;

    [NativeTypeName("unsigned int")]
    public uint mMinMinor;

    [NativeTypeName("unsigned int")]
    public uint mMaxMajor;

    [NativeTypeName("unsigned int")]
    public uint mMaxMinor;

    [NativeTypeName("const char *")]
    public sbyte* mFileExtensions;
}
