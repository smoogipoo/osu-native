// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Audio.Track;

// ReSharper disable once CheckNamespace

namespace osu.Framework.Audio
{
    public interface ITrackStore
    {
        TrackVirtual GetVirtual(double length);
    }
}
