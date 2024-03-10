// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Game.Rulesets.Scoring;

// ReSharper disable once CheckNamespace

namespace osu.Game.Online.API.Requests.Responses
{
    public class SoloScoreInfo
    {
        public int RulesetID = default;
        public long TotalScore = default;
        public Dictionary<HitResult, int> MaximumStatistics = default!;
    }
}
