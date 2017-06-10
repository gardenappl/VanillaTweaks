
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
		internal static bool MiscellaniaLoaded;
		
		public override void Load()
		{
			Config.Load();
			MiscellaniaLoaded = ModLoader.GetMod("GoldensMisc") != null;
			LanguageManager.Instance.OnLanguageChanged += LangTweaks.EditNames;
			LanguageManager.Instance.OnLanguageChanged += LangTweaks.EditTooltips;
			LangTweaks.EditNames(LanguageManager.Instance);
			LangTweaks.AddText(this);
		}
		
		public override void AddRecipes()
		{
			LangTweaks.EditTooltips(LanguageManager.Instance);
			RecipeTweaks.EditVanillaRecipes();
		}
		
		public override void PostAddRecipes()
		{
			RecipeTweaks.TweakCoins();
		}
		
		public static void Log(string message, params object[] formatData)
		{
			ErrorLogger.Log(String.Format("[Vanilla Tweaks][{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), string.Format(message, formatData)));
		}
	}
}
