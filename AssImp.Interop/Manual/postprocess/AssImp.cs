using static AssImp.Interop.aiPostProcessSteps;

namespace AssImp.Interop;

public static partial class AssImp
{
    [NativeTypeName("#define aiProcess_ConvertToLeftHanded ( \\\n    aiProcess_MakeLeftHanded     | \\\n    aiProcess_FlipUVs            | \\\n    aiProcess_FlipWindingOrder   | \\\n    0 )")]
    public const int aiProcess_ConvertToLeftHanded = ((int)(aiProcess_MakeLeftHanded) | (int)(aiProcess_FlipUVs) | (int)(aiProcess_FlipWindingOrder) | 0);

    [NativeTypeName("#define aiProcessPreset_TargetRealtime_Fast ( \\\n    aiProcess_CalcTangentSpace      |  \\\n    aiProcess_GenNormals            |  \\\n    aiProcess_JoinIdenticalVertices |  \\\n    aiProcess_Triangulate           |  \\\n    aiProcess_GenUVCoords           |  \\\n    aiProcess_SortByPType           |  \\\n    0 )")]
    public const int aiProcessPreset_TargetRealtime_Fast = ((int)(aiProcess_CalcTangentSpace) | (int)(aiProcess_GenNormals) | (int)(aiProcess_JoinIdenticalVertices) | (int)(aiProcess_Triangulate) | (int)(aiProcess_GenUVCoords) | (int)(aiProcess_SortByPType) | 0);

    [NativeTypeName("#define aiProcessPreset_TargetRealtime_Quality ( \\\n    aiProcess_CalcTangentSpace              |  \\\n    aiProcess_GenSmoothNormals              |  \\\n    aiProcess_JoinIdenticalVertices         |  \\\n    aiProcess_ImproveCacheLocality          |  \\\n    aiProcess_LimitBoneWeights              |  \\\n    aiProcess_RemoveRedundantMaterials      |  \\\n    aiProcess_SplitLargeMeshes              |  \\\n    aiProcess_Triangulate                   |  \\\n    aiProcess_GenUVCoords                   |  \\\n    aiProcess_SortByPType                   |  \\\n    aiProcess_FindDegenerates               |  \\\n    aiProcess_FindInvalidData               |  \\\n    0 )")]
    public const int aiProcessPreset_TargetRealtime_Quality = ((int)(aiProcess_CalcTangentSpace) | (int)(aiProcess_GenSmoothNormals) | (int)(aiProcess_JoinIdenticalVertices) | (int)(aiProcess_ImproveCacheLocality) | (int)(aiProcess_LimitBoneWeights) | (int)(aiProcess_RemoveRedundantMaterials) | (int)(aiProcess_SplitLargeMeshes) | (int)(aiProcess_Triangulate) | (int)(aiProcess_GenUVCoords) | (int)(aiProcess_SortByPType) | (int)(aiProcess_FindDegenerates) | (int)(aiProcess_FindInvalidData) | 0);

    [NativeTypeName("#define aiProcessPreset_TargetRealtime_MaxQuality ( \\\n    aiProcessPreset_TargetRealtime_Quality   |  \\\n    aiProcess_FindInstances                  |  \\\n    aiProcess_ValidateDataStructure          |  \\\n    aiProcess_OptimizeMeshes                 |  \\\n    0 )")]
    public const int aiProcessPreset_TargetRealtime_MaxQuality = (((int)(aiProcess_CalcTangentSpace) | (int)(aiProcess_GenSmoothNormals) | (int)(aiProcess_JoinIdenticalVertices) | (int)(aiProcess_ImproveCacheLocality) | (int)(aiProcess_LimitBoneWeights) | (int)(aiProcess_RemoveRedundantMaterials) | (int)(aiProcess_SplitLargeMeshes) | (int)(aiProcess_Triangulate) | (int)(aiProcess_GenUVCoords) | (int)(aiProcess_SortByPType) | (int)(aiProcess_FindDegenerates) | (int)(aiProcess_FindInvalidData) | 0) | (int)(aiProcess_FindInstances) | (int)(aiProcess_ValidateDataStructure) | (int)(aiProcess_OptimizeMeshes) | 0);
}
