// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using osu.Game.Beatmaps;
using osu.Game.Beatmaps.Legacy;
using osu.Native;
using osu.Game.Rulesets;
using osu.Game.Rulesets.Mods;

// ReSharper disable once CheckNamespace

public partial class Program
{
    private static readonly MethodInfo load_beatmap_async_method;

    static Program()
    {
        load_beatmap_async_method = typeof(WorkingBeatmap).GetMethod("loadBeatmapAsync", BindingFlags.Instance | BindingFlags.NonPublic)!;
    }

    public static void Main(string[] args)
    {
    }

    [JSExport]
    public static async Task<double> ComputeDifficulty(string beatmapText, int rulesetId, int mods)
    {
        WorkingBeatmap workingBeatmap = new StringBackedWorkingBeatmap(beatmapText);
        Ruleset ruleset = RulesetHelper.CreateRuleset(rulesetId);
        Mod[] rulesetMods = ruleset.ConvertFromLegacyMods((LegacyMods)mods).ToArray();

        // Normally, the beatmap will be loaded internally via .Result.
        // In WebAssembly, this is dangerous to do because waiting on monitors is not allowed.
        // So to get around this, we extract the underlying async method and forcefully await on it before continuing onwards,
        // which makes sure that the following call to .Result will complete without waiting on a monitor.
        await (Task<IBeatmap>)load_beatmap_async_method.Invoke(workingBeatmap, [])!;

        return ruleset.CreateDifficultyCalculator(workingBeatmap)
                      .Calculate(rulesetMods)
                      .StarRating;
    }
}
