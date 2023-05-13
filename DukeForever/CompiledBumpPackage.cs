namespace DukeForever;

public sealed class CompiledBumpPackage : IUnSerializable
{
    public string Name = "";

    public int Unknown;

    public void Serialize(UnSerializer ar)
    {
        ar.Serialize(ref Name);

        if (ar.Version > 3)
        {
            ar.Serialize(ref Unknown);
        }
    }
}
