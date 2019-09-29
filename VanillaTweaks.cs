
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
		
		public VanillaTweaks()
		{
			LegacyConfig.Load();
		}

		public override void Load()
		{
			Instance = this;
			MiscellaniaLoaded = ModLoader.GetMod("GoldensMisc") != null;
			
			LanguageManager.Instance.OnLanguageChanged += LangTweaks.EditNames;
		}
		
		public override void AddRecipes()
		{
			LangTweaks.EditNames(LanguageManager.Instance);
			LangTweaks.EditTooltips();
			RecipeTweaks.EditVanillaRecipes();
		}
		
		public override void PostAddRecipes()
		{
			if(ServerConfig.Instance.CoinRecipesAtEndofList)
				RecipeTweaks.TweakCoins();
		}

		public override void Unload()
		{
			LangTweaks.ResetTooltips();
		}

		public static void Log(object message)
		{
			Instance.Logger.Info(message);
		}
		
		public static void Log(string message, params object[] formatData)
		{
			Instance.Logger.Info(string.Format(message, formatData));
		}
	}
}
