using MinecraftRecipes;

namespace LinearProgressionPatcher;

/// <summary>
///   Represents an object capable of patching Minecraft recipes.
/// </summary>
/// <param name="copperEquipmentProvider">
///   <inheritdoc cref="CopperEquipmentProvider" />
/// </param>
public class RecipePatcher(string? copperEquipmentProvider = null)
{
    /// <summary>
    ///   The namespace under which to find copper equipment.
    /// </summary>
    public string? CopperEquipmentProvider { get; } = copperEquipmentProvider;

    /// <summary>
    ///   Tries to apply all available patches to <paramref name="recipe" />.
    /// </summary>
    /// <param name="recipe">
    ///   The recipe to patch in-place.
    /// </param>
    /// <returns>
    ///   <c>true</c> if <paramref name="recipe" /> was modified, and <c>false</c> otherwise.
    /// </returns>
    /// <seealso cref="TryApplyDurabilityPatch" />
    /// <seealso cref="TryApplyCopperEquipmentPatch" />
    public bool TryPatch(IRecipe recipe)
    {
        // I think I have to write it this way to bypass the short-circuiting boolean logic.
        bool madeChanges = TryApplyDurabilityPatch(recipe);
        madeChanges |= TryApplyCopperEquipmentPatch(recipe);

        return madeChanges;
    }

    /// <summary>
    ///   Tries to apply the durability patch to <paramref name="recipe" />.
    /// </summary>
    /// <remarks>
    ///   This patch removes the unbreakable component from the recipe's result, allowing the vanilla behavior to persist.
    /// </remarks>
    /// <param name="recipe">
    ///   <inheritdoc cref="TryPatch" path="/param[@name='recipe']" />
    /// </param>
    /// <returns>
    ///   <inheritdoc cref="TryPatch" path="/returns" />
    /// </returns>
    public static bool TryApplyDurabilityPatch(IRecipe recipe) => recipe switch
    {
        IHasUnitResult recipeWithUnitResult => recipeWithUnitResult.Result.Components.Remove(UnbreakableComponent),
        IHasVariableResult recipeWithVariableResult => recipeWithVariableResult.Result.Components.Remove(UnbreakableComponent),
        _ => false,
    };

    /// <summary>
    ///   Tries to apply the copper equipment patch to <paramref name="recipe" />.
    /// </summary>
    /// <remarks>
    ///   This patch replaces the namespace of copper equipment in smithing transform recipes with
    ///   <see cref="CopperEquipmentProvider" />.
    /// </remarks>
    /// <param name="recipe">
    ///   <inheritdoc cref="TryPatch" path="/param[@name='recipe']" />
    /// </param>
    /// <returns>
    ///   <inheritdoc cref="TryPatch" path="/returns" />
    /// </returns>
    public bool TryApplyCopperEquipmentPatch(IRecipe recipe)
    {
        if (CopperEquipmentProvider is not null
            && recipe is MinecraftRecipes.Smithing.TransformRecipe transformRecipe
            && transformRecipe.Base is string @base
            && @base.StartsWith("minecraft:copper_"))
        {
            transformRecipe.Base = string.Concat(CopperEquipmentProvider, @base["minecraft".Length..]);
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    ///   An item component that makes the attached item unbreakable.
    /// </summary>
    private const string UnbreakableComponent = "minecraft:unbreakable";
}
