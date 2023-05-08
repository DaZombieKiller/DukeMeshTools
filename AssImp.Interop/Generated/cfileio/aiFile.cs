namespace AssImp.Interop;

public unsafe partial struct aiFile
{
    [NativeTypeName("aiFileReadProc")]
    public delegate* unmanaged[Cdecl]<aiFile*, sbyte*, nuint, nuint, nuint> ReadProc;

    [NativeTypeName("aiFileWriteProc")]
    public delegate* unmanaged[Cdecl]<aiFile*, sbyte*, nuint, nuint, nuint> WriteProc;

    [NativeTypeName("aiFileTellProc")]
    public delegate* unmanaged[Cdecl]<aiFile*, nuint> TellProc;

    [NativeTypeName("aiFileTellProc")]
    public delegate* unmanaged[Cdecl]<aiFile*, nuint> FileSizeProc;

    [NativeTypeName("aiFileSeek")]
    public delegate* unmanaged[Cdecl]<aiFile*, nuint, aiOrigin, aiReturn> SeekProc;

    [NativeTypeName("aiFileFlushProc")]
    public delegate* unmanaged[Cdecl]<aiFile*, void> FlushProc;

    [NativeTypeName("aiUserData")]
    public sbyte* UserData;
}
