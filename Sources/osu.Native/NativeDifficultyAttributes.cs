// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Runtime.InteropServices;

namespace osu.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct NativeDifficultyAttributes
    {
        private readonly IntPtr handle;
        public readonly double StarRating;
        public readonly int MaxCombo;
    }
}
