namespace AssImp.Interop;

public unsafe partial struct aiSkeletonBone
{
    public int mParent;

    [NativeTypeName("struct aiNode *")]
    public aiNode* mArmature;

    [NativeTypeName("struct aiNode *")]
    public aiNode* mNode;

    [NativeTypeName("unsigned int")]
    public uint mNumnWeights;

    [NativeTypeName("struct aiMesh *")]
    public aiMesh* mMeshId;

    [NativeTypeName("struct aiVertexWeight *")]
    public aiVertexWeight* mWeights;

    [NativeTypeName("struct aiMatrix4x4")]
    public aiMatrix4x4 mOffsetMatrix;

    [NativeTypeName("struct aiMatrix4x4")]
    public aiMatrix4x4 mLocalMatrix;
}
