using System;

namespace AssImp.Interop;

public static partial class AssImp
{
    [NativeTypeName("#define AI_EMBEDDED_TEXNAME_PREFIX \"*\"")]
    public static ReadOnlySpan<byte> AI_EMBEDDED_TEXNAME_PREFIX => "*"u8;

    [NativeTypeName("#define HINTMAXTEXTURELEN 9")]
    public const int HINTMAXTEXTURELEN = 9;
}
