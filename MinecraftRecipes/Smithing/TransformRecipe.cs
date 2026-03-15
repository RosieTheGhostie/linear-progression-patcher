using System.Text.Json.Serialization;

namespace MinecraftRecipes.Smithing;

public class TransformRecipe : ISmithingRecipe, IHasUnitResult
{
    public const string Type = "minecraft:smithing_transform";

    [JsonPropertyName("template")]
    public object? Template { get; set; } = null;

    [JsonPropertyName("base")]
    public required object Base { get; set; }

    [JsonPropertyName("addition")]
    public object? Addition { get; set; } = null;

    [JsonPropertyName("result")]
    public required UnitResult Result { get; set; }
}
