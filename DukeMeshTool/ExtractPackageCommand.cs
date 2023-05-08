using DukeForever;
using System.CommandLine;
using System.CommandLine.Invocation;

internal static class ExtractPackageCommand
{
    private static readonly Argument<string> s_InputArgument = new("input");

    private static readonly Argument<string> s_OutputArgument = new("output");

    public static Command Command { get; }

    static ExtractPackageCommand()
    {
        Command = new Command("extract");
        Command.AddArgument(s_InputArgument);
        Command.AddArgument(s_OutputArgument);
        Handler.SetHandler(Command, Execute);
    }

    public static void Execute(InvocationContext context)
    {
        var filePath = context.ParseResult.GetValueForArgument(s_InputArgument);
        var destPath = context.ParseResult.GetValueForArgument(s_OutputArgument);
        var package  = new SkinMeshPackage();

        using (var fs = File.OpenRead(filePath))
        {
            var reader = new UnStreamReader(fs);
            package.Serialize(reader);
        }
        
        foreach (SkinMeshFile entry in package.Entries)
        {
            Console.WriteLine(entry.Path);
            var destination = Path.Combine(destPath, entry.Path);

            if (Path.GetDirectoryName(destination) is { Length: > 0 } directory)
                Directory.CreateDirectory(directory);

            File.WriteAllBytes(destination, entry.Data);
        }
    }
}
