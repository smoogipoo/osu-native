// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

// ReSharper disable once CheckNamespace

namespace Newtonsoft.Json
{
    public class JsonSerializer
    {
        public void Serialize(JsonWriter jsonWriter, object? value)
        {
        }

        public void Populate(JsonReader jsonReader, object? value)
        {
        }

        public T Deserialize<T>(JsonReader jsonReader)
        {
            return default!;
        }
    }
}
