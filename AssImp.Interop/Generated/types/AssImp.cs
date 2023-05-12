using static AssImp.Interop.aiDefaultLogStream;
using static AssImp.Interop.aiReturn;

namespace AssImp.Interop;

public static partial class AssImp
{
    [NativeTypeName("#define MAXLEN 1024")]
    public const int MAXLEN = 1024;

    [NativeTypeName("#define AI_SUCCESS aiReturn_SUCCESS")]
    public const aiReturn AI_SUCCESS = aiReturn_SUCCESS;

    [NativeTypeName("#define AI_FAILURE aiReturn_FAILURE")]
    public const aiReturn AI_FAILURE = aiReturn_FAILURE;

    [NativeTypeName("#define AI_OUTOFMEMORY aiReturn_OUTOFMEMORY")]
    public const aiReturn AI_OUTOFMEMORY = aiReturn_OUTOFMEMORY;

    [NativeTypeName("#define DLS_FILE aiDefaultLogStream_FILE")]
    public const aiDefaultLogStream DLS_FILE = aiDefaultLogStream_FILE;

    [NativeTypeName("#define DLS_STDOUT aiDefaultLogStream_STDOUT")]
    public const aiDefaultLogStream DLS_STDOUT = aiDefaultLogStream_STDOUT;

    [NativeTypeName("#define DLS_STDERR aiDefaultLogStream_STDERR")]
    public const aiDefaultLogStream DLS_STDERR = aiDefaultLogStream_STDERR;

    [NativeTypeName("#define DLS_DEBUGGER aiDefaultLogStream_DEBUGGER")]
    public const aiDefaultLogStream DLS_DEBUGGER = aiDefaultLogStream_DEBUGGER;
}
