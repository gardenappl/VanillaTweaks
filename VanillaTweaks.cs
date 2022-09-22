
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
		public static Mod Miscellania;
		public static ModItem Miscellania_ReinforcedVest;
		public static ModItem Miscellania_SandstoneSlabWall;
		public VanillaTweaks()
		{
			LegacyConfig.Load();
		}

		public override void Load()
		{
			ModLoader.TryGetMod("GoldensMisc", out Miscellania);
			if (Miscellania != null)
			{
				Miscellania.TryFind<ModItem>("SandstoneSlabWall", out Miscellania_SandstoneSlabWall);
				Miscellania.TryFind<ModItem>("ReinforcedVest", out Miscellania_ReinforcedVest);
			}
			
			
			LangTweaks.EditTooltips();
            LanguageManager.Instance.OnLanguageChanged += LangTweaks.EditNames;
		}

		public override void Unload()
		{
			Miscellania = null;
			Miscellania_ReinforcedVest = null;
			Miscellania_SandstoneSlabWall = null;
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

	public class VanillaTweaksSystem : ModSystem
    {
		public override void AddRecipes()
		{
			LangTweaks.EditNames(LanguageManager.Instance);
			if (ModContent.GetInstance<ServerConfig>().MolotovBlueGelCraft > 0)
			{
				Recipe.Create(ItemID.MolotovCocktail, 5)
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
			if (ModContent.GetInstance<ServerConfig>().CoinRecipesAtEndofList)
				RecipeTweaks.TweakCoins();
		}
	}
}
