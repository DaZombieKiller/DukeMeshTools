namespace AssImp.Interop;

public enum aiShadingMode
{
    aiShadingMode_Flat = 0x1,
    aiShadingMode_Gouraud = 0x2,
    aiShadingMode_Phong = 0x3,
    aiShadingMode_Blinn = 0x4,
    aiShadingMode_Toon = 0x5,
    aiShadingMode_OrenNayar = 0x6,
    aiShadingMode_Minnaert = 0x7,
    aiShadingMode_CookTorrance = 0x8,
    aiShadingMode_NoShading = 0x9,
    aiShadingMode_Unlit = aiShadingMode_NoShading,
    aiShadingMode_Fresnel = 0xa,
    aiShadingMode_PBR_BRDF = 0xb,
    _aiShadingMode_Force32Bit = 2147483647,
}
