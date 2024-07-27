// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Runtime.InteropServices;
using System;

namespace osu.Native
{
    public partial struct NativeDifficultyCalculator : IDisposable
    {
        public unsafe NativeDifficultyAttributes Calculate(NativeMod[] mods)
        {
            fixed (NativeMod* modsPtr = mods)
                return calculate(this, modsPtr, mods.Length);
        }

        public void Dispose()
        {
            delete(this);
        }

        [DllImport(Lazer.LIB_NAME, EntryPoint = "DifficultyCalculator_Calculate")]
        private static extern unsafe NativeDifficultyAttributes calculate(NativeDifficultyCalculator calculator, [In] NativeMod* mods, int numMods);

        [DllImport(Lazer.LIB_NAME, EntryPoint = "DifficultyCalculator_Delete")]
        private static extern int delete(NativeDifficultyCalculator calculator);
    }
}
