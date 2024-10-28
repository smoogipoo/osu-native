// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Bindables;
using osu.Game.Configuration;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Osu.Objects;

// ReSharper disable once CheckNamespace

namespace osu.Game.Rulesets.Osu.Mods
{
    public class OsuModClassic : ModClassic, IApplicableToHitObject
    {
        [SettingSource("No slider head accuracy requirement", "Scores sliders proportionally to the number of ticks hit.")]
        public Bindable<bool> NoSliderHeadAccuracy { get; } = new BindableBool(true);

        [SettingSource("Apply classic note lock", "Applies note lock to the full hit window.")]
        public Bindable<bool> ClassicNoteLock { get; } = new BindableBool(true);

        [SettingSource("Always play a slider's tail sample", "Always plays a slider's tail sample regardless of whether it was hit or not.")]
        public Bindable<bool> AlwaysPlayTailSample { get; } = new BindableBool(true);

        [SettingSource("Fade out hit circles earlier", "Make hit circles fade out into a miss, rather than after it.")]
        public Bindable<bool> FadeHitCircleEarly { get; } = new Bindable<bool>(true);

        [SettingSource("Classic health", "More closely resembles the original HP drain mechanics.")]
        public Bindable<bool> ClassicHealth { get; } = new Bindable<bool>(true);

        public void ApplyToHitObject(HitObject hitObject)
        {
            switch (hitObject)
            {
                case Slider slider:
                    slider.ClassicSliderBehaviour = NoSliderHeadAccuracy.Value;
                    break;
            }
        }
    }
}
