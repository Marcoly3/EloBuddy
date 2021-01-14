using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Notifications;
using pEzreal.Extensions;

namespace pEzreal
{
    internal class Program
    {
        private static void Main()
        {
            Loading.OnLoadingComplete += GameLoaded;
        }

        private static void GameLoaded(EventArgs args)
        {
            if (Player.Instance.ChampionName != "Ezreal") return;
            Notifications.Show(new SimpleNotification("pEzreal", "Successfully loaded."));

            Events.Initialize();
            Config.Initialize();
            Spells.Initialize();
        }
    }
}