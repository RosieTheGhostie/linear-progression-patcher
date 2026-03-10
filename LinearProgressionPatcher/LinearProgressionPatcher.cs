// Linear Progression Patcher - a patcher script for Linear Progression.
// Copyright (C) 2026  RosieTheGhostie
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using System.IO.Compression;
using System.Text.Json;
using LinearProgressionPatcher;
using LinearProgressionPatcher.CommandLineInterface;
using MinecraftRecipes;
using TempDirectories;

internal class Program
{
    static void Main(string[] args)
    {
        Arguments arguments;
        try
        {
            arguments = Arguments.ParseFrom(args);
        }
        catch (HelpRequestedException)
        {
            return;
        }
        catch (ParseException exception)
        {
            Console.WriteLine($"[ERROR] {exception.Message}");
            return;
        }

        using TempDirectory tempDirectory = TempDirectory.FromOperatingSystem();

        ExtractInputJar(arguments.InputJar, tempDirectory.Info.FullName);

        string originalCwd = Directory.GetCurrentDirectory();
        Directory.SetCurrentDirectory(tempDirectory.Info.FullName);

        DeleteUnwantedFiles(arguments.Version);
        DeleteUnwantedDirectories(arguments.Version);
        PatchMcFunctions(arguments.Version);
        PatchRecipes(arguments.CopperEquipmentProvider);

        Directory.SetCurrentDirectory(originalCwd);
        CompressPatchedCode(arguments.PatchedJar, tempDirectory.Info.FullName);
    }

    static void ExtractInputJar(string jarPath, string outputDirectory)
    {
        Console.WriteLine("Extracting the JAR...");

        using FileStream inputJar = new(jarPath, FileMode.Open);
        ZipFile.ExtractToDirectory(inputJar, outputDirectory);
    }

    static void DeleteUnwantedFiles(ModVersion modVersion)
    {
        string[] unwantedFiles = UnwantedFileLocator.GetUnwantedFiles(modVersion);
        switch (unwantedFiles.Length)
        {
            case < 1:
                return;
            case 1:
                Console.WriteLine("Deleting 1 unwanted file...");
                break;
            default:
                Console.WriteLine($"Deleting {unwantedFiles.Length} unwanted files...");
                break;
        }

        foreach (string fileName in unwantedFiles)
        {
            Console.WriteLine($"\t{fileName}");
            File.Delete(fileName);
        }
    }

    static void DeleteUnwantedDirectories(ModVersion modVersion)
    {
        string[] unwantedDirectories = UnwantedFileLocator.GetUnwantedDirectories(modVersion);
        switch (unwantedDirectories.Length)
        {
            case < 1:
                return;
            case 1:
                Console.WriteLine("Deleting 1 unwanted directory...");
                break;
            default:
                Console.WriteLine($"Deleting {unwantedDirectories.Length} unwanted directories...");
                break;
        }

        foreach (string directoryName in unwantedDirectories)
        {
            Console.WriteLine($"\t{directoryName}");
            Directory.Delete(directoryName, recursive: true);
        }
    }

    static void PatchMcFunctions(ModVersion modVersion)
    {
        Console.WriteLine("Patching the .mcfunction files...");
        McFunctionPatcher.PatchAll(modVersion);
    }

    static void PatchRecipes(string? copperEquipmentProvider)
    {
        Console.WriteLine($"Patching the recipes in '{Directories.Minecraft.Recipes}'...");

        var jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
        RecipePatcher patcher = new(copperEquipmentProvider);
        foreach (string recipePath in Directory.EnumerateFiles(Directories.Minecraft.Recipes))
        {
            if (!Path.GetExtension(recipePath).Equals(".json", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            string recipeJsonString = File.ReadAllText(recipePath);
            IRecipe recipe = JsonSerializer.Deserialize<IRecipe>(recipeJsonString)!;
            if (patcher.TryPatch(recipe))
            {
                recipeJsonString = JsonSerializer.Serialize(recipe, jsonSerializerOptions);
                File.WriteAllText(recipePath, recipeJsonString);

                Console.WriteLine($"\t{recipePath}");
            }
        }
    }

    static void CompressPatchedCode(string jarPath, string codeDirectory)
    {
        Console.WriteLine("Compressing the patched code into a new JAR...");

        using FileStream patchedJar = new(jarPath, FileMode.OpenOrCreate);
        ZipFile.CreateFromDirectory(codeDirectory, patchedJar);
    }
}
