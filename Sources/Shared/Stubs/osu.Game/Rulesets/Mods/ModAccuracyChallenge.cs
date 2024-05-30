// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Linq;
using osu.Framework.Bindables;
using osu.Framework.Localisation;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Scoring;
using osu.Game.Scoring;

// ReSharper disable once CheckNamespace

namespace osu.Game.Rulesets.Mods
{
    public class ModAccuracyChallenge : ModFailCondition, IApplicableToScoreProcessor
    {
        public override string Name => "Accuracy Challenge";
        public override string Acronym => "AC";
        public override LocalisableString Description => "Fail if your accuracy drops too low!";
        public override ModType Type => ModType.DifficultyIncrease;
        public override double ScoreMultiplier => 1.0;
        public override Type[] IncompatibleMods => base.IncompatibleMods.Concat(new[] { typeof(ModEasyWithExtraLives), typeof(ModPerfect) }).ToArray();
        public override bool RequiresConfiguration => false;
        public override bool Ranked => true;

        public BindableNumber<double> MinimumAccuracy { get; } = new BindableDouble
        {
            MinValue = 0.60,
            MaxValue = 0.99,
            Precision = 0.01,
            Default = 0.9,
            Value = 0.9,
        };

        public Bindable<AccuracyMode> AccuracyJudgeMode { get; } = new Bindable<AccuracyMode>();

        public virtual void ApplyToScoreProcessor(ScoreProcessor scoreProcessor)
        {
        }

        public virtual ScoreRank AdjustRank(ScoreRank rank, double accuracy) => rank;

        protected override bool FailCondition(HealthProcessor healthProcessor, JudgementResult result) => false;

        public enum AccuracyMode
        {
            MaximumAchievable,
            Standard,
        }
    }
}
