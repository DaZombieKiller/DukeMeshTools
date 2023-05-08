namespace AssImp.Interop;

public unsafe partial struct aiExportFormatDesc
{
    [NativeTypeName("const char *")]
    public sbyte* id;

    [NativeTypeName("const char *")]
    public sbyte* description;

    [NativeTypeName("const char *")]
    public sbyte* fileExtension;
}
