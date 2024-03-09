// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

// ReSharper disable once CheckNamespace

namespace osu.Framework.Audio.Track
{
    public class TrackVirtual : Track
    {
        public double Rate => 1; // Todo: Actually implement!

        public TrackVirtual(double length, string name = "virtual")
        {
        }
    }
}
