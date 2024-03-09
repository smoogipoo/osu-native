// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace

namespace osu.Framework.Extensions
{
    public static class ExtensionMethods
    {
        public static int AddInPlace<T>(this List<T> list, T item)
        {
            int index = list.BinarySearch(item);
            if (index < 0) index = ~index;
            list.Insert(index, item);
            return index;
        }

        public static string GetDescription(this object value) => throw new NotImplementedException();

        public static string ToStandardisedPath(this string path)
            => path.Replace('\\', '/');
    }
}
