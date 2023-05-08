namespace AssImp.Interop;

public partial struct aiVectorKey
{
    public double mTime;

    [NativeTypeName("struct aiVector3D")]
    public aiVector3D mValue;
}
