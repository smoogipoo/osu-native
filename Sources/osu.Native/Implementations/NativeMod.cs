// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using osu.Framework.Bindables;
using osu.Game.Rulesets.Mods;

namespace osu.Native
{
    public readonly unsafe partial struct NativeMod : INativeObject<Mod>, IDisposable
    {
        public NativeMod(Mod mod)
        {
            handle = Allocator.Reference(mod);
            name = Marshal.StringToHGlobalUni(mod.Name);
            acronym = Marshal.StringToHGlobalUni(mod.Acronym);
            ScoreMultiplier = mod.ScoreMultiplier;
            Ranked = mod.Ranked;
            Type = mod.Type;
        }

        public void Dispose()
        {
            Marshal.FreeHGlobal(name);
            Marshal.FreeHGlobal(acronym);
        }

        IntPtr INativeObject<Mod>.GetHandle() => handle;

        /// <summary>
        /// Creates a mod from a given acronym.
        /// </summary>
        /// <param name="ruleset">The ruleset the mod's a part of.</param>
        /// <param name="acronym">The mod's acronym.</param>
        /// <returns>The mod.</returns>
        [UnmanagedCallersOnly(EntryPoint = "CreateMod", CallConvs = [typeof(CallConvCdecl)])]
        public static NativeMod CreateMod(NativeRuleset ruleset, [In] char* acronym)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a mod's settings.
        /// </summary>
        /// <param name="mod">The mod.</param>
        /// <param name="names">The setting names. Must be freed by the caller.</param>
        /// <param name="values">The setting values. Must be freed by the caller.</param>
        /// <returns>The number of settings.</returns>
        [UnmanagedCallersOnly(EntryPoint = "Mod_GetSettings", CallConvs = [typeof(CallConvCdecl)])]
        public static int GetSettings(NativeMod mod, [Out] char*** names, [Out] char*** values)
        {
            try
            {
                Mod osuMod = mod.Get();

                char*[] osuNames = new char*[osuMod.SettingsMap.Count];
                char*[] osuValues = new char*[osuMod.SettingsMap.Count];

                int index = 0;

                foreach (KeyValuePair<string, IBindable> kvp in osuMod.SettingsMap)
                {
                    osuNames[index] = (char*)Marshal.StringToHGlobalUni(kvp.Key);
                    osuValues[index] = (char*)Marshal.StringToHGlobalUni(kvp.Value.ToString(null, CultureInfo.InvariantCulture));
                    index++;
                }

                *names = Allocator.Pack(osuNames);
                *values = Allocator.Pack(osuValues);
                return index;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                return default;
            }
        }

        /// <summary>
        /// Retrieves the value of a mod's setting.
        /// </summary>
        /// <param name="mod">The mod.</param>
        /// <param name="name">The name of the setting to retrieve the value of.</param>
        /// <returns>The value. Must be freed by the caller.</returns>
        [UnmanagedCallersOnly(EntryPoint = "Mod_GetSetting", CallConvs = [typeof(CallConvCdecl)])]
        public static char* GetSetting(NativeMod mod, [In] char* name)
        {
            try
            {
                Mod osuMod = mod.Get();
                string osuName = Marshal.PtrToStringUni((IntPtr)name) ?? string.Empty;
                string osuValue = osuMod.SettingsMap[osuName].ToString(null, CultureInfo.InvariantCulture);

                return (char*)Marshal.StringToHGlobalUni(osuValue);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                return default;
            }
        }

        /// <summary>
        /// Sets a mod's setting.
        /// </summary>
        /// <param name="mod">The mod to set the setting of.</param>
        /// <param name="name">The setting name.</param>
        /// <param name="value">The setting value.</param>
        [UnmanagedCallersOnly(EntryPoint = "Mod_SetSetting", CallConvs = [typeof(CallConvCdecl)])]
        public static void SetSetting(NativeMod mod, [In] char* name, [In] char* value)
        {
            try
            {
                Mod osuMod = mod.Get();
                string osuName = Marshal.PtrToStringUTF8((IntPtr)name) ?? string.Empty;
                string osuValue = Marshal.PtrToStringUTF8((IntPtr)value) ?? string.Empty;

                if (!osuMod.SettingsMap.TryGetValue(osuName, out IBindable? bindable))
                    throw new Exception($"Mod ({osuMod.Acronym}) does not contain the setting \"{osuName}\".");

                ((IParseable)bindable).Parse(osuValue, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a mod.
        /// </summary>
        /// <param name="mod">The mod.</param>
        [UnmanagedCallersOnly(EntryPoint = "Mod_Delete", CallConvs = [typeof(CallConvCdecl)])]
        public static void Delete(NativeMod mod)
        {
            mod.Delete();
        }
    }
}
