// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace osu.Native
{
    public struct ModSettingsDictionary : IEnumerable<KeyValuePair<string, string>>
    {
        private readonly NativeMod mod;

        internal ModSettingsDictionary(NativeMod mod)
        {
            this.mod = mod;
        }

        public unsafe string Get(string key)
        {
            char* keyPtr = default;
            char* valuePtr = default;

            try
            {
                keyPtr = (char*)Marshal.StringToHGlobalUni(key);
                valuePtr = getSetting(mod, keyPtr);
                return Marshal.PtrToStringUni((IntPtr)valuePtr);
            }
            finally
            {
                Marshal.FreeHGlobal((IntPtr)keyPtr);
                Marshal.FreeHGlobal((IntPtr)valuePtr);
            }
        }

        public void Set(string key, string value)
        {
            setSetting(mod, key, value);
        }

        public unsafe IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();

            char** names;
            char** values;
            int count = getSettings(mod, &names, &values);

            for (int i = 0; i < count; i++)
            {
                IntPtr name = (IntPtr)names[i];
                IntPtr value = (IntPtr)values[i];

                settings[Marshal.PtrToStringUni(name) ?? string.Empty] = Marshal.PtrToStringUni(value) ?? string.Empty;

                Marshal.FreeHGlobal(name);
                Marshal.FreeHGlobal(value);
            }

            return settings.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        [DllImport(Lazer.LIB_NAME, EntryPoint = "Mod_GetSettings")]
        private static extern unsafe int getSettings(NativeMod mod, [Out] char*** names, [Out] char*** values);

        [DllImport(Lazer.LIB_NAME, EntryPoint = "Mod_GetSetting")]
        private static extern unsafe char* getSetting(NativeMod mod, char* name);

        [DllImport(Lazer.LIB_NAME, EntryPoint = "Mod_SetSetting")]
        private static extern void setSetting(NativeMod mod, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string value);
    }
}
