// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;
using osu.Game.Graphics;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.UI;
using osu.Game.Scoring;

// ReSharper disable once CheckNamespace

namespace osu.Game.Rulesets.Mods
{
    public abstract class ModFlashlight : Mod
    {
        public override string Name => "Flashlight";
        public override string Acronym => "FL";
        public override IconUsage? Icon => OsuIcon.ModFlashlight;
        public override ModType Type => ModType.DifficultyIncrease;
        public override LocalisableString Description => "Restricted view area.";
        public override bool Ranked => UsesDefaultConfiguration;

        public abstract BindableFloat SizeMultiplier { get; }
        public abstract BindableBool ComboBasedSize { get; }
        public abstract float DefaultFlashlightSize { get; }
    }

    public abstract class ModFlashlight<T> : ModFlashlight, IApplicableToDrawableRuleset<T>, IApplicableToScoreProcessor
        where T : HitObject
    {
        protected abstract Flashlight CreateFlashlight();

        public virtual void ApplyToDrawableRuleset(DrawableRuleset<T> drawableRuleset)
        {
            throw new System.NotImplementedException();
        }

        public virtual void ApplyToScoreProcessor(ScoreProcessor scoreProcessor)
        {
            throw new System.NotImplementedException();
        }

        public virtual ScoreRank AdjustRank(ScoreRank rank, double accuracy)
        {
            throw new System.NotImplementedException();
        }

        public abstract class Flashlight : Drawable
        {
        }
    }
}
