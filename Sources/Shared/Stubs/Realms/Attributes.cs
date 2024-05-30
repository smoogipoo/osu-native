// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

// ReSharper disable once CheckNamespace

namespace Realms
{
    [AttributeUsage(AttributeTargets.All)]
    public class MapToAttribute : Attribute
    {
        public MapToAttribute(string name)
        {
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class PrimaryKeyAttribute : Attribute;

    [AttributeUsage(AttributeTargets.All)]
    public class IgnoredAttribute : Attribute;

    [AttributeUsage(AttributeTargets.All)]
    public class IndexedAttribute : Attribute;

    [AttributeUsage(AttributeTargets.All)]
    public class BacklinkAttribute : Attribute
    {
        public BacklinkAttribute(string name)
        {
        }
    }
}
