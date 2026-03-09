using System.Text.Json.Serialization;

namespace MinecraftRecipes.Crafting;

public interface ICraftingRecipe : IRecipe
{
    [JsonPropertyName("category")]
    public string? Category { get; set; }
}
