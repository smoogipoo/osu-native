// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

// ReSharper disable once CheckNamespace

namespace osu.Game.Configuration
{
    public class OsuConfigManager
    {
        public void BindWith<T>(OsuSetting setting, T bindable)
        {
            throw new NotImplementedException();
        }
    }

    public enum OsuSetting
    {
        ShowHealthDisplayWhenCantFail,
        IncreaseFirstObjectVisibility,
    }
}
