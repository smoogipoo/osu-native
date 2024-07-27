// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Runtime.InteropServices;
using osu.Game.Beatmaps.Legacy;

namespace osu.Native
{
    public partial struct NativeRuleset : IDisposable
    {
        public unsafe NativeMod[] ConvertFromLegacyMods(LegacyMods mods)
        {
            NativeMod* nativeMods;
            int count = convertFromLegacyMods(this, mods, &nativeMods);

            NativeMod[] osuMods = new NativeMod[count];
            for (int i = 0; i < count; i++)
                osuMods[i] = nativeMods[i];

            return osuMods;
        }

        public NativeDifficultyCalculator CreateDifficultyCalculator(NativeWorkingBeatmap beatmap)
        {
            return createDifficultyCalculator(this, beatmap);
        }

        public void Dispose()
        {
            delete(this);
        }

        [DllImport(Lazer.LIB_NAME, EntryPoint = "Ruleset_ConvertFromLegacyMods")]
        private static extern unsafe int convertFromLegacyMods(NativeRuleset ruleset, LegacyMods legacyMods, [Out] NativeMod** mods);

        [DllImport(Lazer.LIB_NAME, EntryPoint = "Ruleset_CreateDifficultyCalculator")]
        private static extern NativeDifficultyCalculator createDifficultyCalculator(NativeRuleset ruleset, NativeWorkingBeatmap beatmap);

        [DllImport(Lazer.LIB_NAME, EntryPoint = "Ruleset_Delete")]
        private static extern int delete(NativeRuleset ruleset);
    }
}
