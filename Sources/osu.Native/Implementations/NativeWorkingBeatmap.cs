// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using osu.Game.Beatmaps;

namespace osu.Native
{
    public readonly unsafe partial struct NativeWorkingBeatmap : INativeObject<WorkingBeatmap>
    {
        public NativeWorkingBeatmap(WorkingBeatmap beatmap)
        {
            handle = Allocator.Reference(beatmap);
        }

        IntPtr INativeObject<WorkingBeatmap>.GetHandle() => handle;

        /// <summary>
        /// Creates a working beatmap from the given beatmap content.
        /// </summary>
        /// <param name="content">The beatmap file content.</param>
        /// <returns>The working beatmap.</returns>
        [UnmanagedCallersOnly(EntryPoint = "CreateWorkingBeatmap", CallConvs = [typeof(CallConvCdecl)])]
        public static NativeWorkingBeatmap CreateWorkingBeatmap([In] char* content)
        {
            try
            {
                string beatmapText = Marshal.PtrToStringUTF8((IntPtr)content) ?? string.Empty;
                WorkingBeatmap beatmap = new StringBackedWorkingBeatmap(beatmapText);

                return new NativeWorkingBeatmap(beatmap);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                return default;
            }
        }

        [UnmanagedCallersOnly(EntryPoint = "WorkingBeatmap_Delete", CallConvs = [typeof(CallConvCdecl)])]
        public static void Delete(NativeWorkingBeatmap beatmap)
        {
            beatmap.Delete();
        }
    }
}
