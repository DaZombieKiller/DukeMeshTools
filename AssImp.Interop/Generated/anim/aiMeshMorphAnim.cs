namespace AssImp.Interop;

public unsafe partial struct aiMeshMorphAnim
{
    [NativeTypeName("struct aiString")]
    public aiString mName;

    [NativeTypeName("unsigned int")]
    public uint mNumKeys;

    [NativeTypeName("struct aiMeshMorphKey *")]
    public aiMeshMorphKey* mKeys;
}
