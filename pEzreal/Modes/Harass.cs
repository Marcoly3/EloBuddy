using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using pEzreal.Extensions;

namespace pEzreal.Modes
{
    internal class Harass
    {
        public static void Execute()
        {
            if (Config.HarassMana >= Player.Instance.ManaPercent) return;
            if (Player.Instance.IsRecalling()) return;

            if (Config.HarassQ)
            {
                var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Physical);
                if (target == null) return;

                var execute = Config.Harass[target.BaseSkinName].Cast<CheckBox>().CurrentValue;
                if (!execute) return;

                Spells.CastQ(target);
            }

            if (Config.HarassW)
            {
                var target = TargetSelector.GetTarget(Spells.W.Range, DamageType.Magical);
                if (target == null) return;

                var execute = Config.Harass[target.BaseSkinName].Cast<CheckBox>().CurrentValue;
                if (!execute) return;

                Spells.CastW(target);
            }
        }
    }
}