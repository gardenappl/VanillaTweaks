
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
		
		public override void Load()
		{
			Instance = this;
			MiscellaniaLoaded = ModLoader.GetMod("GoldensMisc") != null;
			
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
			if(ClientConfig.Instance.CoinsTweak)
				RecipeTweaks.TweakCoins();
		}
		
		public override void PostUpdateInput()
		{

		}
		
		public override void PreSaveAndQuit()
		{
			
		}
		
		public static void Log(object message)
		{
			Instance.Logger.Info(message);
			//ErrorLogger.Log(String.Format("[Miscellania][{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), message));
		}
		
		public static void Log(string message, params object[] formatData)
		{
			Instance.Logger.Info(string.Format(message, formatData));
			//ErrorLogger.Log(String.Format("[Miscellania][{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), String.Format(message, formatData)));
		}

		#region Hamstar's Mod Helpers integration

		public static string GithubUserName { get { return "goldenapple3"; } }
		public static string GithubProjectName { get { return "VanillaTweaks"; } }

		public static string ConfigFileRelativePath { get { return "Mod Configs/Vanilla Tweaks.json"; } }

		#endregion
	}
}
