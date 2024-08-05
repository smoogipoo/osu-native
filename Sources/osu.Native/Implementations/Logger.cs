// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace osu.Native
{
    public static unsafe class Logger
    {
        private static delegate* unmanaged<char*, void> log;

        static Logger()
        {
            log = &defaultLog;

            [UnmanagedCallersOnly]
            static void defaultLog(char* message) => Console.WriteLine(Marshal.PtrToStringUni((IntPtr)message));
        }

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Log(string message)
        {
            if (log == null)
                return;

            IntPtr msgPtr = Marshal.StringToHGlobalUni(message);
            log((char*)msgPtr);
            Marshal.FreeHGlobal(msgPtr);
        }

        /// <summary>
        /// Sets the logger.
        /// </summary>
        /// <param name="handler">A callback to handle the message.</param>
        [UnmanagedCallersOnly(EntryPoint = "SetLogger", CallConvs = [typeof(CallConvCdecl)])]
        public static void SetLogger(delegate* unmanaged<char*, void> handler)
        {
            log = handler;
        }
    }
}
