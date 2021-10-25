
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
		public static bool MiscellaniaLoaded;
		public static Mod Miscellania;
		public static ModItem reinforcedVestModItem;

		public VanillaTweaks()
		{
			LegacyConfig.Load();
		}

		public override void Load()
		{
			MiscellaniaLoaded = ModLoader.TryGetMod("GoldensMisc", out Mod MiscellaniaMod);
			if (MiscellaniaLoaded == true)
            {
				Miscellania = MiscellaniaMod;
				bool foundVest;
				foundVest = MiscellaniaMod.TryFind<ModItem>("ReinforcedVest", out ModItem reinforcedVest);
				if (reinforcedVest != null)
				{
					reinforcedVestModItem = reinforcedVest;
				}
				else
				{
					reinforcedVestModItem = null;
				}
			}
			else
            {
				Miscellania = null; 
            }
			
			
			LangTweaks.EditTooltips();
            LanguageManager.Instance.OnLanguageChanged += LangTweaks.EditNames;
		}
		
		public override void AddRecipes()
		{
			LangTweaks.EditNames(LanguageManager.Instance);
			if (ModContent.GetInstance<ServerConfig>().MolotovBlueGelCraft > 0)
			{
				CreateRecipe(ItemID.MolotovCocktail, 5)
					.AddIngredient(ItemID.Ale, 5)
					.AddIngredient(ItemID.Torch, 1)
					.AddIngredient(ItemID.Silk, 1)
					.AddIngredient(ItemID.Gel, ModContent.GetInstance<ServerConfig>().MolotovBlueGelCraft)
					.Register();
			}
			RecipeTweaks.EditVanillaRecipes();
			
		}
		
		public override void PostAddRecipes()
		{
			if(ModContent.GetInstance<ServerConfig>().CoinRecipesAtEndofList)
				RecipeTweaks.TweakCoins();
		}

		public override void Unload()
		{
			Miscellania = null;
			reinforcedVestModItem = null;
			LangTweaks.ResetTooltips();
		}

		public static void Log(object message)
		{
			ModContent.GetInstance<VanillaTweaks>().Logger.Info(message);
		}

		public static void Log(string message, params object[] formatData)
		{
			ModContent.GetInstance<VanillaTweaks>().Logger.Info(string.Format(message, formatData));
		}
	}
}
