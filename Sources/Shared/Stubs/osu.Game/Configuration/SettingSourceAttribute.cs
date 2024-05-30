// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using osu.Framework.Bindables;

// ReSharper disable once CheckNamespace

namespace osu.Game.Configuration
{
    [AttributeUsage(AttributeTargets.All)]
    public class SettingSourceAttribute : Attribute
    {
        public string Label => string.Empty;
        public Type? SettingControlType { get; set; }

        public SettingSourceAttribute(Type declaringType, string label, string? description = null)
        {
        }

        public SettingSourceAttribute(string? label, string? description = null)
        {
        }

        public SettingSourceAttribute(Type declaringType, string label, string description, int orderPosition)
            : this(declaringType, label, description)
        {
        }

        public SettingSourceAttribute(string label, string description, int orderPosition)
            : this(label, description)
        {
        }
    }

    public static partial class SettingSourceExtensions
    {
        public static object GetUnderlyingSettingValue(this object setting)
        {
            switch (setting)
            {
                case Bindable<double> d:
                    return d.Value;

                case Bindable<int> i:
                    return i.Value;

                case Bindable<float> f:
                    return f.Value;

                case Bindable<bool> b:
                    return b.Value;

                case IBindable u:
                    // An unknown (e.g. enum) generic type.
                    var valueMethod = u.GetType().GetProperty(nameof(IBindable<int>.Value));
                    Debug.Assert(valueMethod != null);
                    return valueMethod.GetValue(u)!;

                default:
                    // fall back for non-bindable cases.
                    return setting;
            }
        }

        public static IEnumerable<(SettingSourceAttribute, PropertyInfo)> GetSettingsSourceProperties(this object obj) => Enumerable.Empty<(SettingSourceAttribute, PropertyInfo)>();

        public static ICollection<(SettingSourceAttribute, PropertyInfo)> GetOrderedSettingsSourceProperties(this object obj) => Array.Empty<(SettingSourceAttribute, PropertyInfo)>();
    }
}
