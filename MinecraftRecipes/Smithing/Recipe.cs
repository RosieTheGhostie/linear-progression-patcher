using System.Text.Json.Serialization;

namespace MinecraftRecipes.Smithing;

public interface ISmithingRecipe : IRecipe
{
    [JsonPropertyName("template")]
    public object? Template { get; set; }

    [JsonPropertyName("base")]
    public object Base { get; set; }

    [JsonPropertyName("addition")]
    public object? Addition { get; set; }
}
