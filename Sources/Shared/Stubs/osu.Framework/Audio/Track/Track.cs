// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using System.Linq;
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

        public double Rate => rateAdjustments.Aggregate<IBindableNumber<double>, double>(1, (current, a) => current * a.Value);

        private readonly List<IBindableNumber<double>> rateAdjustments = new List<IBindableNumber<double>>();

        public void AddAdjustment(AdjustableProperty property, IBindableNumber<double> bindable)
        {
            if (property == AdjustableProperty.Frequency || property == AdjustableProperty.Tempo)
                rateAdjustments.Add(bindable);
        }

        public void Seek(double time) => throw new NotImplementedException();
    }
}
