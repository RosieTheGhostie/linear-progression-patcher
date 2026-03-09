using System.Text;

namespace LinearProgressionPatcher;

public static class McFunctionPatcher
{
    public static void PatchAll(ModVersion modVersion)
    {
        switch (modVersion)
        {
            case ModVersion.V1_8:
                PatchV1_8();
                break;
            default:
                break;
        }
    }

    private static void PatchV1_8()
    {
        PatchOutDurabilityChecks(Directories.LinearProgression.Function("tick"));
    }

    private static void PatchOutDurabilityChecks(string filePath)
    {
        const string DurabilityCheckPrefix = "execute as @a if predicate linear_progression:durability_check/";

        string[] lines = File.ReadAllLines(filePath);
        using FileStream tickFile = File.OpenWrite(filePath);
        foreach (string line in lines.Where(line => !line.StartsWith(DurabilityCheckPrefix)))
        {
            tickFile.Write(Encoding.UTF8.GetBytes(line));
        }
    }
}
