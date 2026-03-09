namespace TempDirectories;

public class TempDirectory : IDisposable
{
    public DirectoryInfo Info { get; set; }

    internal TempDirectory(DirectoryInfo info) => Info = info;

    ~TempDirectory() => Dispose();

    public static TempDirectory WithName(string name) => new(Directory.CreateDirectory(name));
    public static TempDirectory FromOperatingSystem(string? prefix = null) => new(Directory.CreateTempSubdirectory(prefix));

    public void Dispose() => Info.Delete(recursive: true);
}
