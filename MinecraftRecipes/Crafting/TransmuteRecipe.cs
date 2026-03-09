using System.Text.Json.Serialization;

namespace MinecraftRecipes.Crafting;

public class TransmuteRecipe : ICraftingRecipe
{
    public const string Type = "minecraft:crafting_transmute";

    [JsonPropertyName("category")]
    public string? Category { get; set; } = "misc";

    [JsonPropertyName("group")]
    public string? Group { get; set; } = null;

    [JsonPropertyName("input")]
    public required object Input { get; set; }

    [JsonPropertyName("material")]
    public required object Material { get; set; }

    [JsonPropertyName("result")]
    public required TransmuteResult Result { get; set; }
}
