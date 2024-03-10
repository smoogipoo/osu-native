// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Graphics.Containers;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Objects.Legacy;
using osuTK;

// ReSharper disable once CheckNamespace

namespace osu.Game.Rulesets.Catch.UI
{
    public class Catcher : CompositeDrawable
    {
        public const float BASE_SIZE = 106.75f;
        public const float ALLOWED_CATCH_RANGE = 0.8f;
        public const double BASE_DASH_SPEED = 1.0;

        public static float CalculateCatchWidth(Vector2 scale) => BASE_SIZE * Math.Abs(scale.X) * ALLOWED_CATCH_RANGE;

        public static float CalculateCatchWidth(IBeatmapDifficultyInfo difficulty) => CalculateCatchWidth(calculateScale(difficulty));

        private static Vector2 calculateScale(IBeatmapDifficultyInfo difficulty) => new Vector2(LegacyRulesetExtensions.CalculateScaleFromCircleSize(difficulty.CircleSize) * 2);
    }
}
