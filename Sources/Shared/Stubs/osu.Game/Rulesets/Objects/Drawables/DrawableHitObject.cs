// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.Judgements;

// ReSharper disable once CheckNamespace

namespace osu.Game.Rulesets.Objects.Drawables
{
    public class DrawableHitObject : CompositeDrawable
    {
        public HitObject HitObject = default!;

#pragma warning disable CS0067 // Event is never used
        public event Action<DrawableHitObject, JudgementResult>? OnNewResult;
        public event Action<DrawableHitObject, JudgementResult>? OnRevertResult;
        public event Action<DrawableHitObject, ArmedState>? ApplyCustomUpdateState;
#pragma warning restore CS0067 // Event is never used
    }
}
