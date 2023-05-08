namespace AssImp.Interop;

public unsafe partial struct aiBone
{
    [NativeTypeName("struct aiString")]
    public aiString mName;

    [NativeTypeName("unsigned int")]
    public uint mNumWeights;

    [NativeTypeName("struct aiNode *")]
    public aiNode* mArmature;

    [NativeTypeName("struct aiNode *")]
    public aiNode* mNode;

    [NativeTypeName("struct aiVertexWeight *")]
    public aiVertexWeight* mWeights;

    [NativeTypeName("struct aiMatrix4x4")]
    public aiMatrix4x4 mOffsetMatrix;
}
