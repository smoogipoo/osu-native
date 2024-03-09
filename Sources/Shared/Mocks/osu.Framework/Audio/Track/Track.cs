// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Bindables;

// ReSharper disable once CheckNamespace

namespace osu.Framework.Audio.Track
{
    public class Track : IAdjustableAudioComponent
    {
        public bool Looping;
        public double RestartPoint;
        public bool IsLoaded;
        public double CurrentTime;
        public double Length;
        public bool IsDummyDevice;

        public void AddAdjustment(AdjustableProperty property, BindableNumber<double> bindable)
        {
            throw new NotImplementedException();
        }

        public void Seek(double time)
        {
            throw new NotImplementedException();
        }
    }
}
