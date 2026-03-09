using System.Text.Json.Serialization;

namespace MinecraftRecipes.Crafting;

public class ShapedRecipe : ICraftingRecipe, IHasVariableResult
{
    public const string Type = "minecraft:crafting_shaped";

    [JsonPropertyName("category")]
    public string? Category { get; set; } = "misc";

    [JsonPropertyName("group")]
    public string? Group { get; set; } = null;

    [JsonPropertyName("show_notification")]
    public bool ShowNotification { get; set; } = true;

    [JsonPropertyName("pattern")]
    public required List<string> Pattern { get; set; }

    [JsonPropertyName("key")]
    public required Dictionary<string, object> Key { get; set; }

    [JsonPropertyName("result")]
    public required VariableResult Result { get; set; }
}
