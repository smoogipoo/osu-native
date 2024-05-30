// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Framework.Bindables;
using osu.Framework.Graphics.Containers;

// ReSharper disable once CheckNamespace

namespace osu.Game.Rulesets.Scoring
{
    public class ScoreProcessor : CompositeDrawable
    {
        public const double MAX_SCORE = 1000000;

        public Ruleset Ruleset = default!;
        public BindableLong TotalScore = default!;
        public Bindable<double> Accuracy = default!;
        public Bindable<double> MaximumAccuracy = default!;
        public Dictionary<HitResult, int> MaximumStatistics = default!;
    }
}
