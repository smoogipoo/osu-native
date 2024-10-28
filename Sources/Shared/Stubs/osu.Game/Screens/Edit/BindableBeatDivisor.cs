// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

// ReSharper disable once CheckNamespace

namespace osu.Game.Screens.Edit
{
    public class BindableBeatDivisor
    {
        public static readonly int[] PREDEFINED_DIVISORS = Array.Empty<int>();
        public const int MINIMUM_DIVISOR = 1;
        public const int MAXIMUM_DIVISOR = 64;
    }
}
