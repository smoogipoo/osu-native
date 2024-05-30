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
    public static unsafe double ComputeDifficulty(char* beatmapText, int rulesetId, uint mods)
    {
        WorkingBeatmap workingBeatmap = new StringBackedWorkingBeatmap(Marshal.PtrToStringAuto((IntPtr)beatmapText) ?? throw new InvalidOperationException("Empty beatmap."));
        Ruleset ruleset = RulesetHelper.CreateRuleset(rulesetId);
        Mod[] rulesetMods = ruleset.ConvertFromLegacyMods((LegacyMods)mods).ToArray();

        return ruleset.CreateDifficultyCalculator(workingBeatmap)
                      .Calculate(rulesetMods)
                      .StarRating;
    }
}
