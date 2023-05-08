namespace AssImp.Interop;

public unsafe partial struct aiMeshMorphKey
{
    public double mTime;

    [NativeTypeName("unsigned int *")]
    public uint* mValues;

    public double* mWeights;

    [NativeTypeName("unsigned int")]
    public uint mNumValuesAndWeights;
}
