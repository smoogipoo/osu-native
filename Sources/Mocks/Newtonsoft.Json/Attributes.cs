// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

// ReSharper disable once CheckNamespace

namespace Newtonsoft.Json
{
    [AttributeUsage(AttributeTargets.All)]
    public class JsonIgnoreAttribute : Attribute;

    [AttributeUsage(AttributeTargets.All)]
    public class JsonPropertyAttribute : Attribute
    {
        public int Order { get; set; }

        public JsonPropertyAttribute()
        {
        }

        public JsonPropertyAttribute(string name)
        {
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class JsonConstructorAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.All)]
    public class JsonObjectAttribute : Attribute
    {
        public JsonObjectAttribute()
        {
        }

        public JsonObjectAttribute(MemberSerialization memberSerialization)
        {
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class JsonConverterAttribute : Attribute
    {
        public JsonConverterAttribute(Type type)
        {
        }
    }

    public enum MemberSerialization
    {
        OptOut,
        OptIn,
        Fields,
    }
}
