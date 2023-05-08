namespace AssImp.Interop;

public unsafe partial struct aiFileIO
{
    [NativeTypeName("aiFileOpenProc")]
    public delegate* unmanaged[Cdecl]<aiFileIO*, sbyte*, sbyte*, aiFile*> OpenProc;

    [NativeTypeName("aiFileCloseProc")]
    public delegate* unmanaged[Cdecl]<aiFileIO*, aiFile*, void> CloseProc;

    [NativeTypeName("aiUserData")]
    public sbyte* UserData;
}
