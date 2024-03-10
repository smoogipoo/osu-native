// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;
using osu.Game.Graphics;
using osu.Game.Rulesets.Mods;

// ReSharper disable once CheckNamespace

namespace osu.Game.Rulesets.Osu.Mods
{
    public class OsuModAutopilot : Mod
    {
        public override string Name => "Autopilot";
        public override string Acronym => "AP";
        public override IconUsage? Icon => OsuIcon.ModAutopilot;
        public override ModType Type => ModType.Automation;
        public override LocalisableString Description => @"Automatic cursor movement - just follow the rhythm.";
        public override double ScoreMultiplier => 0.1;

        public override Type[] IncompatibleMods => new[]
        {
            typeof(OsuModSpunOut),
            typeof(ModRelax),
            typeof(ModAutoplay),
            typeof(ModTouchDevice)
        };
    }
}
