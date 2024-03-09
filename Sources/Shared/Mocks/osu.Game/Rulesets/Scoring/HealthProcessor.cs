// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Bindables;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.Judgements;

// ReSharper disable once CheckNamespace

namespace osu.Game.Rulesets.Scoring
{
    public class HealthProcessor : CompositeDrawable
    {
        public Bindable<double> Health = default!;

#pragma warning disable CS0067 // Event is never used
        public event Func<HealthProcessor, JudgementResult, bool>? FailConditions;
#pragma warning restore CS0067 // Event is never used

        public void TriggerFailure()
        {
            throw new NotImplementedException();
        }
    }
}
