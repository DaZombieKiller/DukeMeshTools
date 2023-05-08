namespace AssImp.Interop;

public partial struct aiLight
{
    [NativeTypeName("struct aiString")]
    public aiString mName;

    [NativeTypeName("enum aiLightSourceType")]
    public aiLightSourceType mType;

    [NativeTypeName("struct aiVector3D")]
    public aiVector3D mPosition;

    [NativeTypeName("struct aiVector3D")]
    public aiVector3D mDirection;

    [NativeTypeName("struct aiVector3D")]
    public aiVector3D mUp;

    public float mAttenuationConstant;

    public float mAttenuationLinear;

    public float mAttenuationQuadratic;

    [NativeTypeName("struct aiColor3D")]
    public aiColor3D mColorDiffuse;

    [NativeTypeName("struct aiColor3D")]
    public aiColor3D mColorSpecular;

    [NativeTypeName("struct aiColor3D")]
    public aiColor3D mColorAmbient;

    public float mAngleInnerCone;

    public float mAngleOuterCone;

    [NativeTypeName("struct aiVector2D")]
    public aiVector2D mSize;
}
