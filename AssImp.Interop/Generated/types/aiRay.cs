namespace AssImp.Interop;

public partial struct aiRay
{
    [NativeTypeName("struct aiVector3D")]
    public aiVector3D pos;

    [NativeTypeName("struct aiVector3D")]
    public aiVector3D dir;
}
