namespace LinearProgressionPatcher.CommandLineInterface;

/// <summary>
///   Represents an object capable of parsing command-line arguments into an instance of the <see cref="Arguments" /> class.
/// </summary>
internal class Parser()
{
    /// <inheritdoc cref="Arguments.InputJar" />
    public string? InputJar { get; set; } = null;

    /// <inheritdoc cref="Arguments.PatchedJar" />
    public string? PatchedJar { get; set; } = null;

    /// <inheritdoc cref="Arguments.Version" />
    public ModVersion? Version { get; set; } = null;

    /// <inheritdoc cref="Arguments.CopperEquipmentProvider" />
    public string? CopperEquipmentProvider { get; set; } = null;

    /// <summary>
    ///   The current state of the parser.
    /// </summary>
    private ParserState State { get; set; } = ParserState.Default;

    /// <summary>
    ///   Attempts to finish parsing and yield the parsed <see cref="Arguments" />.
    /// </summary>
    /// <returns>
    ///   The parsed arguments.
    /// </returns>
    /// <exception cref="ParseException" />
    public Arguments Finish() => new(
        InputJar ?? throw ParseException.MissingArgument("INPUT_JAR"),
        PatchedJar ?? throw ParseException.MissingArgument("PATCHED_JAR"),
        version: Version,
        copperEquipmentProvider: CopperEquipmentProvider
    );

    /// <summary>
    ///   Parses <paramref name="arg" /> as the next argument in the sequence.
    /// </summary>
    /// <param name="arg">
    ///   The next command-line argument.
    /// </param>
    /// <exception cref="HelpRequestedException" />
    /// <exception cref="ParseException" />
    public void ParseNextArgument(string arg)
    {
        switch (State)
        {
            case ParserState.WantVersion:
                Version = ParseVersion(arg);
                State = ParserState.Default;
                return;
            case ParserState.WantCopperEquipmentProvider:
                CopperEquipmentProvider = arg;
                State = ParserState.Default;
                return;
            case ParserState.Default:
            default:
                break;
        }

        switch (arg)
        {
            case "-h" or "--help":
                throw new HelpRequestedException();
            case "-v" or "--version":
                if (Version is not null)
                {
                    throw ParseException.DuplicateOption(arg);
                }

                State = ParserState.WantVersion;
                break;
            case "--copper-equipment-provider":
                if (CopperEquipmentProvider is not null)
                {
                    throw ParseException.DuplicateOption(arg);
                }

                State = ParserState.WantCopperEquipmentProvider;
                break;
            case var _ when arg.StartsWith('-'):
                throw ParseException.UnknownOption(arg);
            case var _ when InputJar is null:
                InputJar = arg;
                break;
            case var _ when PatchedJar is null:
                PatchedJar = arg;
                break;
            default:
                throw ParseException.ExtraArgument(arg);
        }
    }

    /// <summary>
    ///   Parses <paramref name="version" /> as a <see cref="ModVersion" />.
    /// </summary>
    /// <param name="version">
    ///   A string representation of a <see cref="ModVersion" />.
    /// </param>
    /// <returns>
    ///   The parsed mod version.
    /// </returns>
    /// <exception cref="ParseException" />
    private static ModVersion ParseVersion(string version)
    {
        try
        {
            return ModVersionParser.Parse(version);
        }
        catch (ArgumentException)
        {
            throw ParseException.BadOptionValue("mod version", version);
        }
    }
}

/// <summary>
///   Represents the broad state of the <see cref="Parser" />.
/// </summary>
internal enum ParserState
{
    /// <summary>
    ///   The parser is not expecting anything in particular.
    /// </summary>
    Default,

    /// <summary>
    ///   The parser is expecting the value of the <see cref="Arguments.Version" /> option.
    /// </summary>
    WantVersion,

    /// <summary>
    ///   The parser is expecting the value of the <see cref="Arguments.CopperEquipmentProvider" /> option.
    /// </summary>
    WantCopperEquipmentProvider,
}
