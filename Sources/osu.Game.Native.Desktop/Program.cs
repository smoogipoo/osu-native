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

public unsafe class Program
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

    private static delegate*<IntPtr, void> logger;

    [UnmanagedCallersOnly(EntryPoint = "SetLogger")]
    public static void SetLogger(delegate*<IntPtr, void> handler)
        => logger = handler;

    [UnmanagedCallersOnly(EntryPoint = "ComputeDifficulty")]
    public static ErrorCode ComputeDifficulty(char* beatmapTextPtr, int rulesetId, uint mods, double* starRating)
    {
        *starRating = 0;

        try
        {
            string? beatmapText = Marshal.PtrToStringAuto((IntPtr)beatmapTextPtr);

            if (string.IsNullOrEmpty(beatmapText))
                return error(ErrorCode.EmptyBeatmap, "The provided beatmap was empty.");

            WorkingBeatmap workingBeatmap = new StringBackedWorkingBeatmap(beatmapText);
            Ruleset ruleset = RulesetHelper.CreateRuleset(rulesetId);
            Mod[] rulesetMods = ruleset.ConvertFromLegacyMods((LegacyMods)mods).ToArray();

            *starRating = ruleset.CreateDifficultyCalculator(workingBeatmap)
                                 .Calculate(rulesetMods)
                                 .StarRating;

            return ErrorCode.Success;
        }
        catch (Exception ex)
        {
            return error(ErrorCode.Failure, ex.ToString());
        }
    }

    private static ErrorCode error(ErrorCode code, string description)
    {
        if (logger != null)
            logger(Marshal.StringToHGlobalAuto(description));

        return code;
    }

    public enum ErrorCode : byte
    {
        Success = 0,
        EmptyBeatmap = 1,
        Failure = 255
    }
}
