// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Localisation;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects.Drawables;

// ReSharper disable once CheckNamespace

namespace osu.Game.Rulesets.Osu.Mods
{
    public class OsuModTraceable : ModWithVisibilityAdjustment
    {
        public override string Name => "Traceable";
        public override string Acronym => "TC";
        public override ModType Type => ModType.Fun;
        public override LocalisableString Description => "Put your faith in the approach circles...";
        public override double ScoreMultiplier => 1;
        public override bool Ranked => true;

        protected override void ApplyIncreasedVisibilityState(DrawableHitObject hitObject, ArmedState state)
        {
        }

        protected override void ApplyNormalVisibilityState(DrawableHitObject hitObject, ArmedState state)
        {
        }
    }
}

