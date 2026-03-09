namespace LinearProgressionPatcher.CommandLineInterface;

/// <summary>
///   Represents an error in parsing command-line arguments.
/// </summary>
/// <seealso cref="Arguments" />
/// <seealso cref="Parser" />
public class ParseException : Exception
{
    public ParseException() : base()
    {
    }

    public ParseException(string? message) : base(message)
    {
    }

    public ParseException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    ///   Constructs a new <see cref="ParseException" /> in response to an invalid value for an option.
    /// </summary>
    /// <param name="option">
    ///   The name of the option.
    /// </param>
    /// <param name="value">
    ///   The given value of the option.
    /// </param>
    /// <returns>
    ///   An exception with an appropriate error message.
    /// </returns>
    public static ParseException BadOptionValue(string option, object value) => new($"bad value for {option}: {value}");

    /// <summary>
    ///   Constructs a new <see cref="ParseException" /> in response to an unknown option.
    /// </summary>
    /// <param name="option">
    ///   The name of the unknown option.
    /// </param>
    /// <returns>
    ///   An exception with an appropriate error message.
    /// </returns>
    public static ParseException UnknownOption(string option) => new($"unknown option: {option}");

    /// <summary>
    ///   Constructs a new <see cref="ParseException" /> in response to a duplicate option.
    /// </summary>
    /// <param name="option">
    ///   The name of the option that was duplicated.
    /// </param>
    /// <returns>
    ///   An exception with an appropriate error message.
    /// </returns>
    public static ParseException DuplicateOption(string option) => new($"duplicate option: {option}");

    /// <summary>
    ///   Constructs a new <see cref="ParseException" /> in response to a missing argument.
    /// </summary>
    /// <param name="argument">
    ///   The name of the argument that was missing.
    /// </param>
    /// <returns>
    ///   An exception with an appropriate error message.
    /// </returns>
    public static ParseException MissingArgument(string argument) => new($"missing argument: {argument}");

    /// <summary>
    ///   Constructs a new <see cref="ParseException" /> in response to an extra argument.
    /// </summary>
    /// <param name="argument">
    ///   The value of the extra argument.
    /// </param>
    /// <returns>
    ///   An exception with an appropriate error message.
    /// </returns>
    public static ParseException ExtraArgument(object value) => new($"extra argument: {value}");
}

/// <summary>
///   Represents a request to print the help text.
/// </summary>
public class HelpRequestedException : Exception
{
    public HelpRequestedException() : base(string.Empty)
    {
    }
}
