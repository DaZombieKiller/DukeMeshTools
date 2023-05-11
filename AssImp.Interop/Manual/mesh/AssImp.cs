namespace AssImp.Interop;

public static partial class AssImp
{
    [NativeTypeName("#define AI_MAX_FACE_INDICES 0x7fff")]
    public const int AI_MAX_FACE_INDICES = 0x7fff;

    [NativeTypeName("#define AI_MAX_BONE_WEIGHTS 0x7fffffff")]
    public const int AI_MAX_BONE_WEIGHTS = 0x7fffffff;

    [NativeTypeName("#define AI_MAX_VERTICES 0x7fffffff")]
    public const int AI_MAX_VERTICES = 0x7fffffff;

    [NativeTypeName("#define AI_MAX_FACES 0x7fffffff")]
    public const int AI_MAX_FACES = 0x7fffffff;

    [NativeTypeName("#define AI_MAX_NUMBER_OF_COLOR_SETS 0x8")]
    public const int AI_MAX_NUMBER_OF_COLOR_SETS = 0x8;

    [NativeTypeName("#define AI_MAX_NUMBER_OF_TEXTURECOORDS 0x8")]
    public const int AI_MAX_NUMBER_OF_TEXTURECOORDS = 0x8;
}
