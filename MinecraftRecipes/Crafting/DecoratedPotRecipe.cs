using System.Text.Json.Serialization;

namespace MinecraftRecipes.Crafting;

public class DecoratedPotRecipe : ICraftingRecipe
{
    public const string Type = "minecraft:crafting_decorated_pot";

    [JsonPropertyName("category")]
    public string? Category { get; set; } = "misc";
}
