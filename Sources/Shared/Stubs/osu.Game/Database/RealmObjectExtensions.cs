// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

// ReSharper disable once CheckNamespace

namespace osu.Game.Database
{
    public static class RealmObjectExtensions
    {
        public static T Detach<T>(this T item) => item;
    }
}
