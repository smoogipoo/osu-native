// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

// ReSharper disable once CheckNamespace

namespace Humanizer
{
    public static class ToQuantityExtensions
    {
        public static string ToQuantity(this string input, int quantity, ShowQuantityAs showQuantityAs = ShowQuantityAs.Numeric)
        {
            throw new NotImplementedException();
        }
    }

    public enum ShowQuantityAs
    {
        None,
        Numeric,
        Words
    }
}
