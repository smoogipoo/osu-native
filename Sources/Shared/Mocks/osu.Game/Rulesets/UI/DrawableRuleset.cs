// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using osu.Framework.Graphics.Containers;

// ReSharper disable once CheckNamespace

namespace osu.Game.Rulesets.UI
{
    public class DrawableRuleset<T> : DrawableRuleset
    {
        public Playfield Playfield = default!;
    }

    public class DrawableRuleset : CompositeDrawable
    {
        public bool AlwaysPresent;

        public List<object> Overlays => throw new NotImplementedException();

        public void Hide()
        {
            throw new NotImplementedException();
        }
    }
}
