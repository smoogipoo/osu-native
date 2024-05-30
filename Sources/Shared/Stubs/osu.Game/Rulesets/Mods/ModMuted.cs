// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Audio;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.UI;
using osu.Game.Scoring;

// ReSharper disable once CheckNamespace

namespace osu.Game.Rulesets.Mods
{
    public abstract class ModMuted : Mod
    {
        public override string Name => "Muted";
        public override string Acronym => "MU";
        public override IconUsage? Icon => FontAwesome.Solid.VolumeMute;
        public override LocalisableString Description => "Can you still feel the rhythm without music?";
        public override ModType Type => ModType.Fun;
        public override double ScoreMultiplier => 1;
        public override bool Ranked => true;
    }

    public abstract class ModMuted<TObject> : ModMuted, IApplicableToDrawableRuleset<TObject>, IApplicableToTrack, IApplicableToScoreProcessor
        where TObject : HitObject
    {
        public virtual void ApplyToDrawableRuleset(DrawableRuleset<TObject> drawableRuleset)
        {
            throw new System.NotImplementedException();
        }

        public virtual void ApplyToTrack(IAdjustableAudioComponent track)
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
    }
}
