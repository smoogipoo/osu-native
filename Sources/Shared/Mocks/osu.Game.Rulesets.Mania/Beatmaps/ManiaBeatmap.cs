// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using System.Linq;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Mania.Objects;

// ReSharper disable once CheckNamespace

namespace osu.Game.Rulesets.Mania.Beatmaps
{
    public class ManiaBeatmap : Beatmap<ManiaHitObject>
    {
        public List<StageDefinition> Stages = new List<StageDefinition>();

        public int TotalColumns => Stages.Sum(g => g.Columns);
        public readonly int OriginalTotalColumns;

        public ManiaBeatmap(StageDefinition defaultStage, int? originalTotalColumns = null)
        {
            Stages.Add(defaultStage);
            OriginalTotalColumns = originalTotalColumns ?? defaultStage.Columns;
        }

        public StageDefinition GetStageForColumnIndex(int column)
        {
            foreach (var stage in Stages)
            {
                if (column < stage.Columns)
                    return stage;

                column -= stage.Columns;
            }

            throw new ArgumentOutOfRangeException(nameof(column), "Provided index exceeds all available stages");
        }
    }
}
