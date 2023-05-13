namespace DukeForever;

public sealed class CompiledTexPackage : IUnSerializable
{
    public string Name = "";

    public int Unknown;

    public void Serialize(UnSerializer ar)
    {
        ar.Serialize(ref Name);
        ar.Serialize(ref Unknown);
    }
}
