namespace AssImp.Interop;

public partial struct aiMemoryInfo
{
    [NativeTypeName("unsigned int")]
    public uint textures;

    [NativeTypeName("unsigned int")]
    public uint materials;

    [NativeTypeName("unsigned int")]
    public uint meshes;

    [NativeTypeName("unsigned int")]
    public uint nodes;

    [NativeTypeName("unsigned int")]
    public uint animations;

    [NativeTypeName("unsigned int")]
    public uint cameras;

    [NativeTypeName("unsigned int")]
    public uint lights;

    [NativeTypeName("unsigned int")]
    public uint total;
}
