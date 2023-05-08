using System.Runtime.InteropServices;

namespace AssImp.Interop;

public static unsafe partial class AssImp
{
    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const struct aiScene *")]
    public static extern aiScene* aiImportFile([NativeTypeName("const char *")] sbyte* pFile, [NativeTypeName("unsigned int")] uint pFlags);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const struct aiScene *")]
    public static extern aiScene* aiImportFileEx([NativeTypeName("const char *")] sbyte* pFile, [NativeTypeName("unsigned int")] uint pFlags, [NativeTypeName("struct aiFileIO *")] aiFileIO* pFS);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const struct aiScene *")]
    public static extern aiScene* aiImportFileExWithProperties([NativeTypeName("const char *")] sbyte* pFile, [NativeTypeName("unsigned int")] uint pFlags, [NativeTypeName("struct aiFileIO *")] aiFileIO* pFS, [NativeTypeName("const struct aiPropertyStore *")] aiPropertyStore* pProps);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const struct aiScene *")]
    public static extern aiScene* aiImportFileFromMemory([NativeTypeName("const char *")] sbyte* pBuffer, [NativeTypeName("unsigned int")] uint pLength, [NativeTypeName("unsigned int")] uint pFlags, [NativeTypeName("const char *")] sbyte* pHint);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const struct aiScene *")]
    public static extern aiScene* aiImportFileFromMemoryWithProperties([NativeTypeName("const char *")] sbyte* pBuffer, [NativeTypeName("unsigned int")] uint pLength, [NativeTypeName("unsigned int")] uint pFlags, [NativeTypeName("const char *")] sbyte* pHint, [NativeTypeName("const struct aiPropertyStore *")] aiPropertyStore* pProps);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const struct aiScene *")]
    public static extern aiScene* aiApplyPostProcessing([NativeTypeName("const struct aiScene *")] aiScene* pScene, [NativeTypeName("unsigned int")] uint pFlags);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("struct aiLogStream")]
    public static extern aiLogStream aiGetPredefinedLogStream([NativeTypeName("enum aiDefaultLogStream")] aiDefaultLogStream pStreams, [NativeTypeName("const char *")] sbyte* file);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiAttachLogStream([NativeTypeName("const struct aiLogStream *")] aiLogStream* stream);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiEnableVerboseLogging([NativeTypeName("aiBool")] int d);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("enum aiReturn")]
    public static extern aiReturn aiDetachLogStream([NativeTypeName("const struct aiLogStream *")] aiLogStream* stream);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiDetachAllLogStreams();

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiReleaseImport([NativeTypeName("const struct aiScene *")] aiScene* pScene);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* aiGetErrorString();

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("aiBool")]
    public static extern int aiIsExtensionSupported([NativeTypeName("const char *")] sbyte* szExtension);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiGetExtensionList([NativeTypeName("struct aiString *")] aiString* szOut);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiGetMemoryRequirements([NativeTypeName("const struct aiScene *")] aiScene* pIn, [NativeTypeName("struct aiMemoryInfo *")] aiMemoryInfo* @in);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("struct aiPropertyStore *")]
    public static extern aiPropertyStore* aiCreatePropertyStore();

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiReleasePropertyStore([NativeTypeName("struct aiPropertyStore *")] aiPropertyStore* p);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiSetImportPropertyInteger([NativeTypeName("struct aiPropertyStore *")] aiPropertyStore* store, [NativeTypeName("const char *")] sbyte* szName, int value);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiSetImportPropertyFloat([NativeTypeName("struct aiPropertyStore *")] aiPropertyStore* store, [NativeTypeName("const char *")] sbyte* szName, [NativeTypeName("ai_real")] float value);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiSetImportPropertyString([NativeTypeName("struct aiPropertyStore *")] aiPropertyStore* store, [NativeTypeName("const char *")] sbyte* szName, [NativeTypeName("const struct aiString *")] aiString* st);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiSetImportPropertyMatrix([NativeTypeName("struct aiPropertyStore *")] aiPropertyStore* store, [NativeTypeName("const char *")] sbyte* szName, [NativeTypeName("const struct aiMatrix4x4 *")] aiMatrix4x4* mat);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiCreateQuaternionFromMatrix([NativeTypeName("struct aiQuaternion *")] aiQuaternion* quat, [NativeTypeName("const struct aiMatrix3x3 *")] aiMatrix3x3* mat);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiDecomposeMatrix([NativeTypeName("const struct aiMatrix4x4 *")] aiMatrix4x4* mat, [NativeTypeName("struct aiVector3D *")] aiVector3D* scaling, [NativeTypeName("struct aiQuaternion *")] aiQuaternion* rotation, [NativeTypeName("struct aiVector3D *")] aiVector3D* position);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiTransposeMatrix4([NativeTypeName("struct aiMatrix4x4 *")] aiMatrix4x4* mat);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiTransposeMatrix3([NativeTypeName("struct aiMatrix3x3 *")] aiMatrix3x3* mat);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiTransformVecByMatrix3([NativeTypeName("struct aiVector3D *")] aiVector3D* vec, [NativeTypeName("const struct aiMatrix3x3 *")] aiMatrix3x3* mat);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiTransformVecByMatrix4([NativeTypeName("struct aiVector3D *")] aiVector3D* vec, [NativeTypeName("const struct aiMatrix4x4 *")] aiMatrix4x4* mat);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMultiplyMatrix4([NativeTypeName("struct aiMatrix4x4 *")] aiMatrix4x4* dst, [NativeTypeName("const struct aiMatrix4x4 *")] aiMatrix4x4* src);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMultiplyMatrix3([NativeTypeName("struct aiMatrix3x3 *")] aiMatrix3x3* dst, [NativeTypeName("const struct aiMatrix3x3 *")] aiMatrix3x3* src);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiIdentityMatrix3([NativeTypeName("struct aiMatrix3x3 *")] aiMatrix3x3* mat);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiIdentityMatrix4([NativeTypeName("struct aiMatrix4x4 *")] aiMatrix4x4* mat);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint aiGetImportFormatCount();

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const struct aiImporterDesc *")]
    public static extern aiImporterDesc* aiGetImportFormatDescription([NativeTypeName("size_t")] nuint pIndex);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int aiVector2AreEqual([NativeTypeName("const struct aiVector2D *")] aiVector2D* a, [NativeTypeName("const struct aiVector2D *")] aiVector2D* b);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int aiVector2AreEqualEpsilon([NativeTypeName("const struct aiVector2D *")] aiVector2D* a, [NativeTypeName("const struct aiVector2D *")] aiVector2D* b, [NativeTypeName("const float")] float epsilon);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector2Add([NativeTypeName("struct aiVector2D *")] aiVector2D* dst, [NativeTypeName("const struct aiVector2D *")] aiVector2D* src);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector2Subtract([NativeTypeName("struct aiVector2D *")] aiVector2D* dst, [NativeTypeName("const struct aiVector2D *")] aiVector2D* src);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector2Scale([NativeTypeName("struct aiVector2D *")] aiVector2D* dst, [NativeTypeName("const float")] float s);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector2SymMul([NativeTypeName("struct aiVector2D *")] aiVector2D* dst, [NativeTypeName("const struct aiVector2D *")] aiVector2D* other);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector2DivideByScalar([NativeTypeName("struct aiVector2D *")] aiVector2D* dst, [NativeTypeName("const float")] float s);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector2DivideByVector([NativeTypeName("struct aiVector2D *")] aiVector2D* dst, [NativeTypeName("struct aiVector2D *")] aiVector2D* v);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float aiVector2Length([NativeTypeName("const struct aiVector2D *")] aiVector2D* v);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float aiVector2SquareLength([NativeTypeName("const struct aiVector2D *")] aiVector2D* v);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector2Negate([NativeTypeName("struct aiVector2D *")] aiVector2D* dst);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float aiVector2DotProduct([NativeTypeName("const struct aiVector2D *")] aiVector2D* a, [NativeTypeName("const struct aiVector2D *")] aiVector2D* b);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector2Normalize([NativeTypeName("struct aiVector2D *")] aiVector2D* v);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int aiVector3AreEqual([NativeTypeName("const struct aiVector3D *")] aiVector3D* a, [NativeTypeName("const struct aiVector3D *")] aiVector3D* b);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int aiVector3AreEqualEpsilon([NativeTypeName("const struct aiVector3D *")] aiVector3D* a, [NativeTypeName("const struct aiVector3D *")] aiVector3D* b, [NativeTypeName("const float")] float epsilon);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int aiVector3LessThan([NativeTypeName("const struct aiVector3D *")] aiVector3D* a, [NativeTypeName("const struct aiVector3D *")] aiVector3D* b);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector3Add([NativeTypeName("struct aiVector3D *")] aiVector3D* dst, [NativeTypeName("const struct aiVector3D *")] aiVector3D* src);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector3Subtract([NativeTypeName("struct aiVector3D *")] aiVector3D* dst, [NativeTypeName("const struct aiVector3D *")] aiVector3D* src);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector3Scale([NativeTypeName("struct aiVector3D *")] aiVector3D* dst, [NativeTypeName("const float")] float s);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector3SymMul([NativeTypeName("struct aiVector3D *")] aiVector3D* dst, [NativeTypeName("const struct aiVector3D *")] aiVector3D* other);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector3DivideByScalar([NativeTypeName("struct aiVector3D *")] aiVector3D* dst, [NativeTypeName("const float")] float s);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector3DivideByVector([NativeTypeName("struct aiVector3D *")] aiVector3D* dst, [NativeTypeName("struct aiVector3D *")] aiVector3D* v);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float aiVector3Length([NativeTypeName("const struct aiVector3D *")] aiVector3D* v);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float aiVector3SquareLength([NativeTypeName("const struct aiVector3D *")] aiVector3D* v);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector3Negate([NativeTypeName("struct aiVector3D *")] aiVector3D* dst);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float aiVector3DotProduct([NativeTypeName("const struct aiVector3D *")] aiVector3D* a, [NativeTypeName("const struct aiVector3D *")] aiVector3D* b);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector3CrossProduct([NativeTypeName("struct aiVector3D *")] aiVector3D* dst, [NativeTypeName("const struct aiVector3D *")] aiVector3D* a, [NativeTypeName("const struct aiVector3D *")] aiVector3D* b);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector3Normalize([NativeTypeName("struct aiVector3D *")] aiVector3D* v);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector3NormalizeSafe([NativeTypeName("struct aiVector3D *")] aiVector3D* v);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiVector3RotateByQuaternion([NativeTypeName("struct aiVector3D *")] aiVector3D* v, [NativeTypeName("const struct aiQuaternion *")] aiQuaternion* q);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix3FromMatrix4([NativeTypeName("struct aiMatrix3x3 *")] aiMatrix3x3* dst, [NativeTypeName("const struct aiMatrix4x4 *")] aiMatrix4x4* mat);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix3FromQuaternion([NativeTypeName("struct aiMatrix3x3 *")] aiMatrix3x3* mat, [NativeTypeName("const struct aiQuaternion *")] aiQuaternion* q);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int aiMatrix3AreEqual([NativeTypeName("const struct aiMatrix3x3 *")] aiMatrix3x3* a, [NativeTypeName("const struct aiMatrix3x3 *")] aiMatrix3x3* b);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int aiMatrix3AreEqualEpsilon([NativeTypeName("const struct aiMatrix3x3 *")] aiMatrix3x3* a, [NativeTypeName("const struct aiMatrix3x3 *")] aiMatrix3x3* b, [NativeTypeName("const float")] float epsilon);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix3Inverse([NativeTypeName("struct aiMatrix3x3 *")] aiMatrix3x3* mat);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float aiMatrix3Determinant([NativeTypeName("const struct aiMatrix3x3 *")] aiMatrix3x3* mat);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix3RotationZ([NativeTypeName("struct aiMatrix3x3 *")] aiMatrix3x3* mat, [NativeTypeName("const float")] float angle);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix3FromRotationAroundAxis([NativeTypeName("struct aiMatrix3x3 *")] aiMatrix3x3* mat, [NativeTypeName("const struct aiVector3D *")] aiVector3D* axis, [NativeTypeName("const float")] float angle);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix3Translation([NativeTypeName("struct aiMatrix3x3 *")] aiMatrix3x3* mat, [NativeTypeName("const struct aiVector2D *")] aiVector2D* translation);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix3FromTo([NativeTypeName("struct aiMatrix3x3 *")] aiMatrix3x3* mat, [NativeTypeName("const struct aiVector3D *")] aiVector3D* from, [NativeTypeName("const struct aiVector3D *")] aiVector3D* to);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix4FromMatrix3([NativeTypeName("struct aiMatrix4x4 *")] aiMatrix4x4* dst, [NativeTypeName("const struct aiMatrix3x3 *")] aiMatrix3x3* mat);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix4FromScalingQuaternionPosition([NativeTypeName("struct aiMatrix4x4 *")] aiMatrix4x4* mat, [NativeTypeName("const struct aiVector3D *")] aiVector3D* scaling, [NativeTypeName("const struct aiQuaternion *")] aiQuaternion* rotation, [NativeTypeName("const struct aiVector3D *")] aiVector3D* position);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix4Add([NativeTypeName("struct aiMatrix4x4 *")] aiMatrix4x4* dst, [NativeTypeName("const struct aiMatrix4x4 *")] aiMatrix4x4* src);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int aiMatrix4AreEqual([NativeTypeName("const struct aiMatrix4x4 *")] aiMatrix4x4* a, [NativeTypeName("const struct aiMatrix4x4 *")] aiMatrix4x4* b);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int aiMatrix4AreEqualEpsilon([NativeTypeName("const struct aiMatrix4x4 *")] aiMatrix4x4* a, [NativeTypeName("const struct aiMatrix4x4 *")] aiMatrix4x4* b, [NativeTypeName("const float")] float epsilon);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix4Inverse([NativeTypeName("struct aiMatrix4x4 *")] aiMatrix4x4* mat);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float aiMatrix4Determinant([NativeTypeName("const struct aiMatrix4x4 *")] aiMatrix4x4* mat);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int aiMatrix4IsIdentity([NativeTypeName("const struct aiMatrix4x4 *")] aiMatrix4x4* mat);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix4DecomposeIntoScalingEulerAnglesPosition([NativeTypeName("const struct aiMatrix4x4 *")] aiMatrix4x4* mat, [NativeTypeName("struct aiVector3D *")] aiVector3D* scaling, [NativeTypeName("struct aiVector3D *")] aiVector3D* rotation, [NativeTypeName("struct aiVector3D *")] aiVector3D* position);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix4DecomposeIntoScalingAxisAnglePosition([NativeTypeName("const struct aiMatrix4x4 *")] aiMatrix4x4* mat, [NativeTypeName("struct aiVector3D *")] aiVector3D* scaling, [NativeTypeName("struct aiVector3D *")] aiVector3D* axis, [NativeTypeName("ai_real *")] float* angle, [NativeTypeName("struct aiVector3D *")] aiVector3D* position);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix4DecomposeNoScaling([NativeTypeName("const struct aiMatrix4x4 *")] aiMatrix4x4* mat, [NativeTypeName("struct aiQuaternion *")] aiQuaternion* rotation, [NativeTypeName("struct aiVector3D *")] aiVector3D* position);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix4FromEulerAngles([NativeTypeName("struct aiMatrix4x4 *")] aiMatrix4x4* mat, float x, float y, float z);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix4RotationX([NativeTypeName("struct aiMatrix4x4 *")] aiMatrix4x4* mat, [NativeTypeName("const float")] float angle);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix4RotationY([NativeTypeName("struct aiMatrix4x4 *")] aiMatrix4x4* mat, [NativeTypeName("const float")] float angle);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix4RotationZ([NativeTypeName("struct aiMatrix4x4 *")] aiMatrix4x4* mat, [NativeTypeName("const float")] float angle);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix4FromRotationAroundAxis([NativeTypeName("struct aiMatrix4x4 *")] aiMatrix4x4* mat, [NativeTypeName("const struct aiVector3D *")] aiVector3D* axis, [NativeTypeName("const float")] float angle);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix4Translation([NativeTypeName("struct aiMatrix4x4 *")] aiMatrix4x4* mat, [NativeTypeName("const struct aiVector3D *")] aiVector3D* translation);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix4Scaling([NativeTypeName("struct aiMatrix4x4 *")] aiMatrix4x4* mat, [NativeTypeName("const struct aiVector3D *")] aiVector3D* scaling);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiMatrix4FromTo([NativeTypeName("struct aiMatrix4x4 *")] aiMatrix4x4* mat, [NativeTypeName("const struct aiVector3D *")] aiVector3D* from, [NativeTypeName("const struct aiVector3D *")] aiVector3D* to);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiQuaternionFromEulerAngles([NativeTypeName("struct aiQuaternion *")] aiQuaternion* q, float x, float y, float z);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiQuaternionFromAxisAngle([NativeTypeName("struct aiQuaternion *")] aiQuaternion* q, [NativeTypeName("const struct aiVector3D *")] aiVector3D* axis, [NativeTypeName("const float")] float angle);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiQuaternionFromNormalizedQuaternion([NativeTypeName("struct aiQuaternion *")] aiQuaternion* q, [NativeTypeName("const struct aiVector3D *")] aiVector3D* normalized);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int aiQuaternionAreEqual([NativeTypeName("const struct aiQuaternion *")] aiQuaternion* a, [NativeTypeName("const struct aiQuaternion *")] aiQuaternion* b);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int aiQuaternionAreEqualEpsilon([NativeTypeName("const struct aiQuaternion *")] aiQuaternion* a, [NativeTypeName("const struct aiQuaternion *")] aiQuaternion* b, [NativeTypeName("const float")] float epsilon);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiQuaternionNormalize([NativeTypeName("struct aiQuaternion *")] aiQuaternion* q);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiQuaternionConjugate([NativeTypeName("struct aiQuaternion *")] aiQuaternion* q);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiQuaternionMultiply([NativeTypeName("struct aiQuaternion *")] aiQuaternion* dst, [NativeTypeName("const struct aiQuaternion *")] aiQuaternion* q);

    [DllImport("assimp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void aiQuaternionInterpolate([NativeTypeName("struct aiQuaternion *")] aiQuaternion* dst, [NativeTypeName("const struct aiQuaternion *")] aiQuaternion* start, [NativeTypeName("const struct aiQuaternion *")] aiQuaternion* end, [NativeTypeName("const float")] float factor);
}
