// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Bindables;

// ReSharper disable once CheckNamespace

namespace osu.Framework.Audio
{
    public interface IAdjustableAudioComponent
    {
        void AddAdjustment(AdjustableProperty property, IBindableNumber<double> bindable);
    }
}
