using System.Runtime.InteropServices;

namespace AssImp.Interop;

public static unsafe partial class AssImp
{
    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* aiTextureTypeToString([NativeTypeName("enum aiTextureType")] aiTextureType @in);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("enum aiReturn")]
    public static extern aiReturn aiGetMaterialProperty([NativeTypeName("const struct aiMaterial *")] aiMaterial* pMat, [NativeTypeName("const char *")] sbyte* pKey, [NativeTypeName("unsigned int")] uint type, [NativeTypeName("unsigned int")] uint index, [NativeTypeName("const struct aiMaterialProperty **")] aiMaterialProperty** pPropOut);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("enum aiReturn")]
    public static extern aiReturn aiGetMaterialFloatArray([NativeTypeName("const struct aiMaterial *")] aiMaterial* pMat, [NativeTypeName("const char *")] sbyte* pKey, [NativeTypeName("unsigned int")] uint type, [NativeTypeName("unsigned int")] uint index, [NativeTypeName("ai_real *")] float* pOut, [NativeTypeName("unsigned int *")] uint* pMax);

    public static aiReturn aiGetMaterialFloat([NativeTypeName("const struct aiMaterial *")] aiMaterial* pMat, [NativeTypeName("const char *")] sbyte* pKey, [NativeTypeName("unsigned int")] uint type, [NativeTypeName("unsigned int")] uint index, [NativeTypeName("ai_real *")] float* pOut)
    {
        return aiGetMaterialFloatArray(pMat, pKey, type, index, pOut, unchecked((uint*)(0x0)));
    }

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("enum aiReturn")]
    public static extern aiReturn aiGetMaterialIntegerArray([NativeTypeName("const struct aiMaterial *")] aiMaterial* pMat, [NativeTypeName("const char *")] sbyte* pKey, [NativeTypeName("unsigned int")] uint type, [NativeTypeName("unsigned int")] uint index, int* pOut, [NativeTypeName("unsigned int *")] uint* pMax);

    public static aiReturn aiGetMaterialInteger([NativeTypeName("const struct aiMaterial *")] aiMaterial* pMat, [NativeTypeName("const char *")] sbyte* pKey, [NativeTypeName("unsigned int")] uint type, [NativeTypeName("unsigned int")] uint index, int* pOut)
    {
        return aiGetMaterialIntegerArray(pMat, pKey, type, index, pOut, unchecked((uint*)(0x0)));
    }

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("enum aiReturn")]
    public static extern aiReturn aiGetMaterialColor([NativeTypeName("const struct aiMaterial *")] aiMaterial* pMat, [NativeTypeName("const char *")] sbyte* pKey, [NativeTypeName("unsigned int")] uint type, [NativeTypeName("unsigned int")] uint index, [NativeTypeName("struct aiColor4D *")] aiColor4D* pOut);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("enum aiReturn")]
    public static extern aiReturn aiGetMaterialUVTransform([NativeTypeName("const struct aiMaterial *")] aiMaterial* pMat, [NativeTypeName("const char *")] sbyte* pKey, [NativeTypeName("unsigned int")] uint type, [NativeTypeName("unsigned int")] uint index, [NativeTypeName("struct aiUVTransform *")] aiUVTransform* pOut);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("enum aiReturn")]
    public static extern aiReturn aiGetMaterialString([NativeTypeName("const struct aiMaterial *")] aiMaterial* pMat, [NativeTypeName("const char *")] sbyte* pKey, [NativeTypeName("unsigned int")] uint type, [NativeTypeName("unsigned int")] uint index, [NativeTypeName("struct aiString *")] aiString* pOut);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint aiGetMaterialTextureCount([NativeTypeName("const struct aiMaterial *")] aiMaterial* pMat, [NativeTypeName("enum aiTextureType")] aiTextureType type);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("enum aiReturn")]
    public static extern aiReturn aiGetMaterialTexture([NativeTypeName("const struct aiMaterial *")] aiMaterial* mat, [NativeTypeName("enum aiTextureType")] aiTextureType type, [NativeTypeName("unsigned int")] uint index, [NativeTypeName("struct aiString *")] aiString* path, [NativeTypeName("enum aiTextureMapping *")] aiTextureMapping* mapping, [NativeTypeName("unsigned int *")] uint* uvindex, [NativeTypeName("ai_real *")] float* blend, [NativeTypeName("enum aiTextureOp *")] aiTextureOp* op, [NativeTypeName("enum aiTextureMapMode *")] aiTextureMapMode* mapmode, [NativeTypeName("unsigned int *")] uint* flags);
}
