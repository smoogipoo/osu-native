// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

// ReSharper disable once CheckNamespace

namespace NUnit.Framework
{
    public class TestContext
    {
        public static TestContext CurrentContext = new TestContext();
        public readonly Test Test = new Test();
    }

    public class Test
    {
        public string? ClassName;
    }
}
