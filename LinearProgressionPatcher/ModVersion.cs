using System.Text.RegularExpressions;

namespace LinearProgressionPatcher;

public enum ModVersion
{
    V1_7,
    V1_8,
}

public static partial class ModVersionParser
{
    public static ModVersion Parse(string version)
    {
        Match match;
        try
        {
            match = VersionRegex.Match(version);
        }
        catch
        {
            throw new ArgumentException("invalid mod version");
        }

        return (match.Groups[1].Value, match.Groups[2].Value) switch
        {
            ("1", "7") => ModVersion.V1_7,
            ("1", "8") => ModVersion.V1_8,
            _ => throw new ArgumentException("unknown or unsupported mod version"),
        };
    }

    [GeneratedRegex(@"^(\d+)\.(\d+)(?:\.\d+)?$")]
    private static partial Regex VersionRegex { get; }
}
