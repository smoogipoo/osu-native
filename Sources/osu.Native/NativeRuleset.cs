// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Runtime.InteropServices;

namespace osu.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct NativeRuleset
    {
        private readonly IntPtr handle;
        public readonly int OnlineId;
        private readonly IntPtr shortName;

        public string ShortName => Marshal.PtrToStringUni(shortName) ?? string.Empty;
    }
}
