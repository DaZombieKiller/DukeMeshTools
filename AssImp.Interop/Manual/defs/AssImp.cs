namespace AssImp.Interop;

public static partial class AssImp
{
    [NativeTypeName("#define SIZE_MAX (~((size_t)0))")]
    public static nuint SIZE_MAX => nuint.MaxValue;

    [NativeTypeName("#define ASSIMP_AI_REAL_TEXT_PRECISION 9")]
    public const int ASSIMP_AI_REAL_TEXT_PRECISION = 9;

    [NativeTypeName("#define AI_MATH_PI (3.141592653589793238462643383279)")]
    public const double AI_MATH_PI = (3.141592653589793238462643383279);

    [NativeTypeName("#define AI_MATH_TWO_PI (AI_MATH_PI * 2.0)")]
    public const double AI_MATH_TWO_PI = ((3.141592653589793238462643383279) * 2.0);

    [NativeTypeName("#define AI_MATH_HALF_PI (AI_MATH_PI * 0.5)")]
    public const double AI_MATH_HALF_PI = ((3.141592653589793238462643383279) * 0.5);

    [NativeTypeName("#define AI_MATH_PI_F (3.1415926538f)")]
    public const float AI_MATH_PI_F = (3.1415926538f);

    [NativeTypeName("#define AI_MATH_TWO_PI_F (AI_MATH_PI_F * 2.0f)")]
    public const float AI_MATH_TWO_PI_F = ((3.1415926538f) * 2.0f);

    [NativeTypeName("#define AI_MATH_HALF_PI_F (AI_MATH_PI_F * 0.5f)")]
    public const float AI_MATH_HALF_PI_F = ((3.1415926538f) * 0.5f);
}
