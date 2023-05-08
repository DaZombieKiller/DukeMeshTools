using DukeForever;
using System.CommandLine;
using System.CommandLine.Invocation;

internal static class BuildPackageCommand
{
    public static Command Command { get; }

    private static readonly Argument<string> s_InputArgument = new("input");

    private static readonly Argument<string> s_FilesArgument = new("files");

    private static readonly Argument<string> s_OutputArgument = new("output");

    static BuildPackageCommand()
    {
        Command = new Command("build");
        Command.AddArgument(s_InputArgument);
        Command.AddArgument(s_FilesArgument);
        Command.AddArgument(s_OutputArgument);
        Handler.SetHandler(Command, Execute);
    }

    public static void Execute(InvocationContext context)
    {
        var meshPath = context.ParseResult.GetValueForArgument(s_InputArgument);
        var destPath = context.ParseResult.GetValueForArgument(s_OutputArgument);
        var search   = context.ParseResult.GetValueForArgument(s_FilesArgument);
        var package  = new SkinMeshPackage();

        foreach (string path in Directory.EnumerateFiles(meshPath, search, SearchOption.AllDirectories))
        {
            var relative = Path.GetRelativePath(meshPath, path);
            var entry    = new SkinMeshFile
            {
                Path = relative.Replace('\\', '/'),
                Data = File.ReadAllBytes(path)
            };

            package.Entries.Add(entry);
            Console.WriteLine(entry.Path);
        }

        using (var fs = File.Open(destPath, FileMode.Create, FileAccess.Write))
        {
            var writer = new UnStreamWriter(fs);
            package.Serialize(writer);
            writer.CommitLazyData();
        }
    }
}
