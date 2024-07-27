// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using osu.Game.Rulesets.Difficulty;

namespace osu.Native
{
    public readonly partial struct NativeDifficultyAttributes : INativeObject<DifficultyAttributes>
    {
        public NativeDifficultyAttributes(DifficultyAttributes attributes)
        {
            handle = Allocator.Reference(attributes);
            StarRating = attributes.StarRating;
            MaxCombo = attributes.MaxCombo;
        }

        IntPtr INativeObject<DifficultyAttributes>.GetHandle() => handle;

        /// <summary>
        /// Deletes the difficulty attributes.
        /// </summary>
        /// <param name="attributes">The difficulty attributes.</param>
        [UnmanagedCallersOnly(EntryPoint = "DifficultyAttributes_Delete", CallConvs = [typeof(CallConvCdecl)])]
        public static void Delete(NativeDifficultyCalculator attributes)
        {
            attributes.Delete();
        }
    }
}
