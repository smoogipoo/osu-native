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
    public class OsuModSpunOut : Mod
    {
        public override string Name => "Spun Out";
        public override string Acronym => "SO";
        public override IconUsage? Icon => OsuIcon.ModSpunOut;
        public override ModType Type => ModType.Automation;
        public override LocalisableString Description => @"Spinners will be automatically completed.";
        public override double ScoreMultiplier => 0.9;
        public override Type[] IncompatibleMods => new[] { typeof(ModAutoplay) };
        public override bool Ranked => UsesDefaultConfiguration;
    }
}
