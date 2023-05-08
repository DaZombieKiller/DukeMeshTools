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
}
