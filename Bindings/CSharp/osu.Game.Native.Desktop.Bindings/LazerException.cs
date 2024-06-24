// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

namespace osu.Game.Native.Desktop.Bindings
{
    public class LazerException : Exception
    {
        public LazerException(string message)
            : base(message)
        {
        }
    }
}
