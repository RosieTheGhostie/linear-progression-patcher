using System.Text.Json.Serialization;

namespace MinecraftRecipes.Smithing;

public class TrimRecipe : ISmithingRecipe
{
    public const string Type = "minecraft:smithing_trim";

    [JsonPropertyName("template")]
    public object? Template { get; set; } = null;

    [JsonPropertyName("base")]
    public required object Base { get; set; }

    [JsonPropertyName("addition")]
    public object? Addition { get; set; } = null;

    [JsonExtensionData]
    public Dictionary<string, object> ExtensionData { get; set; } = [];
}
