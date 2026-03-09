using System.Text.Json.Serialization;

namespace MinecraftRecipes;

public class CampfireCookingRecipe : IRecipe, IHasUnitResult
{
    public const string Type = "minecraft:campfire_cooking";

    [JsonPropertyName("ingredient")]
    public required object Ingredient { get; set; }

    [JsonPropertyName("cookingtime")]
    public int CookingTime { get; set; } = 100;

    [JsonPropertyName("result")]
    public required UnitResult Result { get; set; }
}
