using System.CommandLine;

internal static class Program
{
    private static readonly RootCommand s_RootCommand;

    static Program()
    {
        s_RootCommand = new RootCommand("Duke Mesh Tool");
        s_RootCommand.AddCommand(ExtractPackageCommand.Command);
        s_RootCommand.AddCommand(BuildPackageCommand.Command);
        s_RootCommand.AddCommand(ConvertMeshCommand.Command);
        s_RootCommand.AddCommand(ConvertSkeletonCommand.Command);
    }

    public static Task Main(string[] args)
    {
        return s_RootCommand.InvokeAsync(args);
    }
}
