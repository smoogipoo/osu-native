// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Graphics.UserInterface;

// ReSharper disable once CheckNamespace

namespace osu.Framework.Bindables
{
    public interface IBindableWithCurrent<T> : IBindable<T>, IHasCurrentValue<T>
    {
        public static IBindableWithCurrent<T> Create() => throw new NotImplementedException();
    }
}
