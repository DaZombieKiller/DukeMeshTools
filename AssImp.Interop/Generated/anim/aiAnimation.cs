namespace AssImp.Interop;

public unsafe partial struct aiAnimation
{
    [NativeTypeName("struct aiString")]
    public aiString mName;

    public double mDuration;

    public double mTicksPerSecond;

    [NativeTypeName("unsigned int")]
    public uint mNumChannels;

    [NativeTypeName("struct aiNodeAnim **")]
    public aiNodeAnim** mChannels;

    [NativeTypeName("unsigned int")]
    public uint mNumMeshChannels;

    [NativeTypeName("struct aiMeshAnim **")]
    public aiMeshAnim** mMeshChannels;

    [NativeTypeName("unsigned int")]
    public uint mNumMorphMeshChannels;

    [NativeTypeName("struct aiMeshMorphAnim **")]
    public aiMeshMorphAnim** mMorphMeshChannels;
}
