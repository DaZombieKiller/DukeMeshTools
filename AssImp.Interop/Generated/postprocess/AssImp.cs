using static AssImp.Interop.aiPostProcessSteps;

namespace AssImp.Interop;

public static partial class AssImp
{
    [NativeTypeName("#define aiProcess_ConvertToLeftHanded ( \\\n    aiProcess_MakeLeftHanded     | \\\n    aiProcess_FlipUVs            | \\\n    aiProcess_FlipWindingOrder   | \\\n    0 )")]
    public const aiPostProcessSteps aiProcess_ConvertToLeftHanded = (aiProcess_MakeLeftHanded | aiProcess_FlipUVs | aiProcess_FlipWindingOrder | 0);

    [NativeTypeName("#define aiProcessPreset_TargetRealtime_Fast ( \\\n    aiProcess_CalcTangentSpace      |  \\\n    aiProcess_GenNormals            |  \\\n    aiProcess_JoinIdenticalVertices |  \\\n    aiProcess_Triangulate           |  \\\n    aiProcess_GenUVCoords           |  \\\n    aiProcess_SortByPType           |  \\\n    0 )")]
    public const aiPostProcessSteps aiProcessPreset_TargetRealtime_Fast = (aiProcess_CalcTangentSpace | aiProcess_GenNormals | aiProcess_JoinIdenticalVertices | aiProcess_Triangulate | aiProcess_GenUVCoords | aiProcess_SortByPType | 0);

    [NativeTypeName("#define aiProcessPreset_TargetRealtime_Quality ( \\\n    aiProcess_CalcTangentSpace              |  \\\n    aiProcess_GenSmoothNormals              |  \\\n    aiProcess_JoinIdenticalVertices         |  \\\n    aiProcess_ImproveCacheLocality          |  \\\n    aiProcess_LimitBoneWeights              |  \\\n    aiProcess_RemoveRedundantMaterials      |  \\\n    aiProcess_SplitLargeMeshes              |  \\\n    aiProcess_Triangulate                   |  \\\n    aiProcess_GenUVCoords                   |  \\\n    aiProcess_SortByPType                   |  \\\n    aiProcess_FindDegenerates               |  \\\n    aiProcess_FindInvalidData               |  \\\n    0 )")]
    public const aiPostProcessSteps aiProcessPreset_TargetRealtime_Quality = (aiProcess_CalcTangentSpace | aiProcess_GenSmoothNormals | aiProcess_JoinIdenticalVertices | aiProcess_ImproveCacheLocality | aiProcess_LimitBoneWeights | aiProcess_RemoveRedundantMaterials | aiProcess_SplitLargeMeshes | aiProcess_Triangulate | aiProcess_GenUVCoords | aiProcess_SortByPType | aiProcess_FindDegenerates | aiProcess_FindInvalidData | 0);

    [NativeTypeName("#define aiProcessPreset_TargetRealtime_MaxQuality ( \\\n    aiProcessPreset_TargetRealtime_Quality   |  \\\n    aiProcess_FindInstances                  |  \\\n    aiProcess_ValidateDataStructure          |  \\\n    aiProcess_OptimizeMeshes                 |  \\\n    0 )")]
    public const aiPostProcessSteps aiProcessPreset_TargetRealtime_MaxQuality = ((aiProcess_CalcTangentSpace | aiProcess_GenSmoothNormals | aiProcess_JoinIdenticalVertices | aiProcess_ImproveCacheLocality | aiProcess_LimitBoneWeights | aiProcess_RemoveRedundantMaterials | aiProcess_SplitLargeMeshes | aiProcess_Triangulate | aiProcess_GenUVCoords | aiProcess_SortByPType | aiProcess_FindDegenerates | aiProcess_FindInvalidData | 0) | aiProcess_FindInstances | aiProcess_ValidateDataStructure | aiProcess_OptimizeMeshes | 0);
}
