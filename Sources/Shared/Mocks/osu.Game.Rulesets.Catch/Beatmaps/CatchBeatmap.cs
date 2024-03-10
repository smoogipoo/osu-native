// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using System.Linq;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Catch.Objects;
using osu.Game.Rulesets.Objects;

// ReSharper disable once CheckNamespace

namespace osu.Game.Rulesets.Catch.Beatmaps
{
    public class CatchBeatmap : Beatmap<CatchHitObject>
    {
        public static IEnumerable<PalpableCatchHitObject> GetPalpableObjects(IEnumerable<HitObject> hitObjects)
        {
            return hitObjects.SelectMany(selectPalpableObjects).OrderBy(h => h.StartTime);

            IEnumerable<PalpableCatchHitObject> selectPalpableObjects(HitObject h)
            {
                if (h is PalpableCatchHitObject palpable)
                    yield return palpable;

                foreach (var nested in h.NestedHitObjects.OfType<PalpableCatchHitObject>())
                    yield return nested;
            }
        }
    }
}
