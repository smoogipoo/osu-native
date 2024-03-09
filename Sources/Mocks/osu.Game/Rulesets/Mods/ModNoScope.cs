// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Bindables;
using osu.Framework.Graphics.Sprites;
using osu.Game.Rulesets.Scoring;
using osu.Game.Scoring;
using osu.Game.Screens.Play;

// ReSharper disable once CheckNamespace

namespace osu.Game.Rulesets.Mods
{
    public abstract class ModNoScope : Mod, IApplicableToScoreProcessor, IApplicableToPlayer
    {
        public override string Name => "No Scope";
        public override string Acronym => "NS";
        public override ModType Type => ModType.Fun;
        public override IconUsage? Icon => FontAwesome.Solid.EyeSlash;
        public override double ScoreMultiplier => 1;
        public override bool Ranked => true;

        protected readonly BindableNumber<int> CurrentCombo = new BindableInt();
        protected readonly IBindable<bool> IsBreakTime = new Bindable<bool>();

        protected float ComboBasedAlpha;

        public abstract BindableInt HiddenComboCount { get; }

        public virtual ScoreRank AdjustRank(ScoreRank rank, double accuracy) => rank;

        public virtual void ApplyToPlayer(Player player)
        {
        }

        public virtual void ApplyToScoreProcessor(ScoreProcessor scoreProcessor)
        {
        }
    }
}
