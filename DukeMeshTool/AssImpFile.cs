using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssImp.Interop;
using Microsoft.Win32.SafeHandles;

namespace DukeMeshTool;

public abstract unsafe class AssImpFile : IDisposable
{
    private bool _disposed;

    private readonly SafeFileHandle _handle;

    protected AssImpFile()
    {
        _handle = new SafeFileHandle(this);
    }

    public static AssImpFile GetFromPointer(aiFile* pFile)
    {
        ArgumentNullException.ThrowIfNull(pFile);
        return (AssImpFile)GCHandle.FromIntPtr((nint)pFile->UserData).Target!;
    }

    public abstract int Read(Span<byte> data);

    public abstract void Write(ReadOnlySpan<byte> data);

    public abstract nuint Tell();

    public abstract nuint FileSize();

    public abstract void Seek(nuint offset, SeekOrigin origin);

    public abstract void Flush();

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static nuint Read(aiFile* pFile, sbyte* data, nuint size, nuint count)
    {
        count   *= size;
        count    = nuint.Min(count, int.MaxValue);
        var span = new Span<byte>(data, (int)count);
        return (uint)GetFromPointer(pFile).Read(span);
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static nuint Write(aiFile* pFile, sbyte* data, nuint size, nuint count)
    {
        count   *= size;
        count    = nuint.Min(count, int.MaxValue);
        var span = new Span<byte>(data, (int)count);
        GetFromPointer(pFile).Write(span);
        return count;
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static nuint Tell(aiFile* pFile)
    {
        return GetFromPointer(pFile).Tell();
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static nuint FileSize(aiFile* pFile)
    {
        return GetFromPointer(pFile).FileSize();
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static aiReturn Seek(aiFile* pFile, nuint offset, aiOrigin origin)
    {
        var file = GetFromPointer(pFile);

        try
        {
            file.Seek(offset, origin switch
            {
                aiOrigin.aiOrigin_SET => SeekOrigin.Begin,
                aiOrigin.aiOrigin_CUR => SeekOrigin.Current,
                aiOrigin.aiOrigin_END => SeekOrigin.End
            });
        }
        catch
        {
            return aiReturn.aiReturn_FAILURE;
        }

        return aiReturn.aiReturn_SUCCESS;
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void Flush(aiFile* pFile)
    {
        GetFromPointer(pFile).Flush();
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

    public SafeHandle SafeHandle
    {
        get
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
            return _handle;
        }
    }

    public aiFile* Handle
    {
        get
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
            return _handle.handle;
        }
    }

    private sealed class SafeFileHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public new aiFile* handle
        {
            get => (aiFile*)base.handle;
            set => base.handle = (nint)value;
        }

        public SafeFileHandle(AssImpFile owner)
            : base(ownsHandle: true)
        {
            handle = (aiFile*)NativeMemory.Alloc((uint)sizeof(aiFile));
            handle->ReadProc     = &Read;
            handle->WriteProc    = &Write;
            handle->TellProc     = &Tell;
            handle->FileSizeProc = &FileSize;
            handle->SeekProc     = &Seek;
            handle->FlushProc    = &Flush;
            handle->UserData     = (sbyte*)GCHandle.ToIntPtr(GCHandle.Alloc(owner));
        }

        protected override bool ReleaseHandle()
        {
            GCHandle.FromIntPtr((nint)handle->UserData).Free();
            NativeMemory.Free(handle);
            return true;
        }
    }
}
