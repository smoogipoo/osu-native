// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics.Containers;
using osu.Game.Beatmaps.ControlPoints;

// ReSharper disable once CheckNamespace

namespace osu.Game.Graphics.Containers
{
    public class BeatSyncedContainer : CompositeDrawable
    {
        public int Divisor;
        public bool IsBeatSyncedWithTrack;

        protected virtual void OnNewBeat(int beatIndex, TimingControlPoint timingPoint, EffectControlPoint effectPoint, ChannelAmplitudes amplitudes)
        {
            throw new NotImplementedException();
        }
    }
}
