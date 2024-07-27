// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Runtime.InteropServices;

namespace osu.Native
{
    public static class Lazer
    {
#if NETFRAMEWORK
        public const string LIB_NAME = "osu.Native.dll";
#else
        public const string LIB_NAME = "osu.Native";
#endif

        [DllImport(LIB_NAME, EntryPoint = "CreateRuleset")]
        public static extern NativeRuleset CreateRuleset(int rulesetId);

        [DllImport(LIB_NAME, EntryPoint = "CreateWorkingBeatmap")]
        public static extern NativeWorkingBeatmap CreateWorkingBeatmap([MarshalAs(UnmanagedType.LPStr)] string content);
    }
}
