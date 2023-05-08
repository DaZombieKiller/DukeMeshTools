namespace AssImp.Interop;

public partial struct aiAABB
{
    [NativeTypeName("struct aiVector3D")]
    public aiVector3D mMin;

    [NativeTypeName("struct aiVector3D")]
    public aiVector3D mMax;
}
