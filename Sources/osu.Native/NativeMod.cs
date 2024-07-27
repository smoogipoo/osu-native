// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Runtime.InteropServices;
using osu.Game.Rulesets.Mods;

namespace osu.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct NativeMod
    {
        private readonly IntPtr handle;
        private readonly IntPtr name;
        private readonly IntPtr acronym;
        public readonly ModType Type;
        public readonly double ScoreMultiplier;
        public readonly bool Ranked;

        public string Name => Marshal.PtrToStringUni(name) ?? string.Empty;
        public string Acronym => Marshal.PtrToStringUni(acronym) ?? string.Empty;
    }
}
