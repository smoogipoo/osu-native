// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace

namespace osu.Framework.Graphics.Containers
{
    public class CompositeDrawable : Drawable
    {
        public IReadOnlyList<Drawable> InternalChildren
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}
