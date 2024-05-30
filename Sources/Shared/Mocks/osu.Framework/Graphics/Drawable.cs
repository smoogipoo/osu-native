// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Timing;
using osuTK;

// ReSharper disable once CheckNamespace

namespace osu.Framework.Graphics
{
    public class Drawable
    {
        public IFrameBasedClock Clock = default!;
        public FrameTimeInfo Time;
        public float Rotation;
        public Vector2 DrawSize;
        public Vector2 Scale;
        public bool AlwaysPresent;

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Hide()
        {
            throw new NotImplementedException();
        }
    }
}
