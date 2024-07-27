// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
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

        public static unsafe NativeWorkingBeatmap CreateWorkingBeatmap(string content)
        {
            IntPtr contentPtr = Marshal.StringToHGlobalUni(content);

            try
            {
                return createWorkingBeatmap((char*)contentPtr);
            }
            finally
            {
                Marshal.FreeHGlobal(contentPtr);
            }
        }

        [DllImport(LIB_NAME, EntryPoint = "CreateRuleset")]
        public static extern NativeRuleset CreateRuleset(int rulesetId);

        [DllImport(LIB_NAME, EntryPoint = "CreateWorkingBeatmap")]
        private static extern unsafe NativeWorkingBeatmap createWorkingBeatmap(char* content);
    }
}
