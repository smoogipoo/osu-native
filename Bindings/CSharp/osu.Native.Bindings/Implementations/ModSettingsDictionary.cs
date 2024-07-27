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
        private readonly Dictionary<string, string> settings;

        internal unsafe ModSettingsDictionary(NativeMod mod)
        {
            this.mod = mod;
            settings = new Dictionary<string, string>();

            char** names;
            char** values;
            int count = getSettings(mod, &names, &values);

            for (int i = 0; i < count; i++)
                settings.Add(Marshal.PtrToStringUni((IntPtr)names[i]) ?? string.Empty, Marshal.PtrToStringUni((IntPtr)values[i]) ?? string.Empty);
        }

        public string this[string key]
        {
            get => settings[key];
            set
            {
                settings[key] = value;
                setSetting(mod, key, value);
            }
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return settings.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        [DllImport(Lazer.LIB_NAME, EntryPoint = "Mod_GetSettings")]
        private static extern unsafe int getSettings(NativeMod mod, [Out] char*** names, [Out] char*** values);

        [DllImport(Lazer.LIB_NAME, EntryPoint = "Mod_SetSetting")]
        private static extern void setSetting(NativeMod mod, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string value);
    }
}
