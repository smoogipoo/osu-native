// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace

namespace osu.Framework.Extensions.EnumExtensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> GetValuesInOrder<T>() where T : struct, Enum
            => Enum.GetValues<T>();

        public static bool HasFlagFast<T>(this T enumValue, T flag) where T : unmanaged, Enum
            => enumValue.HasFlag(flag);
    }
}
