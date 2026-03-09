namespace LinearProgressionPatcher.CommandLineInterface;

/// <summary>
///   The command-line arguments for <see cref="LinearProgressionPatcher" />.
/// </summary>
public class Arguments
{
    /// <summary>
    ///   The path to the unpatched Linear Progression JAR.
    /// </summary>
    public string InputJar { get; set; }

    /// <summary>
    ///   The path at which to place the patched Linear Progression JAR.
    /// </summary>
    public string PatchedJar { get; set; }

    /// <summary>
    ///   The version of Linear Progression to patch.
    /// </summary>
    public ModVersion Version { get; set; }

    /// <summary>
    ///   The namespace providing copper equipment.
    /// </summary>
    /// <remarks>
    ///   This is only needed when targeting a version prior to 1.8.0.
    /// </remarks>
    public string? CopperEquipmentProvider { get; set; } = null;

    /// <summary>
    ///   Constructs an instance of the <see cref="Arguments" /> class.
    /// </summary>
    /// <remarks>
    ///   The normal way to construct the <see cref="Arguments" /> is through <see cref="ParseFrom" />.
    /// </remarks>
    /// <param name="inputJar">
    ///   <inheritdoc cref="InputJar" />
    /// </param>
    /// <param name="patchedJar">
    ///   <inheritdoc cref="PatchedJar" />
    /// </param>
    /// <param name="version">
    ///   <inheritdoc cref="Version" />
    /// </param>
    internal Arguments(
        string inputJar,
        string patchedJar,
        ModVersion? version = null,
        string? copperEquipmentProvider = null
    )
    {
        InputJar = inputJar;
        PatchedJar = patchedJar;
        Version = version ?? ModVersion.V1_8;
        CopperEquipmentProvider = copperEquipmentProvider;
    }

    /// <summary>
    ///   Parses an <see cref="Arguments" /> instance from <paramref name="args" />.
    /// </summary>
    /// <param name="args">
    ///   A list of command-line arguments, not including the name of the program.
    /// </param>
    /// <returns>
    ///   The parsed arguments.
    /// </returns>
    /// <exception cref="HelpRequestedException" />
    /// <exception cref="ParseException" />
    public static Arguments ParseFrom(string[] args)
    {
        Parser parser = new();
        try
        {
            foreach (string arg in args)
            {
                parser.ParseNextArgument(arg);
            }
        }
        catch (HelpRequestedException)
        {
            PrintUsage();
            throw;
        }

        return parser.Finish();
    }

    /// <summary>
    ///   Prints the program's usage to the console.
    /// </summary>
    private static void PrintUsage()
    {
        Console.WriteLine(@$"Usage: {nameof(LinearProgressionPatcher)} [OPTIONS] <INPUT_JAR> <PATCHED_JAR>

Arguments:
  <INPUT_JAR>    The path to the unpatched Linear Progression JAR
  <PATCHED_JAR>  The path at which to place the patched Linear Progression JAR

Options:
  -v, --version <VERSION>  The version of Linear Progression to patch
      --copper-equipment-provider <NAMESPACE>
                           The namespace providing copper equipment
  -h, --help               Print help");
    }
}
