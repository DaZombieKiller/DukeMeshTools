namespace AssImp.Interop;

public unsafe partial struct aiNodeAnim
{
    [NativeTypeName("struct aiString")]
    public aiString mNodeName;

    [NativeTypeName("unsigned int")]
    public uint mNumPositionKeys;

    [NativeTypeName("struct aiVectorKey *")]
    public aiVectorKey* mPositionKeys;

    [NativeTypeName("unsigned int")]
    public uint mNumRotationKeys;

    [NativeTypeName("struct aiQuatKey *")]
    public aiQuatKey* mRotationKeys;

    [NativeTypeName("unsigned int")]
    public uint mNumScalingKeys;

    [NativeTypeName("struct aiVectorKey *")]
    public aiVectorKey* mScalingKeys;

    [NativeTypeName("enum aiAnimBehaviour")]
    public aiAnimBehaviour mPreState;

    [NativeTypeName("enum aiAnimBehaviour")]
    public aiAnimBehaviour mPostState;
}
