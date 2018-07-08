
using System;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace VanillaTweaks
{
	public class VanillaTweaks : Mod
	{
		public static VanillaTweaks Instance;
		public static bool MiscellaniaLoaded;
		public static bool FKtModSettingsLoaded;
		
		public override void Load()
		{
			Instance = this;
			MiscellaniaLoaded = ModLoader.GetMod("GoldensMisc") != null;
			FKtModSettingsLoaded = ModLoader.GetMod("FKTModSettings") != null;
			
			Config.Load();
			if(FKtModSettingsLoaded && !Main.dedServ)
				Config.LoadFKConfig();
			
			LanguageManager.Instance.OnLanguageChanged += LangTweaks.EditNames;
			LanguageManager.Instance.OnLanguageChanged += LangTweaks.EditTooltips;
		}
		
		public override void AddRecipes()
		{
			LangTweaks.EditNames(LanguageManager.Instance);
			LangTweaks.EditTooltips(LanguageManager.Instance);
			RecipeTweaks.EditVanillaRecipes();
		}
		
		public override void PostAddRecipes()
		{
			if(Config.CoinsTweak)
				RecipeTweaks.TweakCoins();
		}
		
		public override void PostUpdateInput()
		{
			if(FKtModSettingsLoaded && !Main.dedServ && !Main.gameMenu)
				Config.UpdateFKConfig();
		}
		
		public override void PreSaveAndQuit()
		{
			if(FKtModSettingsLoaded && !Main.dedServ)
				Config.SaveConfig();
		}
		
		public static void Log(string message, params object[] formatData)
		{
			ErrorLogger.Log(String.Format("[Vanilla Tweaks][{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), string.Format(message, formatData)));
		}

		#region Hamstar's Mod Helpers integration

		public static string GithubUserName { get { return "goldenapple3"; } }
		public static string GithubProjectName { get { return "VanillaTweaks"; } }

		public static string ConfigFileRelativePath { get { return "Mod Configs/Vanilla Tweaks.json"; } }

		public static void ReloadConfigFromFile()
		{
			Config.ReadConfig();
		}

		public static void ResetConfigFromDefaults()
		{
			Config.SetDefaults();
			Config.SaveConfig();
		}

		#endregion
	}
}
