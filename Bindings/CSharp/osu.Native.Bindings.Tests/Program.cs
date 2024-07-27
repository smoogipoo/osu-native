using System;
using System.Collections.Generic;
using osu.Game.Beatmaps.Legacy;
using osu.Native;

var beatmap = Lazer.CreateWorkingBeatmap(args[0]);
var ruleset = Lazer.CreateRuleset(0);
var mods = ruleset.ConvertFromLegacyMods(LegacyMods.DoubleTime | LegacyMods.HardRock);

foreach (KeyValuePair<string, string> setting in mods[0].Settings)
{
    Console.WriteLine(setting.Key);
    Console.WriteLine(setting.Key);
}

Console.Read();
