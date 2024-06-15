// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using osu.Game.Beatmaps;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Beatmaps.Formats;
using osu.Game.Beatmaps.Legacy;
using osu.Game.Native;
using osu.Game.Rulesets;
using osu.Game.Rulesets.Catch.Mods;
using osu.Game.Rulesets.Mania.Mods;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Osu.Mods;
using osu.Game.Rulesets.Taiko.Mods;

// ReSharper disable once CheckNamespace

public unsafe class Program
{
    static Program()
    {
        // This is kinda unfortunate, but I want to avoid mocking these.
        // Sigh... Probably aaaaaaaaaalllllll of these should not use Activator.CreateInstance(), including above.

        _ = Activator.CreateInstance<LegacyControlPointInfo>();
        _ = Activator.CreateInstance<TimingControlPoint>();
        _ = Activator.CreateInstance<SampleControlPoint>();
        _ = Activator.CreateInstance<EffectControlPoint>();
        _ = Activator.CreateInstance<DifficultyControlPoint>();
        _ = Activator.CreateInstance<TimingControlPoint>();
        _ = Activator.CreateInstance<LegacyDecoder<Beatmap>.LegacySampleControlPoint>();

        _ = Activator.CreateInstance<OsuModTouchDevice>();
        _ = Activator.CreateInstance<OsuModDoubleTime>();
        _ = Activator.CreateInstance<OsuModHalfTime>();
        _ = Activator.CreateInstance<OsuModEasy>();
        _ = Activator.CreateInstance<OsuModHardRock>();
        _ = Activator.CreateInstance<OsuModFlashlight>();
        _ = Activator.CreateInstance<OsuModHidden>();
        _ = Activator.CreateInstance<OsuModRelax>();

        _ = Activator.CreateInstance<TaikoModDoubleTime>();
        _ = Activator.CreateInstance<TaikoModHalfTime>();
        _ = Activator.CreateInstance<TaikoModEasy>();
        _ = Activator.CreateInstance<TaikoModHardRock>();

        _ = Activator.CreateInstance<CatchModDoubleTime>();
        _ = Activator.CreateInstance<CatchModHalfTime>();
        _ = Activator.CreateInstance<CatchModEasy>();
        _ = Activator.CreateInstance<CatchModHardRock>();

        _ = Activator.CreateInstance<ManiaModDoubleTime>();
        _ = Activator.CreateInstance<ManiaModHalfTime>();
        _ = Activator.CreateInstance<ManiaModEasy>();
        _ = Activator.CreateInstance<ManiaModHardRock>();
        _ = Activator.CreateInstance<ManiaModKey1>();
        _ = Activator.CreateInstance<ManiaModKey2>();
        _ = Activator.CreateInstance<ManiaModKey3>();
        _ = Activator.CreateInstance<ManiaModKey4>();
        _ = Activator.CreateInstance<ManiaModKey5>();
        _ = Activator.CreateInstance<ManiaModKey6>();
        _ = Activator.CreateInstance<ManiaModKey7>();
        _ = Activator.CreateInstance<ManiaModKey8>();
        _ = Activator.CreateInstance<ManiaModKey9>();
        _ = Activator.CreateInstance<ManiaModDualStages>();
    }

    private static LogDelegate? logger;

    /// <summary>
    /// Sets the logger.
    /// </summary>
    /// <param name="handler">A <see cref="LogDelegate"/> callback to handle the message.</param>
    [UnmanagedCallersOnly(EntryPoint = "SetLogger", CallConvs = [typeof(CallConvCdecl)])]
    public static ErrorCode SetLogger(IntPtr handler)
    {
        logger = Marshal.GetDelegateForFunctionPointer<LogDelegate>(handler);
        return ErrorCode.Success;
    }

    /// <summary>
    /// Computes difficulty given a beatmap file path.
    /// </summary>
    /// <param name="filePathPtr">The file path.</param>
    /// <param name="rulesetId">The ruleset.</param>
    /// <param name="mods">The mods.</param>
    /// <param name="starRating">The star rating.</param>
    [UnmanagedCallersOnly(EntryPoint = "ComputeDifficulty_FromFile", CallConvs = [typeof(CallConvCdecl)])]
    public static ErrorCode ComputeDifficultyFromFile(char* filePathPtr, int rulesetId, uint mods, double* starRating)
    {
        string? filePath = Marshal.PtrToStringUTF8((IntPtr)filePathPtr);

        if (string.IsNullOrEmpty(filePath))
            return error(ErrorCode.FileReadError, "Path is empty.");

        try
        {
            return computeDifficulty(File.ReadAllText(filePath), rulesetId, mods, starRating);
        }
        catch (Exception ex)
        {
            return error(ErrorCode.Failure, ex.ToString());
        }
    }

    /// <summary>
    /// Computes difficulty given beatmap content.
    /// </summary>
    /// <param name="beatmapTextPtr">The beatmap content.</param>
    /// <param name="rulesetId">The ruleset.</param>
    /// <param name="mods">The mods.</param>
    /// <param name="starRating">The star rating.</param>
    [UnmanagedCallersOnly(EntryPoint = "ComputeDifficulty_FromText", CallConvs = [typeof(CallConvCdecl)])]
    public static ErrorCode ComputeDifficultyFromText(char* beatmapTextPtr, int rulesetId, uint mods, double* starRating)
    {
        string? beatmapText = Marshal.PtrToStringUTF8((IntPtr)beatmapTextPtr);
        return computeDifficulty(beatmapText, rulesetId, mods, starRating);
    }

    private static ErrorCode computeDifficulty(string? beatmapText, int rulesetId, uint mods, double* starRating)
    {
        if (string.IsNullOrEmpty(beatmapText))
            return error(ErrorCode.EmptyBeatmap, "Beatmap is empty.");

        try
        {
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
        {
            IntPtr msgPtr = Marshal.StringToHGlobalUni(description);
            logger((char*)msgPtr);
            Marshal.FreeHGlobal(msgPtr);
        }

        return code;
    }

    public enum ErrorCode : byte
    {
        Success = 0,
        EmptyBeatmap = 1,
        FileReadError = 2,
        Failure = 255
    }

    public delegate void LogDelegate(char* message);
}
