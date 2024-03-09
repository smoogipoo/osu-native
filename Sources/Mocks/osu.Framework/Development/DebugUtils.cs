// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Reflection;

// ReSharper disable once CheckNamespace

namespace osu.Framework.Development
{
    public static class DebugUtils
    {
        public static bool IsNUnitRunning => false;
        public static bool IsDebugBuild => false;
        public static bool LogPerformanceIssues => false;
        public static Assembly NUnitTestAssembly => null!;
    }
}
