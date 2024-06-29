// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Runtime.InteropServices;

namespace osu.Native.Bindings
{
    internal class Native
    {
#if NETFRAMEWORK
        private const string lib_name = "osu.Native.dll";
#else
        private const string lib_name = "osu.Native";
#endif

        [DllImport(lib_name, EntryPoint = "ComputeDifficulty_FromFile")]
        public static extern int ComputeDifficultyFromFile([MarshalAs(UnmanagedType.LPStr)] string filePath, int rulesetId, uint mods, out double starRating);

        [DllImport(lib_name, EntryPoint = "ComputeDifficulty_FromText")]
        public static extern int ComputeDifficultyFromText([MarshalAs(UnmanagedType.LPStr)] string filePath, int rulesetId, uint mods, out double starRating);

        [DllImport(lib_name, EntryPoint = "SetLogger")]
        public static extern int SetLogger(IntPtr logger);

        public unsafe delegate void LogDelegate(char* message);
    }
}
