// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Linq;
using System.Runtime.InteropServices;
using osu.Game.Beatmaps;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Beatmaps.Formats;
using osu.Game.Beatmaps.Legacy;
using osu.Game.Native;
using osu.Game.Rulesets;
using osu.Game.Rulesets.Difficulty;
using osu.Game.Rulesets.Mods;

// ReSharper disable once CheckNamespace

public class Program
{
    static Program()
    {
        // This is kinda unfortunate, but I want to avoid mocking these.
        _ = Activator.CreateInstance<LegacyControlPointInfo>();
        _ = Activator.CreateInstance<TimingControlPoint>();
        _ = Activator.CreateInstance<SampleControlPoint>();
        _ = Activator.CreateInstance<EffectControlPoint>();
        _ = Activator.CreateInstance<DifficultyControlPoint>();
        _ = Activator.CreateInstance<TimingControlPoint>();
        _ = Activator.CreateInstance<LegacyDecoder<Beatmap>.LegacySampleControlPoint>();
    }

    [UnmanagedCallersOnly(EntryPoint = "ComputeDifficulty")]
    public static double ComputeDifficulty(IntPtr beatmapTextPtr, int rulesetId, LegacyMods legacyMods)
    {
        string beatmapText = Marshal.PtrToStringAuto(beatmapTextPtr) ?? throw new InvalidOperationException("Beatmap text was empty.");
        Ruleset ruleset = RulesetHelper.CreateRuleset(rulesetId);
        Mod[] mods = ruleset.ConvertFromLegacyMods(legacyMods).ToArray();

        DifficultyCalculator calculator = ruleset.CreateDifficultyCalculator(new StringBackedWorkingBeatmap(beatmapText));
        return calculator.Calculate(mods).StarRating;
    }
}
