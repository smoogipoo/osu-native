// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

// ReSharper disable once CheckNamespace

namespace osu.Framework.Development
{
    /// <summary>
    /// Utilities to ensure correct thread usage throughout a game.
    /// </summary>
    public static class ThreadSafety
    {
        public static bool IsInputThread;
        public static bool IsUpdateThread;
        public static bool IsDrawThread;
        public static bool IsAudioThread;
    }
}
