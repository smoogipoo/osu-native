// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

namespace osu.Native.Bindings
{
    public class LazerException : Exception
    {
        public LazerException(string message)
            : base(message)
        {
        }
    }
}
