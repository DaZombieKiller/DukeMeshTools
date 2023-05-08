namespace DukeMeshTool;

public sealed class AssImpStreamFileIO : AssImpFileIO
{
    public override AssImpFile Open(string path, FileAccess mode)
    {
        var fs = File.Open(path, FileMode.Open, mode);
        return new AssImpStreamFile(fs, leaveOpen: false);
    }

    public override void Close(AssImpFile file)
    {
        file.Dispose();
    }
}
