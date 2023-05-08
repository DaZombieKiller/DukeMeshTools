namespace AssImp.Interop;

public unsafe partial struct aiScene
{
    [NativeTypeName("unsigned int")]
    public uint mFlags;

    [NativeTypeName("struct aiNode *")]
    public aiNode* mRootNode;

    [NativeTypeName("unsigned int")]
    public uint mNumMeshes;

    [NativeTypeName("struct aiMesh **")]
    public aiMesh** mMeshes;

    [NativeTypeName("unsigned int")]
    public uint mNumMaterials;

    [NativeTypeName("struct aiMaterial **")]
    public aiMaterial** mMaterials;

    [NativeTypeName("unsigned int")]
    public uint mNumAnimations;

    [NativeTypeName("struct aiAnimation **")]
    public aiAnimation** mAnimations;

    [NativeTypeName("unsigned int")]
    public uint mNumTextures;

    [NativeTypeName("struct aiTexture **")]
    public aiTexture** mTextures;

    [NativeTypeName("unsigned int")]
    public uint mNumLights;

    [NativeTypeName("struct aiLight **")]
    public aiLight** mLights;

    [NativeTypeName("unsigned int")]
    public uint mNumCameras;

    [NativeTypeName("struct aiCamera **")]
    public aiCamera** mCameras;

    [NativeTypeName("struct aiMetadata *")]
    public aiMetadata* mMetaData;

    [NativeTypeName("struct aiString")]
    public aiString mName;

    [NativeTypeName("unsigned int")]
    public uint mNumSkeletons;

    [NativeTypeName("struct aiSkeleton **")]
    public aiSkeleton** mSkeletons;

    [NativeTypeName("char *")]
    public sbyte* mPrivate;
}
