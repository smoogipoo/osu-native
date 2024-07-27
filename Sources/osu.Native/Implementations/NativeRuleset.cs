// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using osu.Game.Beatmaps.Legacy;
using osu.Game.Rulesets;
using osu.Game.Rulesets.Difficulty;
using osu.Game.Rulesets.Mods;

namespace osu.Native
{
    public readonly unsafe partial struct NativeRuleset : INativeObject<Ruleset>, IDisposable
    {
        public NativeRuleset(Ruleset ruleset)
        {
            handle = Allocator.Reference(ruleset);
            OnlineId = ruleset.RulesetInfo.OnlineID;
            shortName = Marshal.StringToHGlobalUni(ruleset.RulesetInfo.ShortName);
        }

        public void Dispose()
        {
            Marshal.FreeHGlobal(shortName);
        }

        IntPtr INativeObject<Ruleset>.GetHandle() => handle;

        /// <summary>
        /// Creates a ruleset from the given ruleset id.
        /// </summary>
        /// <param name="rulesetId">The ruleset id.</param>
        /// <returns>The ruleset.</returns>
        [UnmanagedCallersOnly(EntryPoint = "CreateRuleset", CallConvs = [typeof(CallConvCdecl)])]
        public static NativeRuleset CreateRuleset(int rulesetId)
        {
            try
            {
                Ruleset ruleset = RulesetHelper.CreateRuleset(rulesetId);
                return new NativeRuleset(ruleset);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                return default;
            }
        }

        /// <summary>
        /// Creates mods from a legacy mod enum value for the given ruleset.
        /// </summary>
        /// <param name="ruleset">The ruleset.</param>
        /// <param name="legacyMods">The legacy mod enum value.</param>
        /// <param name="mods">The resultant mods.</param>
        /// <returns></returns>
        [UnmanagedCallersOnly(EntryPoint = "Ruleset_ConvertFromLegacyMods", CallConvs = [typeof(CallConvCdecl)])]
        public static int ConvertFromLegacyMods(NativeRuleset ruleset, LegacyMods legacyMods, [Out] NativeMod** mods)
        {
            try
            {
                Mod[] osuMods = ruleset.Get().ConvertFromLegacyMods(legacyMods).ToArray();
                NativeMod[] native = osuMods.Select(m => new NativeMod(m)).ToArray();

                *mods = Allocator.Pack(native);
                return native.Length;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                return default;
            }
        }

        /// <summary>
        /// Creates a difficulty calculator for the given ruleset.
        /// </summary>
        /// <param name="ruleset">The ruleset.</param>
        /// <param name="beatmap">The beatmap.</param>
        /// <returns>The difficulty calculator.</returns>
        [UnmanagedCallersOnly(EntryPoint = "Ruleset_CreateDifficultyCalculator", CallConvs = [typeof(CallConvCdecl)])]
        public static NativeDifficultyCalculator CreateDifficultyCalculator(NativeRuleset ruleset, NativeWorkingBeatmap beatmap)
        {
            try
            {
                DifficultyCalculator calculator = ruleset.Get().CreateDifficultyCalculator(beatmap.Get());
                return new NativeDifficultyCalculator(calculator);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                return default;
            }
        }

        /// <summary>
        /// Deletes a ruleset.
        /// </summary>
        /// <param name="ruleset">The ruleset.</param>
        [UnmanagedCallersOnly(EntryPoint = "Ruleset_Delete", CallConvs = [typeof(CallConvCdecl)])]
        public static void Delete(NativeRuleset ruleset)
        {
            ruleset.Delete();
        }
    }
}
