using System;
using System.Runtime.InteropServices;
using static AssImp.Interop.aiTextureType;

namespace AssImp.Interop;

public static unsafe partial class AssImp
{
    [NativeTypeName("#define AI_DEFAULT_MATERIAL_NAME \"DefaultMaterial\"")]
    public static ReadOnlySpan<byte> AI_DEFAULT_MATERIAL_NAME => "DefaultMaterial"u8;

    [NativeTypeName("#define AI_TEXTURE_TYPE_MAX aiTextureType_TRANSMISSION")]
    public const aiTextureType AI_TEXTURE_TYPE_MAX = aiTextureType_TRANSMISSION;

    [NativeTypeName("#define AI_MATKEY_NAME \"?mat.name\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_NAME => "?mat.name"u8;

    [NativeTypeName("#define AI_MATKEY_TWOSIDED \"$mat.twosided\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_TWOSIDED => "$mat.twosided"u8;

    [NativeTypeName("#define AI_MATKEY_SHADING_MODEL \"$mat.shadingm\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_SHADING_MODEL => "$mat.shadingm"u8;

    [NativeTypeName("#define AI_MATKEY_ENABLE_WIREFRAME \"$mat.wireframe\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_ENABLE_WIREFRAME => "$mat.wireframe"u8;

    [NativeTypeName("#define AI_MATKEY_BLEND_FUNC \"$mat.blend\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_BLEND_FUNC => "$mat.blend"u8;

    [NativeTypeName("#define AI_MATKEY_OPACITY \"$mat.opacity\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_OPACITY => "$mat.opacity"u8;

    [NativeTypeName("#define AI_MATKEY_TRANSPARENCYFACTOR \"$mat.transparencyfactor\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_TRANSPARENCYFACTOR => "$mat.transparencyfactor"u8;

    [NativeTypeName("#define AI_MATKEY_BUMPSCALING \"$mat.bumpscaling\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_BUMPSCALING => "$mat.bumpscaling"u8;

    [NativeTypeName("#define AI_MATKEY_SHININESS \"$mat.shininess\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_SHININESS => "$mat.shininess"u8;

    [NativeTypeName("#define AI_MATKEY_REFLECTIVITY \"$mat.reflectivity\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_REFLECTIVITY => "$mat.reflectivity"u8;

    [NativeTypeName("#define AI_MATKEY_SHININESS_STRENGTH \"$mat.shinpercent\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_SHININESS_STRENGTH => "$mat.shinpercent"u8;

    [NativeTypeName("#define AI_MATKEY_REFRACTI \"$mat.refracti\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_REFRACTI => "$mat.refracti"u8;

    [NativeTypeName("#define AI_MATKEY_COLOR_DIFFUSE \"$clr.diffuse\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_COLOR_DIFFUSE => "$clr.diffuse"u8;

    [NativeTypeName("#define AI_MATKEY_COLOR_AMBIENT \"$clr.ambient\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_COLOR_AMBIENT => "$clr.ambient"u8;

    [NativeTypeName("#define AI_MATKEY_COLOR_SPECULAR \"$clr.specular\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_COLOR_SPECULAR => "$clr.specular"u8;

    [NativeTypeName("#define AI_MATKEY_COLOR_EMISSIVE \"$clr.emissive\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_COLOR_EMISSIVE => "$clr.emissive"u8;

    [NativeTypeName("#define AI_MATKEY_COLOR_TRANSPARENT \"$clr.transparent\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_COLOR_TRANSPARENT => "$clr.transparent"u8;

    [NativeTypeName("#define AI_MATKEY_COLOR_REFLECTIVE \"$clr.reflective\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_COLOR_REFLECTIVE => "$clr.reflective"u8;

    [NativeTypeName("#define AI_MATKEY_GLOBAL_BACKGROUND_IMAGE \"?bg.global\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_GLOBAL_BACKGROUND_IMAGE => "?bg.global"u8;

    [NativeTypeName("#define AI_MATKEY_GLOBAL_SHADERLANG \"?sh.lang\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_GLOBAL_SHADERLANG => "?sh.lang"u8;

    [NativeTypeName("#define AI_MATKEY_SHADER_VERTEX \"?sh.vs\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_SHADER_VERTEX => "?sh.vs"u8;

    [NativeTypeName("#define AI_MATKEY_SHADER_FRAGMENT \"?sh.fs\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_SHADER_FRAGMENT => "?sh.fs"u8;

    [NativeTypeName("#define AI_MATKEY_SHADER_GEO \"?sh.gs\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_SHADER_GEO => "?sh.gs"u8;

    [NativeTypeName("#define AI_MATKEY_SHADER_TESSELATION \"?sh.ts\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_SHADER_TESSELATION => "?sh.ts"u8;

    [NativeTypeName("#define AI_MATKEY_SHADER_PRIMITIVE \"?sh.ps\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_SHADER_PRIMITIVE => "?sh.ps"u8;

    [NativeTypeName("#define AI_MATKEY_SHADER_COMPUTE \"?sh.cs\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_SHADER_COMPUTE => "?sh.cs"u8;

    [NativeTypeName("#define AI_MATKEY_USE_COLOR_MAP \"$mat.useColorMap\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_USE_COLOR_MAP => "$mat.useColorMap"u8;

    [NativeTypeName("#define AI_MATKEY_BASE_COLOR \"$clr.base\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_BASE_COLOR => "$clr.base"u8;

    [NativeTypeName("#define AI_MATKEY_BASE_COLOR_TEXTURE aiTextureType_BASE_COLOR")]
    public const aiTextureType AI_MATKEY_BASE_COLOR_TEXTURE = aiTextureType_BASE_COLOR;

    [NativeTypeName("#define AI_MATKEY_USE_METALLIC_MAP \"$mat.useMetallicMap\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_USE_METALLIC_MAP => "$mat.useMetallicMap"u8;

    [NativeTypeName("#define AI_MATKEY_METALLIC_FACTOR \"$mat.metallicFactor\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_METALLIC_FACTOR => "$mat.metallicFactor"u8;

    [NativeTypeName("#define AI_MATKEY_METALLIC_TEXTURE aiTextureType_METALNESS")]
    public const aiTextureType AI_MATKEY_METALLIC_TEXTURE = aiTextureType_METALNESS;

    [NativeTypeName("#define AI_MATKEY_USE_ROUGHNESS_MAP \"$mat.useRoughnessMap\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_USE_ROUGHNESS_MAP => "$mat.useRoughnessMap"u8;

    [NativeTypeName("#define AI_MATKEY_ROUGHNESS_FACTOR \"$mat.roughnessFactor\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_ROUGHNESS_FACTOR => "$mat.roughnessFactor"u8;

    [NativeTypeName("#define AI_MATKEY_ROUGHNESS_TEXTURE aiTextureType_DIFFUSE_ROUGHNESS")]
    public const aiTextureType AI_MATKEY_ROUGHNESS_TEXTURE = aiTextureType_DIFFUSE_ROUGHNESS;

    [NativeTypeName("#define AI_MATKEY_ANISOTROPY_FACTOR \"$mat.anisotropyFactor\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_ANISOTROPY_FACTOR => "$mat.anisotropyFactor"u8;

    [NativeTypeName("#define AI_MATKEY_SPECULAR_FACTOR \"$mat.specularFactor\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_SPECULAR_FACTOR => "$mat.specularFactor"u8;

    [NativeTypeName("#define AI_MATKEY_GLOSSINESS_FACTOR \"$mat.glossinessFactor\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_GLOSSINESS_FACTOR => "$mat.glossinessFactor"u8;

    [NativeTypeName("#define AI_MATKEY_SHEEN_COLOR_FACTOR \"$clr.sheen.factor\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_SHEEN_COLOR_FACTOR => "$clr.sheen.factor"u8;

    [NativeTypeName("#define AI_MATKEY_SHEEN_ROUGHNESS_FACTOR \"$mat.sheen.roughnessFactor\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_SHEEN_ROUGHNESS_FACTOR => "$mat.sheen.roughnessFactor"u8;

    [NativeTypeName("#define AI_MATKEY_SHEEN_COLOR_TEXTURE aiTextureType_SHEEN")]
    public const aiTextureType AI_MATKEY_SHEEN_COLOR_TEXTURE = aiTextureType_SHEEN;

    [NativeTypeName("#define AI_MATKEY_SHEEN_ROUGHNESS_TEXTURE aiTextureType_SHEEN")]
    public const aiTextureType AI_MATKEY_SHEEN_ROUGHNESS_TEXTURE = aiTextureType_SHEEN;

    [NativeTypeName("#define AI_MATKEY_CLEARCOAT_FACTOR \"$mat.clearcoat.factor\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_CLEARCOAT_FACTOR => "$mat.clearcoat.factor"u8;

    [NativeTypeName("#define AI_MATKEY_CLEARCOAT_ROUGHNESS_FACTOR \"$mat.clearcoat.roughnessFactor\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_CLEARCOAT_ROUGHNESS_FACTOR => "$mat.clearcoat.roughnessFactor"u8;

    [NativeTypeName("#define AI_MATKEY_CLEARCOAT_TEXTURE aiTextureType_CLEARCOAT")]
    public const aiTextureType AI_MATKEY_CLEARCOAT_TEXTURE = aiTextureType_CLEARCOAT;

    [NativeTypeName("#define AI_MATKEY_CLEARCOAT_ROUGHNESS_TEXTURE aiTextureType_CLEARCOAT")]
    public const aiTextureType AI_MATKEY_CLEARCOAT_ROUGHNESS_TEXTURE = aiTextureType_CLEARCOAT;

    [NativeTypeName("#define AI_MATKEY_CLEARCOAT_NORMAL_TEXTURE aiTextureType_CLEARCOAT")]
    public const aiTextureType AI_MATKEY_CLEARCOAT_NORMAL_TEXTURE = aiTextureType_CLEARCOAT;

    [NativeTypeName("#define AI_MATKEY_TRANSMISSION_FACTOR \"$mat.transmission.factor\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_TRANSMISSION_FACTOR => "$mat.transmission.factor"u8;

    [NativeTypeName("#define AI_MATKEY_TRANSMISSION_TEXTURE aiTextureType_TRANSMISSION")]
    public const aiTextureType AI_MATKEY_TRANSMISSION_TEXTURE = aiTextureType_TRANSMISSION;

    [NativeTypeName("#define AI_MATKEY_VOLUME_THICKNESS_FACTOR \"$mat.volume.thicknessFactor\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_VOLUME_THICKNESS_FACTOR => "$mat.volume.thicknessFactor"u8;

    [NativeTypeName("#define AI_MATKEY_VOLUME_THICKNESS_TEXTURE aiTextureType_TRANSMISSION")]
    public const aiTextureType AI_MATKEY_VOLUME_THICKNESS_TEXTURE = aiTextureType_TRANSMISSION;

    [NativeTypeName("#define AI_MATKEY_VOLUME_ATTENUATION_DISTANCE \"$mat.volume.attenuationDistance\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_VOLUME_ATTENUATION_DISTANCE => "$mat.volume.attenuationDistance"u8;

    [NativeTypeName("#define AI_MATKEY_VOLUME_ATTENUATION_COLOR \"$mat.volume.attenuationColor\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_VOLUME_ATTENUATION_COLOR => "$mat.volume.attenuationColor"u8;

    [NativeTypeName("#define AI_MATKEY_USE_EMISSIVE_MAP \"$mat.useEmissiveMap\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_USE_EMISSIVE_MAP => "$mat.useEmissiveMap"u8;

    [NativeTypeName("#define AI_MATKEY_EMISSIVE_INTENSITY \"$mat.emissiveIntensity\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_EMISSIVE_INTENSITY => "$mat.emissiveIntensity"u8;

    [NativeTypeName("#define AI_MATKEY_USE_AO_MAP \"$mat.useAOMap\"")]
    public static ReadOnlySpan<byte> AI_MATKEY_USE_AO_MAP => "$mat.useAOMap"u8;

    [NativeTypeName("#define _AI_MATKEY_TEXTURE_BASE \"$tex.file\"")]
    public static ReadOnlySpan<byte> _AI_MATKEY_TEXTURE_BASE => "$tex.file"u8;

    [NativeTypeName("#define _AI_MATKEY_UVWSRC_BASE \"$tex.uvwsrc\"")]
    public static ReadOnlySpan<byte> _AI_MATKEY_UVWSRC_BASE => "$tex.uvwsrc"u8;

    [NativeTypeName("#define _AI_MATKEY_TEXOP_BASE \"$tex.op\"")]
    public static ReadOnlySpan<byte> _AI_MATKEY_TEXOP_BASE => "$tex.op"u8;

    [NativeTypeName("#define _AI_MATKEY_MAPPING_BASE \"$tex.mapping\"")]
    public static ReadOnlySpan<byte> _AI_MATKEY_MAPPING_BASE => "$tex.mapping"u8;

    [NativeTypeName("#define _AI_MATKEY_TEXBLEND_BASE \"$tex.blend\"")]
    public static ReadOnlySpan<byte> _AI_MATKEY_TEXBLEND_BASE => "$tex.blend"u8;

    [NativeTypeName("#define _AI_MATKEY_MAPPINGMODE_U_BASE \"$tex.mapmodeu\"")]
    public static ReadOnlySpan<byte> _AI_MATKEY_MAPPINGMODE_U_BASE => "$tex.mapmodeu"u8;

    [NativeTypeName("#define _AI_MATKEY_MAPPINGMODE_V_BASE \"$tex.mapmodev\"")]
    public static ReadOnlySpan<byte> _AI_MATKEY_MAPPINGMODE_V_BASE => "$tex.mapmodev"u8;

    [NativeTypeName("#define _AI_MATKEY_TEXMAP_AXIS_BASE \"$tex.mapaxis\"")]
    public static ReadOnlySpan<byte> _AI_MATKEY_TEXMAP_AXIS_BASE => "$tex.mapaxis"u8;

    [NativeTypeName("#define _AI_MATKEY_UVTRANSFORM_BASE \"$tex.uvtrafo\"")]
    public static ReadOnlySpan<byte> _AI_MATKEY_UVTRANSFORM_BASE => "$tex.uvtrafo"u8;

    [NativeTypeName("#define _AI_MATKEY_TEXFLAGS_BASE \"$tex.flags\"")]
    public static ReadOnlySpan<byte> _AI_MATKEY_TEXFLAGS_BASE => "$tex.flags"u8;
}
