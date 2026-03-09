using System.Text.Json.Serialization;

namespace MinecraftRecipes;

public class SmokingRecipe : IRecipe, IHasUnitResult
{
    public const string Type = "minecraft:smoking";

    [JsonPropertyName("category")]
    public string? Category { get; set; } = "food";

    [JsonPropertyName("group")]
    public string? Group { get; set; } = null;

    [JsonPropertyName("ingredient")]
    public required object Ingredient { get; set; }

    [JsonPropertyName("cookingtime")]
    public int CookingTime { get; set; } = 100;

    [JsonPropertyName("result")]
    public required UnitResult Result { get; set; }

    [JsonPropertyName("experience")]
    public double? Experience { get; set; } = null;
}
