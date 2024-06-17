// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using osu.Game.Beatmaps;
using osu.Game.Beatmaps.Legacy;
using osu.Game.Native;
using osu.Game.Rulesets;
using osu.Game.Rulesets.Mods;

// ReSharper disable once CheckNamespace

public unsafe class Program
{
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
