// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Game.Rulesets;
using osu.Game.Rulesets.Mods;

// ReSharper disable once CheckNamespace

namespace osu.Game.Online.API
{
    public class APIMod
    {
        public Mod ToMod(Ruleset ruleset) => throw new NotImplementedException();
    }
}
