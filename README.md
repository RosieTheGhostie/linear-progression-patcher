# Linear Progression Patcher

A simple patcher script for the [Linear Progression] [Minecraft] data pack that (among other
things) re-enables the durability system.

This was made for my friend [yeonqii] and her [Mythrift modpack]. I have no affiliation with the
creators of [Linear Progression].

## Functionality

At present, this script serves two purposes:

1. Re-enable the durability system.
2. Point the recipes to a third-party copper equipment provider.
    - This only really makes sense for versions of Minecraft prior to 1.21.9. Users targeting
      Minecraft versions 1.21.9 and above can ignore this.

## Usage

The script is runnable on its own (provided the environment has an available .NET runtime) as well
as through the following command:

```bash
dotnet run --project LinearProgressionPatcher -- # arguments
```

From there, the program will provide help text.

## Compatibility

This script is currently compatible with the following versions of [Linear Progression]:

- 1.7.0 (untested)
- 1.7.1 (untested)
- 1.7.2 (untested)
- 1.7.3 (untested)
- 1.7.4 (untested)
- 1.7.5
- 1.8.0 (untested)
- 1.8.1

## Additional Notes

I will be maintaining this as long as [yeonqii] needs me to. The documentation is currently
incomplete, but the code should hopefully be pretty self-explanatory.

Also, apologies for any potentially unidiomatic code. It's been a few months since I have written
C#, and I had a hard time getting the tooling set up.

[Linear Progression]: https://modrinth.com/datapack/linear-progression
[Minecraft]: https://minecraft.net
[Mythrift modpack]: https://modrinth.com/modpack/mythrifts-modpack
[yeonqii]: https://yeonqii.carrd.co
