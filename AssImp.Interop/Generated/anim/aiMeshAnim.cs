namespace AssImp.Interop;

public unsafe partial struct aiMeshAnim
{
    [NativeTypeName("struct aiString")]
    public aiString mName;

    [NativeTypeName("unsigned int")]
    public uint mNumKeys;

    [NativeTypeName("struct aiMeshKey *")]
    public aiMeshKey* mKeys;
}
