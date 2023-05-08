namespace AssImp.Interop;

public unsafe partial struct aiLogStream
{
    [NativeTypeName("aiLogStreamCallback")]
    public delegate* unmanaged[Cdecl]<sbyte*, sbyte*, void> callback;

    [NativeTypeName("char *")]
    public sbyte* user;
}
