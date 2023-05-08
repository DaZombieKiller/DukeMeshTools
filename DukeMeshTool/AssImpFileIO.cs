using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssImp.Interop;
using Microsoft.Win32.SafeHandles;

namespace DukeMeshTool;

public abstract unsafe class AssImpFileIO : IDisposable
{
    private bool _disposed;

    private readonly SafeFileIOHandle _handle;

    protected AssImpFileIO()
    {
        _handle = new SafeFileIOHandle(this);
    }

    public SafeHandle SafeHandle
    {
        get
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
            return _handle;
        }
    }

    public aiFileIO* Handle
    {
        get
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
            return _handle.handle;
        }
    }

    public static AssImpFileIO GetFromPointer(aiFileIO* pIO)
    {
        ArgumentNullException.ThrowIfNull(pIO);
        return (AssImpFileIO)GCHandle.FromIntPtr((nint)pIO->UserData).Target!;
    }

    public abstract AssImpFile Open(string path, FileAccess mode);

    public abstract void Close(AssImpFile file);

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static aiFile* Open(aiFileIO* pIO, sbyte* pPath, sbyte* pMode)
    {
        var io   = GetFromPointer(pIO);
        var path = Marshal.PtrToStringUTF8((nint)pPath)!;
        var mode = (FileAccess)0;

        foreach (char c in Marshal.PtrToStringUTF8((nint)pMode)!)
        {
            switch (c)
            {
            case 'r':
                mode |= FileAccess.Read;
                break;
            case 'w':
                mode |= FileAccess.Write;
                break;
            }
        }

        try
        {
            var file = io.Open(path, mode);
            return file.Handle;
        }
        catch
        {
            return null;
        }
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void Close(aiFileIO* pIO, aiFile* pFile)
    {
        var io   = GetFromPointer(pIO);
        var file = AssImpFile.GetFromPointer(pFile);
        io.Close(file);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _handle.Dispose();
        }
    }

    public void Dispose()
    {
        if (_disposed)
            return;

        Dispose(true);
        GC.SuppressFinalize(this);
        _disposed = true;
    }

    private sealed class SafeFileIOHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public new aiFileIO* handle
        {
            get => (aiFileIO*)base.handle;
            set => base.handle = (nint)value;
        }

        public SafeFileIOHandle(AssImpFileIO owner)
            : base(ownsHandle: true)
        {
            handle = (aiFileIO*)NativeMemory.Alloc((uint)sizeof(aiFileIO));
            handle->OpenProc  = &Open;
            handle->CloseProc = &AssImpFileIO.Close;
            handle->UserData  = (sbyte*)GCHandle.ToIntPtr(GCHandle.Alloc(owner));
        }

        protected override bool ReleaseHandle()
        {
            GCHandle.FromIntPtr((nint)handle->UserData).Free();
            NativeMemory.Free(handle);
            return true;
        }
    }
}
