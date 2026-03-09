using MinecraftRecipes;

namespace LinearProgressionPatcher;

public class RecipePatcher(string? copperEquipmentProvider = null)
{
    /// <summary>
    ///   The namespace under which to find copper equipment.
    /// </summary>
    public string? CopperEquipmentProvider { get; } = copperEquipmentProvider;

    public bool Patch(IRecipe recipe)
    {
        bool madeChanges = false;

        if (recipe is IHasUnitResult recipeWithUnitResult)
        {
            madeChanges |= RemoveUnbreakableComponent(recipeWithUnitResult);
        }
        else if (recipe is IHasVariableResult recipeWithVariableResult)
        {
            madeChanges |= RemoveUnbreakableComponent(recipeWithVariableResult);
        }

        if (recipe is MinecraftRecipes.Smithing.TransformRecipe smithingTransformRecipe)
        {
            madeChanges |= ApplyCopperItemPatch(smithingTransformRecipe);
        }

        return madeChanges;
    }

    private static bool RemoveUnbreakableComponent(IHasUnitResult recipe)
    {
        return recipe.Result.Components.Remove(UnbreakableComponent);
    }

    private static bool RemoveUnbreakableComponent(IHasVariableResult recipe)
    {
        return recipe.Result.Components.Remove(UnbreakableComponent);
    }

    private bool ApplyCopperItemPatch(MinecraftRecipes.Smithing.TransformRecipe recipe)
    {
        if (CopperEquipmentProvider is not null
            && recipe.Base is string @base
            && @base.StartsWith("minecraft:copper_"))
        {
            recipe.Base = string.Concat(CopperEquipmentProvider, @base["minecraft".Length..]);
            return true;
        }
        else
        {
            return false;
        }
    }

    private const string UnbreakableComponent = "minecraft:unbreakable";
}
