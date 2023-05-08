namespace AssImp.Interop;

public unsafe partial struct aiNode
{
    [NativeTypeName("struct aiString")]
    public aiString mName;

    [NativeTypeName("struct aiMatrix4x4")]
    public aiMatrix4x4 mTransformation;

    [NativeTypeName("struct aiNode *")]
    public aiNode* mParent;

    [NativeTypeName("unsigned int")]
    public uint mNumChildren;

    [NativeTypeName("struct aiNode **")]
    public aiNode** mChildren;

    [NativeTypeName("unsigned int")]
    public uint mNumMeshes;

    [NativeTypeName("unsigned int *")]
    public uint* mMeshes;

    [NativeTypeName("struct aiMetadata *")]
    public aiMetadata* mMetaData;
}
