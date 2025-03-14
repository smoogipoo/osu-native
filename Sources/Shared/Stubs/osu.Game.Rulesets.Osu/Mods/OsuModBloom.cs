// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Localisation;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.UI;
using osu.Game.Scoring;
using osu.Game.Screens.Play;

// ReSharper disable once CheckNamespace

namespace osu.Game.Rulesets.Osu.Mods
{
    public class OsuModBloom : Mod, IApplicableToScoreProcessor, IUpdatableByPlayfield, IApplicableToPlayer
    {
        public override string Name { get; }
        public override LocalisableString Description { get; }
        public override double ScoreMultiplier { get; }
        public override string Acronym { get; }

        public void ApplyToScoreProcessor(ScoreProcessor scoreProcessor)
        {
            throw new System.NotImplementedException();
        }

        public ScoreRank AdjustRank(ScoreRank rank, double accuracy)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Playfield playfield)
        {
            throw new System.NotImplementedException();
        }

        public void ApplyToPlayer(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}
