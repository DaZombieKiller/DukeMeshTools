using System.Runtime.InteropServices;

namespace AssImp.Interop;

public static unsafe partial class AssImp
{
    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* aiGetLegalString();

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint aiGetVersionPatch();

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint aiGetVersionMinor();

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint aiGetVersionMajor();

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint aiGetVersionRevision();

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* aiGetBranchName();

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint aiGetCompileFlags();

    [NativeTypeName("#define ASSIMP_CFLAGS_SHARED 0x1")]
    public const int ASSIMP_CFLAGS_SHARED = 0x1;

    [NativeTypeName("#define ASSIMP_CFLAGS_STLPORT 0x2")]
    public const int ASSIMP_CFLAGS_STLPORT = 0x2;

    [NativeTypeName("#define ASSIMP_CFLAGS_DEBUG 0x4")]
    public const int ASSIMP_CFLAGS_DEBUG = 0x4;

    [NativeTypeName("#define ASSIMP_CFLAGS_NOBOOST 0x8")]
    public const int ASSIMP_CFLAGS_NOBOOST = 0x8;

    [NativeTypeName("#define ASSIMP_CFLAGS_SINGLETHREADED 0x10")]
    public const int ASSIMP_CFLAGS_SINGLETHREADED = 0x10;

    [NativeTypeName("#define ASSIMP_CFLAGS_DOUBLE_SUPPORT 0x20")]
    public const int ASSIMP_CFLAGS_DOUBLE_SUPPORT = 0x20;
}
