using System.Text.Json.Serialization;

namespace MinecraftRecipes;

public class StonecuttingRecipe : IRecipe, IHasVariableResult
{
    public const string Type = "minecraft:stonecutting";

    [JsonPropertyName("ingredient")]
    public required object Ingredient { get; set; }

    [JsonPropertyName("result")]
    public required VariableResult Result { get; set; }
}
