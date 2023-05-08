namespace AssImp.Interop;

public partial struct aiCamera
{
    [NativeTypeName("struct aiString")]
    public aiString mName;

    [NativeTypeName("struct aiVector3D")]
    public aiVector3D mPosition;

    [NativeTypeName("struct aiVector3D")]
    public aiVector3D mUp;

    [NativeTypeName("struct aiVector3D")]
    public aiVector3D mLookAt;

    public float mHorizontalFOV;

    public float mClipPlaneNear;

    public float mClipPlaneFar;

    public float mAspect;

    public float mOrthographicWidth;
}
