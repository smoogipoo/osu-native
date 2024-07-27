// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using osu.Game.Rulesets.Difficulty;
using osu.Game.Rulesets.Mods;

namespace osu.Native
{
    public readonly unsafe partial struct NativeDifficultyCalculator : INativeObject<DifficultyCalculator>
    {
        public NativeDifficultyCalculator(DifficultyCalculator calculator)
        {
            handle = Allocator.Reference(calculator);
        }

        IntPtr INativeObject<DifficultyCalculator>.GetHandle() => handle;

        /// <summary>
        /// Calculates the difficulty of the beatmap using the selected mods.
        /// </summary>
        /// <param name="calculator">The difficulty calculator.</param>
        /// <param name="mods">An array of mods.</param>
        /// <param name="numMods">The number of mods in the <paramref name="mods"/> array.</param>
        /// <returns>The difficulty attributes.</returns>
        [UnmanagedCallersOnly(EntryPoint = "DifficultyCalculator_Calculate", CallConvs = [typeof(CallConvCdecl)])]
        public static NativeDifficultyAttributes Calculate(NativeDifficultyCalculator calculator, [In] NativeMod* mods = default, int numMods = default)
        {
            try
            {
                Mod[] osuMods = Allocator.Unpack(mods, numMods).Select(m => m.Get()).ToArray();
                return new NativeDifficultyAttributes(calculator.Get().Calculate(osuMods));
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                return default;
            }
        }

        /// <summary>
        /// Deletes a difficulty calculator.
        /// </summary>
        /// <param name="calculator">The difficulty calculator.</param>
        [UnmanagedCallersOnly(EntryPoint = "DifficultyCalculator_Delete", CallConvs = [typeof(CallConvCdecl)])]
        public static void Delete(NativeDifficultyCalculator calculator)
        {
            calculator.Delete();
        }
    }
}
