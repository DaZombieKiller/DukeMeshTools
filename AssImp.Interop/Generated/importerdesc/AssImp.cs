using System.Runtime.InteropServices;

namespace AssImp.Interop;

public static unsafe partial class AssImp
{
    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const struct aiImporterDesc *")]
    public static extern aiImporterDesc* aiGetImporterDesc([NativeTypeName("const char *")] sbyte* extension);
}
