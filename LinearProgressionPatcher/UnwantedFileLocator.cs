namespace LinearProgressionPatcher;

public static class UnwantedFileLocator
{
    public static string[] GetUnwantedFiles(ModVersion modVersion) => modVersion switch
    {
        ModVersion.V1_7 => UnwantedFilesV1_7,
        ModVersion.V1_8 => UnwantedFilesV1_8,
        _ => throw new ArgumentException("unsupported mod version"),
    };

    public static string[] GetUnwantedDirectories(ModVersion modVersion) => modVersion switch
    {
        ModVersion.V1_7 => UnwantedDirectoriesV1_7,
        ModVersion.V1_8 => UnwantedDirectoriesV1_8,
        _ => throw new ArgumentException("unsupported mod version"),
    };

    private static string[] UnwantedFilesV1_7 => [
        Path.Join(Directories.LinearProgression.Advancements, "detect", "breakable_item_in_inventory.json"),
        MakeUnbreakableItemModifier,
        Directories.LinearProgression.Function("initiate_modifiers"),
        Directories.LinearProgression.Function("iterate_slots"),
        Directories.LinearProgression.Function("modify_slot"),
        Directories.LinearProgression.Function(Path.Join("handlers", "handle_breakable_item_in_inventory")),
    ];

    private static string[] UnwantedDirectoriesV1_7 => [];

    private static string[] UnwantedFilesV1_8 => [MakeUnbreakableItemModifier];

    private static string[] UnwantedDirectoriesV1_8 => [DurabilityCheckPredicates];

    private static string DurabilityCheckPredicates => Path.Join(Directories.LinearProgression.Predicates, "durability_check");

    private static string MakeUnbreakableItemModifier => Path.Join(
        Directories.LinearProgression.ItemModifiers,
        "make_unbreakable.json"
    );
}
