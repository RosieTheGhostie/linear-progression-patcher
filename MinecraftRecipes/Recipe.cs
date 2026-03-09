using System.Text.Json.Serialization;

namespace MinecraftRecipes;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(SmeltingRecipe), typeDiscriminator: SmeltingRecipe.Type)]
[JsonDerivedType(typeof(BlastingRecipe), typeDiscriminator: BlastingRecipe.Type)]
[JsonDerivedType(typeof(SmokingRecipe), typeDiscriminator: SmokingRecipe.Type)]
[JsonDerivedType(typeof(CampfireCookingRecipe), typeDiscriminator: CampfireCookingRecipe.Type)]
[JsonDerivedType(typeof(Crafting.ShapedRecipe), typeDiscriminator: Crafting.ShapedRecipe.Type)]
[JsonDerivedType(typeof(Crafting.ShapelessRecipe), typeDiscriminator: Crafting.ShapelessRecipe.Type)]
[JsonDerivedType(typeof(Crafting.TransmuteRecipe), typeDiscriminator: Crafting.TransmuteRecipe.Type)]
[JsonDerivedType(typeof(Crafting.DecoratedPotRecipe), typeDiscriminator: Crafting.DecoratedPotRecipe.Type)]
[JsonDerivedType(typeof(StonecuttingRecipe), typeDiscriminator: StonecuttingRecipe.Type)]
[JsonDerivedType(typeof(Smithing.TransformRecipe), typeDiscriminator: Smithing.TransformRecipe.Type)]
[JsonDerivedType(typeof(Smithing.TrimRecipe), typeDiscriminator: Smithing.TrimRecipe.Type)]
public interface IRecipe
{
}
