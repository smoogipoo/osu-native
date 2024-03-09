// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

// ReSharper disable once CheckNamespace

namespace osu.Game.Screens.Select
{
    public class FilterCriteria
    {
        public struct OptionalTextFilter
        {
            public bool Matches(string value) => throw new NotImplementedException();
        }
    }
}
