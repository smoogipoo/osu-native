// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Runtime.InteropServices;

namespace osu.Native.Bindings
{
    public unsafe class Lazer
    {
        public event Action<string> Log;

        private static Native.LogDelegate logHandler;

        public Lazer()
        {
            Native.SetLogger(Marshal.GetFunctionPointerForDelegate(logHandler = onLazerLog));
        }

        private void onLazerLog(char* message)
        {
            Log?.Invoke(Marshal.PtrToStringAuto((IntPtr)message));
        }

        public IDifficultyCalculator CreateDifficultyCalculator() => new DifficultyCalculator();
    }
}
