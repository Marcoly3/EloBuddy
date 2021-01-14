using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using pEzreal.Extensions;

namespace pEzreal.Modes
{
    internal class LaneClear
    {
        public static void Execute()
        {
            if (Config.LaneClearMana >= Player.Instance.ManaPercent) return;
            if (!Config.LaneClearQ) return;

            var minion = EntityManager.MinionsAndMonsters.GetLaneMinions()
                .OrderByDescending(m => m.Health)
                .FirstOrDefault(m => m.IsValidTarget(Spells.Q.Range));

            if (minion == null || !minion.IsValidTarget(Spells.Q.Range)) return;

            Spells.Q.Cast(minion);
        }
    }
}