// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Audio;
using osu.Framework.Bindables;

// ReSharper disable once CheckNamespace

namespace osu.Game.Rulesets.Mods
{
    public class RateAdjustModHelper
    {
        public readonly IBindableNumber<double> SpeedChange;

        public double ScoreMultiplier => 1;

        public RateAdjustModHelper(IBindableNumber<double> speedChange)
        {
            SpeedChange = speedChange;
        }

        public void HandleAudioAdjustments(BindableBool adjustPitch)
        {
        }

        public void ApplyToTrack(IAdjustableAudioComponent track)
        {
            track.AddAdjustment(AdjustableProperty.Tempo, SpeedChange);
        }
    }
}
