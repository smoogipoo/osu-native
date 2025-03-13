using System;
using System.Linq;
using osu.Framework.Localisation;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects.Drawables;

namespace osu.Game.Rulesets.Taiko.Mods
{
    public class TaikoModRelax : ModRelax
    {
        public override LocalisableString Description => "No need to remember which key is correct anymore!";

        public void ApplyToDrawableHitObject(DrawableHitObject drawableHitObject)
        {
            throw new NotImplementedException();
        }
    }
}
