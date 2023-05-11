using System.Runtime.InteropServices;

namespace AssImp.Interop;

public static unsafe partial class AssImp
{
    [NativeTypeName("#define AI_FALSE 0")]
    public const int AI_FALSE = 0;

    [NativeTypeName("#define AI_TRUE 1")]
    public const int AI_TRUE = 1;
}
