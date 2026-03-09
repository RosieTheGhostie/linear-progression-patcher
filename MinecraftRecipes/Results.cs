using System.Text.Json.Serialization;

namespace MinecraftRecipes;

public class TransmuteResult
{
    [JsonPropertyName("id")]
    public required string ID { get; set; }
}

public class UnitResult
{
    [JsonPropertyName("id")]
    public required string ID { get; set; }

    [JsonPropertyName("components")]
    public Dictionary<string, object> Components { get; set; } = [];
}

public interface IHasUnitResult
{
    public UnitResult Result { get; set; }
}

public class VariableResult
{
    [JsonPropertyName("id")]
    public required string ID { get; set; }

    [JsonPropertyName("components")]
    public Dictionary<string, object> Components { get; set; } = [];

    [JsonPropertyName("count")]
    public int Count { get; set; } = 1;
}

public interface IHasVariableResult
{
    public VariableResult Result { get; set; }
}
