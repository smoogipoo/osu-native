// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Database;

// ReSharper disable once CheckNamespace

namespace osu.Game.Online.API.Requests.Responses
{
    public class APIUser : IHasOnlineID<int>
    {
        public const int SYSTEM_USER_ID = 0;

        public int Id;
        public string Username = string.Empty;
        public int OnlineID => default;
    }
}
