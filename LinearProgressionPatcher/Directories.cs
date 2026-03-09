namespace LinearProgressionPatcher;

public static class Directories
{
    public const string Data = "data";

    public static class Minecraft
    {
        public static string Root { get; } = Path.Join(Data, "minecraft");
        public static string Recipes { get; } = Path.Join(Root, "recipe");
    }

    public static class LinearProgression
    {
        public static string Root { get; } = Path.Join(Data, "linear_progression");
        public static string Advancements { get; } = Path.Join(Root, "advancement");
        public static string Functions { get; } = Path.Join(Root, "function");
        public static string Predicates { get; } = Path.Join(Root, "predicate");
        public static string ItemModifiers { get; } = Path.Join(Root, "item_modifier");

        public static string Function(string name) => Path.ChangeExtension(Path.Join(Functions, name), "mcfunction");
    }
}
