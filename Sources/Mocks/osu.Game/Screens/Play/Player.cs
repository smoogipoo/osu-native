// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Bindables;
using osu.Framework.Graphics.Containers;

// ReSharper disable once CheckNamespace

namespace osu.Game.Screens.Play
{
    public class Player : CompositeDrawable
    {
        public IBindable<bool> IsBreakTime = default!;
        public DimmableStoryboard DimmableStoryboard = default!;
        public BreakOverlay BreakOverlay = default!;

        public void ApplyToBackground(Func<DimmableStoryboard, object> func)
        {
            throw new NotImplementedException();
        }
    }
}
