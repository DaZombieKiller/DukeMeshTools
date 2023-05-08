namespace AssImp.Interop;

public partial struct aiUVTransform
{
    [NativeTypeName("struct aiVector2D")]
    public aiVector2D mTranslation;

    [NativeTypeName("struct aiVector2D")]
    public aiVector2D mScaling;

    [NativeTypeName("ai_real")]
    public float mRotation;
}
