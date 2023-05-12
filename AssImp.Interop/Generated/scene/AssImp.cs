namespace AssImp.Interop;

public static partial class AssImp
{
    [NativeTypeName("#define AI_SCENE_FLAGS_INCOMPLETE 0x1")]
    public const int AI_SCENE_FLAGS_INCOMPLETE = 0x1;

    [NativeTypeName("#define AI_SCENE_FLAGS_VALIDATED 0x2")]
    public const int AI_SCENE_FLAGS_VALIDATED = 0x2;

    [NativeTypeName("#define AI_SCENE_FLAGS_VALIDATION_WARNING 0x4")]
    public const int AI_SCENE_FLAGS_VALIDATION_WARNING = 0x4;

    [NativeTypeName("#define AI_SCENE_FLAGS_NON_VERBOSE_FORMAT 0x8")]
    public const int AI_SCENE_FLAGS_NON_VERBOSE_FORMAT = 0x8;

    [NativeTypeName("#define AI_SCENE_FLAGS_TERRAIN 0x10")]
    public const int AI_SCENE_FLAGS_TERRAIN = 0x10;

    [NativeTypeName("#define AI_SCENE_FLAGS_ALLOW_SHARED 0x20")]
    public const int AI_SCENE_FLAGS_ALLOW_SHARED = 0x20;
}
