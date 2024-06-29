// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.IO;

namespace osu.Native.Bindings
{
    public interface IDifficultyCalculator
    {
        /// <summary>
        /// Computes difficulty given a beatmap file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="rulesetId">The ruleset.</param>
        /// <param name="mods">The mods.</param>
        double ComputeDifficulty(FileInfo file, int rulesetId, uint mods);

        /// <summary>
        /// Computes difficulty given beatmap content.
        /// </summary>
        /// <param name="content">The beatmap content.</param>
        /// <param name="rulesetId">The ruleset.</param>
        /// <param name="mods">The mods.</param>
        double ComputeDifficulty(string content, int rulesetId, uint mods);
    }
}
