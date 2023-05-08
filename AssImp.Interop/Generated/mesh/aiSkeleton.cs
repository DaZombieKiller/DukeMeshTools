namespace AssImp.Interop;

public unsafe partial struct aiSkeleton
{
    [NativeTypeName("struct aiString")]
    public aiString mName;

    [NativeTypeName("unsigned int")]
    public uint mNumBones;

    [NativeTypeName("struct aiSkeletonBone **")]
    public aiSkeletonBone** mBones;
}
