using System.Runtime.InteropServices;

namespace AssImp.Interop;

public static unsafe partial class AssImp
{
    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint aiGetExportFormatCount();

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const struct aiExportFormatDesc *")]
    public static extern aiExportFormatDesc* aiGetExportFormatDescription([NativeTypeName("size_t")] nuint pIndex);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiReleaseExportFormatDescription([NativeTypeName("const struct aiExportFormatDesc *")] aiExportFormatDesc* desc);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiCopyScene([NativeTypeName("const struct aiScene *")] aiScene* pIn, [NativeTypeName("struct aiScene **")] aiScene** pOut);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiFreeScene([NativeTypeName("const struct aiScene *")] aiScene* pIn);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern aiReturn aiExportScene([NativeTypeName("const struct aiScene *")] aiScene* pScene, [NativeTypeName("const char *")] sbyte* pFormatId, [NativeTypeName("const char *")] sbyte* pFileName, [NativeTypeName("unsigned int")] uint pPreprocessing);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern aiReturn aiExportSceneEx([NativeTypeName("const struct aiScene *")] aiScene* pScene, [NativeTypeName("const char *")] sbyte* pFormatId, [NativeTypeName("const char *")] sbyte* pFileName, [NativeTypeName("struct aiFileIO *")] aiFileIO* pIO, [NativeTypeName("unsigned int")] uint pPreprocessing);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const struct aiExportDataBlob *")]
    public static extern aiExportDataBlob* aiExportSceneToBlob([NativeTypeName("const struct aiScene *")] aiScene* pScene, [NativeTypeName("const char *")] sbyte* pFormatId, [NativeTypeName("unsigned int")] uint pPreprocessing);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiReleaseExportBlob([NativeTypeName("const struct aiExportDataBlob *")] aiExportDataBlob* pData);
}
