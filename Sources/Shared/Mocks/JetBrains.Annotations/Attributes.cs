// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

// ReSharper disable once CheckNamespace

namespace JetBrains.Annotations
{
    [AttributeUsage(AttributeTargets.All)]
    public class CanBeNullAttribute : Attribute;

    [AttributeUsage(AttributeTargets.All)]
    public class NotNullAttribute : Attribute;

    [AttributeUsage(AttributeTargets.All)]
    public class UsedImplicitlyAttribute : Attribute;

    [AttributeUsage(AttributeTargets.All)]
    public class StringFormatMethodAttribute : Attribute
    {
        public StringFormatMethodAttribute(string name)
        {
        }
    }
}
