namespace AssImp.Interop;

public unsafe partial struct aiExportDataBlob
{
    [NativeTypeName("size_t")]
    public nuint size;

    public void* data;

    [NativeTypeName("struct aiString")]
    public aiString name;

    [NativeTypeName("struct aiExportDataBlob *")]
    public aiExportDataBlob* next;
}
