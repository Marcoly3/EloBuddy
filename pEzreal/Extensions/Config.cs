using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace pEzreal.Extensions
{
    internal class Config
    {
        public static Menu Settings, Combo, Harass, Lasthit, LaneClear, JungleClear, Killsteal, Items, Misc, Drawing;

        private static readonly string[] Priorities =
        {
            "Ashe", "Caitlyn", "Corki", "Draven", "Ezreal", "Graves", "Jhin", "Jinx", "Kalista", "Kindred", "KogMaw",
            "Lucian", "MissFortune", "Quinn", "Sivir", "Tristana", "Twitch", "Urgot", "Varus", "Vayne", "Xayah"
        };

        //Combo values
        public static bool ComboQ => Combo["Q"].Cast<CheckBox>().CurrentValue;
        public static bool ComboW => Combo["W"].Cast<CheckBox>().CurrentValue;
        public static bool ComboE => Combo["E"].Cast<CheckBox>().CurrentValue;
        public static int ComboEMode => Combo["E_mode"].Cast<ComboBox>().CurrentValue;
        public static bool ComboR => Combo["R"].Cast<CheckBox>().CurrentValue;
        public static int ComboREnemies => Combo["REnemies"].Cast<Slider>().CurrentValue;

        //Harass values
        public static bool HarassToggle => Harass["harassToggle"].Cast<KeyBind>().CurrentValue;
        public static bool HarassQ => Harass["Q"].Cast<CheckBox>().CurrentValue;
        public static bool HarassW => Harass["W"].Cast<CheckBox>().CurrentValue;
        public static int HarassMana => Harass["Mana"].Cast<Slider>().CurrentValue;

        //Lasthit values
        public static bool LasthitQ => Lasthit["Q"].Cast<CheckBox>().CurrentValue;
        public static int LasthitMana => Lasthit["Mana"].Cast<Slider>().CurrentValue;

        //LaneClear values
        public static bool LaneClearQ => LaneClear["Q"].Cast<CheckBox>().CurrentValue;
        public static int LaneClearMana => LaneClear["Mana"].Cast<Slider>().CurrentValue;

        //JungleClear values
        public static bool JungleClearQ => JungleClear["Q"].Cast<CheckBox>().CurrentValue;
        public static int JungleClearMana => JungleClear["Mana"].Cast<Slider>().CurrentValue;

        //Killsteal values
        public static bool KillstealQ => Killsteal["Q"].Cast<CheckBox>().CurrentValue;
        public static bool KillstealW => Killsteal["W"].Cast<CheckBox>().CurrentValue;
        public static bool KillstealR => Killsteal["R"].Cast<CheckBox>().CurrentValue;

        //Drawing values
        public static bool DrawQ => Drawing["Q"].Cast<CheckBox>().CurrentValue;
        public static bool DrawW => Drawing["W"].Cast<CheckBox>().CurrentValue;
        public static bool DrawE => Drawing["E"].Cast<CheckBox>().CurrentValue;
        public static bool DrawR => Drawing["R"].Cast<CheckBox>().CurrentValue;
        public static bool Ready => Drawing["ready"].Cast<CheckBox>().CurrentValue;

        //Items values
        public static bool UseQss => Items["qss"].Cast<CheckBox>().CurrentValue;
        public static bool ItemsBotrk => Items["botrk"].Cast<CheckBox>().CurrentValue;
        public static int ItemsBotrkHealth => Items["botrkHealth"].Cast<Slider>().CurrentValue;
        public static bool ItemsYoumuu => Items["youmuu"].Cast<CheckBox>().CurrentValue;

        //Misc values
        public static bool SkinChanger => Misc["_skinChanger"].Cast<CheckBox>().CurrentValue;
        public static int SkinId => Misc["skinID"].Cast<ComboBox>().CurrentValue;
        public static int HitchanceChosen => Misc["_hitchance"].Cast<ComboBox>().CurrentValue;
        public static bool TearStacking => Misc["tearStacking"].Cast<KeyBind>().CurrentValue;
        public static bool PushingW => Misc["pushing_w"].Cast<CheckBox>().CurrentValue;

        public static void Initialize()
        {
            Settings = MainMenu.AddMenu("pEzreal", "pEzreal");

            //Combo Menu
            Combo = Settings.AddSubMenu("Combo", "ComboMenu");

            Combo.AddGroupLabel("Mystic Shot");
            Combo.Add("Q", new CheckBox("Use"));

            Combo.AddGroupLabel("Essence Flux");
            Combo.Add("W", new CheckBox("Use"));

            Combo.AddGroupLabel("Arcane Shift");
            Combo.Add("E", new CheckBox("Use"));
            Combo.Add("E_mode", new ComboBox("Mode", 0, "To mouse", "Towards enemy", "Disabled"));

            Combo.AddGroupLabel("Trueshot Barrage");
            Combo.Add("R", new CheckBox("Use"));
            Combo.Add("REnemies", new Slider("Minimum enemies", 3, 0, 5));

            //Harass Menu
            Harass = Settings.AddSubMenu("Harass", "HarassMenu");

            Harass.AddGroupLabel("Auto-Harass");
            Harass.Add("harassToggle", new KeyBind("Enabled", false, KeyBind.BindTypes.PressToggle, 'T'));

            Harass.AddGroupLabel("Mystic Shot");
            Harass.Add("Q", new CheckBox("Use"));

            Harass.AddGroupLabel("Essence Flux");
            Harass.Add("W", new CheckBox("Use"));

            Harass.AddSeparator();

            foreach (var enemy in EntityManager.Heroes.Enemies)
                Harass.Add(enemy.BaseSkinName, new CheckBox(enemy.BaseSkinName, Priorities.Contains(enemy.BaseSkinName)));

            Harass.AddSeparator();
            Harass.Add("Mana", new Slider("Minimum Mana", 30));

            //Lasthit Menu
            Lasthit = Settings.AddSubMenu("Lasthit", "LasthitMenu");

            Lasthit.AddGroupLabel("Mystic Shot");
            Lasthit.Add("Q", new CheckBox("Use"));

            Lasthit.AddSeparator();
            Lasthit.Add("Mana", new Slider("Minimum Mana", 30));

            //LaneClear Menu
            LaneClear = Settings.AddSubMenu("LaneClear", "LaneClearMenu");

            LaneClear.AddGroupLabel("Mystic Shot");
            LaneClear.Add("Q", new CheckBox("Use"));

            LaneClear.AddSeparator();
            LaneClear.Add("Mana", new Slider("Minimum Mana", 30));

            //JungleClear Menu
            JungleClear = Settings.AddSubMenu("JungleClear", "JungleClearMenu");

            JungleClear.AddGroupLabel("Mystic Shot");
            JungleClear.Add("Q", new CheckBox("Use"));

            JungleClear.AddSeparator();
            JungleClear.Add("Mana", new Slider("Minimum Mana", 30));

            //Killsteal Menu
            Killsteal = Settings.AddSubMenu("Killsteal", "KillstealMenu");

            Killsteal.AddGroupLabel("Mystic Shot");
            Killsteal.Add("Q", new CheckBox("Enabled"));

            Killsteal.AddGroupLabel("Essence Flux");
            Killsteal.Add("W", new CheckBox("Enabled"));

            Killsteal.AddGroupLabel("Trueshot Barrage");
            Killsteal.Add("R", new CheckBox("Enabled"));

            //Drawing Menu
            Drawing = Settings.AddSubMenu("Drawing", "DrawingMenu");

            Drawing.AddGroupLabel("Mystic Shot");
            Drawing.Add("Q", new CheckBox("Enabled"));

            Drawing.AddGroupLabel("Essence Flux");
            Drawing.Add("W", new CheckBox("Enabled"));

            Drawing.AddGroupLabel("Arcane Shift");
            Drawing.Add("E", new CheckBox("Enabled"));

            Drawing.AddGroupLabel("Trueshot Barrage");
            Drawing.Add("R", new CheckBox("Enabled"));

            Drawing.AddSeparator();
            Drawing.AddGroupLabel("Options");
            Drawing.Add("ready", new CheckBox("Draw only if spell is ready?"));

            //Items Menu
            Items = Settings.AddSubMenu("Items", "ItemsMenu");

            Items.AddGroupLabel("Offensive");
            Items.Add("botrk", new CheckBox("Use Blade of the Ruined King/Bilgewater"));
            Items.Add("botrkHealth", new Slider("Minimum health", 65));
            Items.Add("youmuu", new CheckBox("Use Youmuu's Ghostblade"));

            Items.AddGroupLabel("Defensive");
            Items.Add("qss", new CheckBox("Use Quicksilver Sash/Mercurial Scimitar", false));

            //Misc Menu
            Misc = Settings.AddSubMenu("Miscellaneous", "MiscMenu");

            Misc.AddGroupLabel("Skinchanger");
            Misc.Add("_skinChanger", new CheckBox("Enabled"));
            Misc.Add("skinID",
                new ComboBox("Current skin", 0, "Default", "Nottingham", "Striker", "Frosted", "Explorer", "Pulsefire",
                    "TPA", "Debonair", "Ace of Spades", "Arcade", "Debonair: Brown", "Debonair: White",
                    "Debonair: Orange", "Debonair: Black", "Debonair: Blue", "Debonair: Red", "Debonair: Pink",
                    "Debonair: Purple"));

            Misc.AddGroupLabel("Hitchance");
            Misc.Add("_hitchance", new ComboBox("Choose your hitchance", 2, "Low", "Medium", "High"));

            Misc.AddGroupLabel("Tear stacking");
            Misc.Add("tearStacking", new KeyBind("Enabled", true, KeyBind.BindTypes.PressToggle, 'K'));

            Misc.AddGroupLabel("Others");
            Misc.Add("pushing_w", new CheckBox("Use W on allies while pushing turrets"));
        }
    }
}