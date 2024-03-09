// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Bindables;
using osu.Framework.Graphics.Containers;

// ReSharper disable once CheckNamespace

namespace osu.Game.Screens.Play
{
    public class DimmableStoryboard : CompositeDrawable
    {
        public readonly Bindable<bool> IgnoreUserSettings = default!;
    }
}
