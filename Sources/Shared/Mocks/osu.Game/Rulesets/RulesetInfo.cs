// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

// ReSharper disable once CheckNamespace

namespace osu.Game.Rulesets
{
    public class RulesetInfo : IRulesetInfo
    {
        public string ShortName { get; set; } = string.Empty;
        public string InstantiationInfo => string.Empty;

        public int OnlineID { get; set; } = -1;

        public string Name { get; set; } = string.Empty;

        public Func<Ruleset> CreateInstanceFunc = default!;

        public RulesetInfo(string shortName, string name, string instantiationInfo, int onlineID)
        {
        }

        public RulesetInfo()
        {
        }

        public Ruleset CreateInstance() => CreateInstanceFunc();

        public bool Equals(RulesetInfo? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other == null) return false;

            return ShortName == other.ShortName;
        }

        public bool Equals(IRulesetInfo? other) => other is RulesetInfo r && Equals(r);

        public int CompareTo(RulesetInfo? other)
        {
            if (OnlineID >= 0 && other?.OnlineID >= 0)
                return OnlineID.CompareTo(other.OnlineID);

            // Official rulesets are always given precedence for the time being.
            if (OnlineID >= 0)
                return -1;
            if (other?.OnlineID >= 0)
                return 1;

            return string.Compare(ShortName, other?.ShortName, StringComparison.Ordinal);
        }

        public int CompareTo(IRulesetInfo? other)
        {
            if (!(other is RulesetInfo ruleset))
                throw new ArgumentException($@"Object is not of type {nameof(RulesetInfo)}.", nameof(other));

            return CompareTo(ruleset);
        }

        public override int GetHashCode()
        {
            // Importantly, ignore the underlying realm hash code, as it will usually not match.
            var hashCode = new HashCode();
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            hashCode.Add(ShortName);
            return hashCode.ToHashCode();
        }
    }
}
