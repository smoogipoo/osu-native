// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Graphics.Containers;
using osu.Game.Beatmaps.Timing;

// ReSharper disable once CheckNamespace

namespace osu.Game.Screens.Play
{
    public class BreakOverlay : CompositeDrawable
    {
        public const double BREAK_FADE_DURATION = BreakPeriod.MIN_BREAK_DURATION / 2;
    }
}
