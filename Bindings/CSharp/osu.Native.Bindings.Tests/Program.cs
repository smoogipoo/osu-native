using System;
using System.IO;
using System.Linq;
using osu.Game.Beatmaps.Legacy;
using osu.Native;

Logger.SetOutputStream(Console.Out);

using var beatmap = Lazer.CreateWorkingBeatmap(File.ReadAllText(args[0]));
using var ruleset = Lazer.CreateRuleset(0);
var mods = ruleset.ConvertFromLegacyMods(LegacyMods.DoubleTime | LegacyMods.HardRock);
using var calculator = ruleset.CreateDifficultyCalculator(beatmap);

Console.WriteLine("Using 1.5 rate:");
using var attribs = calculator.Calculate(mods);
Console.WriteLine($"Rating: {attribs.StarRating}");

NativeMod dtMod = mods.Single(m => m.Acronym == "DT");
dtMod.Settings.Set("speed_change", "1.25");

Console.WriteLine("Using 1.25 rate:");
using var attribs2 = calculator.Calculate(mods);
Console.WriteLine($"Rating: {attribs2.StarRating}");
