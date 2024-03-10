// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Game.Rulesets;
using osu.Game.Rulesets.Osu;

// ReSharper disable once CheckNamespace

namespace osu.Game.Native
{
    public static class RulesetHelper
    {
        public static Ruleset CreateRuleset(int rulesetId)
        {
            switch (rulesetId)
            {
                case 0:
                    return new OsuRuleset();

                default:
                    throw new InvalidOperationException($"Unknown ruleset id: {rulesetId}.");
            }
        }
    }
}
