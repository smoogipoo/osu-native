// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace osu.Native
{
    public static class Logger
    {
        private static TextWriter writeStream;
        private static LogDelegate logHandler;

        public static unsafe void SetOutputStream(TextWriter stream)
        {
            writeStream = stream;
            setLogger(Marshal.GetFunctionPointerForDelegate(logHandler = onLog));
        }

        private static unsafe void onLog(char* message)
        {
            writeStream.WriteLine(Marshal.PtrToStringAuto((IntPtr)message));
        }

        [DllImport(Lazer.LIB_NAME, EntryPoint = "SetLogger")]
        private static extern int setLogger(IntPtr logger);
    }

    public unsafe delegate void LogDelegate([MarshalAs(UnmanagedType.LPStr)] char* message);
}
