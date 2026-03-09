using System.Text.Json.Serialization;

namespace MinecraftRecipes.Crafting;

public class ShapelessRecipe : ICraftingRecipe, IHasVariableResult
{
    public const string Type = "minecraft:crafting_shapeless";

    [JsonPropertyName("category")]
    public string? Category { get; set; } = "misc";

    [JsonPropertyName("group")]
    public string? Group { get; set; } = null;

    [JsonPropertyName("ingredients")]
    public required List<object> Ingredients { get; set; }

    [JsonPropertyName("result")]
    public required VariableResult Result { get; set; }
}
