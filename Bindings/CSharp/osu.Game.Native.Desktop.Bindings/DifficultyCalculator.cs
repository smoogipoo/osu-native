// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.IO;

namespace osu.Game.Native.Desktop.Bindings
{
    public class DifficultyCalculator : IDifficultyCalculator
    {
        public double ComputeDifficulty(FileInfo file, int rulesetId, uint mods)
        {
            throwOnError((ErrorCode)Native.ComputeDifficultyFromFile(file.FullName, rulesetId, mods, out double starRating));
            return starRating;
        }

        public double ComputeDifficulty(string content, int rulesetId, uint mods)
        {
            throwOnError((ErrorCode)Native.ComputeDifficultyFromText(content, rulesetId, mods, out double starRating));
            return starRating;
        }

        private void throwOnError(ErrorCode errorCode)
        {
            switch (errorCode)
            {
                case ErrorCode.Success:
                    break;

                case ErrorCode.EmptyBeatmap:
                    throw new LazerException("The provided beatmap was empty.");

                case ErrorCode.FileReadError:
                    throw new LazerException("The file could not be read.");

                default:
                    throw new LazerException("An unknown failure occurred.");
            }
        }
    }
}
