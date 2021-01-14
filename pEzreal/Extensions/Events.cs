using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Rendering;
using pEzreal.Modes;
using SharpDX;
using _Color = System.Drawing.Color;

namespace pEzreal.Extensions
{
    internal class Events
    {
        public static void Initialize()
        {
            Game.OnUpdate += OnUpdate;
            Drawing.OnDraw += OnDraw;
            Orbwalker.OnPostAttack += OnPostAttack;
        }

        private static void OnUpdate(EventArgs args)
        {
            if (Config.SkinChanger && Player.Instance.SkinId != Config.SkinId)
                Player.Instance.SetSkinId(Config.SkinId);

            var currentModes = Orbwalker.ActiveModesFlags.ToString();

            if (currentModes.Contains(Orbwalker.ActiveModes.Combo.ToString()))
                Combo.Execute();

            if (currentModes.Contains(Orbwalker.ActiveModes.Harass.ToString()) || Config.HarassToggle)
                Harass.Execute();

            if (currentModes.Contains(Orbwalker.ActiveModes.LastHit.ToString()))
                Lasthit.Execute();

            if (currentModes.Contains(Orbwalker.ActiveModes.LaneClear.ToString()))
                LaneClear.Execute();

            if (currentModes.Contains(Orbwalker.ActiveModes.JungleClear.ToString()))
                JungleClear.Execute();

            Active.Initialize();
        }

        private static void OnDraw(EventArgs args)
        {
            if (Player.Instance.IsDead) return;
            if (Config.DrawQ && (!Config.Ready || Spells.Q.IsReady()))
                Circle.Draw(Color.LightBlue, Spells.Q.Range, Player.Instance);

            if (Config.DrawW && (!Config.Ready || Spells.W.IsReady()))
                Circle.Draw(Color.LightGoldenrodYellow, Spells.W.Range, Player.Instance);

            if (Config.DrawE && (!Config.Ready || Spells.E.IsReady()))
                Circle.Draw(Color.LightPink, Spells.E.Range, Player.Instance);

            if (Config.DrawR && (!Config.Ready || Spells.R.IsReady()))
                Circle.Draw(Color.LightSalmon, Spells.R.Range, Player.Instance);

            if (Config.HarassToggle)
                Drawing.DrawText(
                    Drawing.WorldToScreen(Player.Instance.Position).X - 50,
                    Drawing.WorldToScreen(Player.Instance.Position).Y + 10,
                    _Color.White,
                    "Harass is toggled");
        }

        private static void OnPostAttack(AttackableUnit target, EventArgs args)
        {
            if (!Config.PushingW || !Spells.W.IsReady() || target == null || target.Type != GameObjectType.obj_AI_Turret ||
                !(Player.Instance.Mana > Spells.Q.ManaCost + Spells.W.ManaCost + Spells.E.ManaCost + Spells.R.ManaCost) ||
                !target.IsEnemy) return;

            foreach (var ally in EntityManager.Heroes.Allies)
                if (ally != null && !ally.IsMe && ally.IsAlly &&
                    ally.Distance(Player.Instance.Position) < Spells.W.Range)
                    Spells.W.Cast(ally);
        }
    }
}