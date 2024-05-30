// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;
using osu.Game.Rulesets.Mods;

// ReSharper disable once CheckNamespace

namespace osu.Game.Rulesets.Osu.Mods
{
    public class OsuModBlinds : Mod
    {
        public override string Name => "Blinds";
        public override LocalisableString Description => "Play with blinds on your screen.";
        public override string Acronym => "BL";

        public override IconUsage? Icon => FontAwesome.Solid.Adjust;
        public override ModType Type => ModType.DifficultyIncrease;

        public override double ScoreMultiplier => UsesDefaultConfiguration ? 1.12 : 1;
        public override Type[] IncompatibleMods => new[] { typeof(OsuModFlashlight) };
        public override bool Ranked => true;
    }
}
