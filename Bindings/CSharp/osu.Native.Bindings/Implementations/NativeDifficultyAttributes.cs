// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Runtime.InteropServices;

namespace osu.Native
{
    public partial struct NativeDifficultyAttributes : IDisposable
    {
        public void Dispose()
        {
            delete(this);
        }

        [DllImport(Lazer.LIB_NAME, EntryPoint = "DifficultyAttributes_Delete")]
        private static extern int delete(NativeDifficultyAttributes attributes);
    }
}
