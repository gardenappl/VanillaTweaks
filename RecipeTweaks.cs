
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaTweaks
{
	public static class RecipeTweaks
	{
		public static void EditVanillaRecipes()
		{
			if(ServerConfig.Instance.MolotovCraft > 0)
			{
				var recipe = new ModRecipe(VanillaTweaks.Instance);
				recipe.AddIngredient(ItemID.Ale, 5);
				recipe.AddIngredient(ItemID.Torch, 1);
				recipe.AddIngredient(ItemID.Silk, 1);
				recipe.AddIngredient(ItemID.Gel, ServerConfig.Instance.MolotovCraft);
				recipe.SetResult(ItemID.MolotovCocktail, 5);
				recipe.AddRecipe();
			}

			var foundRecipes = new List<Recipe>();
			if(ServerConfig.Instance.JestersArrowCraft == 0)
			{
				foreach(var recipe in Main.recipe)
					if(recipe != null && recipe.createItem != null && recipe.createItem.type == ItemID.JestersArrow)
						foundRecipes.Add(recipe);
				
				foreach(var recipe in foundRecipes)
				{
					var editor = new RecipeEditor(recipe);
					editor.DeleteRecipe();
				}
				foundRecipes.Clear();
			}
			else
			{
				foreach(var recipe in Main.recipe)
				{
					if(recipe != null && recipe.createItem != null && recipe.createItem.type == ItemID.JestersArrow)
					{
						var editor = new RecipeEditor(recipe);
						editor.SetIngredientStack(ItemID.WoodenArrow, ServerConfig.Instance.JestersArrowCraft);
						editor.SetResult(ItemID.JestersArrow, ServerConfig.Instance.JestersArrowCraft);
					}
				}
			}
		}
		
		public static void TweakCoins()
		{
			int silverToCopper = -1;
			int goldToPlatinum = -1;
			for(int i = 0; i < Recipe.numRecipes; i++)
			{
				if(Main.recipe[i] == null || Main.recipe[i].createItem == null || Main.recipe[i].requiredItem == null || Main.recipe[i].requiredItem.Length == 0)
					continue;
				
				if(Main.recipe[i].createItem.type == ItemID.CopperCoin && Main.recipe[i].createItem.stack == 100 && Main.recipe[i].requiredItem[0].type == ItemID.SilverCoin)
				{
					silverToCopper = i;
					if(goldToPlatinum != -1)
						break;
				}
				else if(Main.recipe[i].createItem.type == ItemID.PlatinumCoin && Main.recipe[i].requiredItem[0].type == ItemID.GoldCoin && Main.recipe[i].requiredItem[0].stack == 100)
				{
					goldToPlatinum = i;
					if(silverToCopper != -1)
						break;
				}
			}
			int coinRecipesStart = silverToCopper < goldToPlatinum ? silverToCopper : goldToPlatinum;
			int coinRecipesEnd = goldToPlatinum > silverToCopper ? goldToPlatinum : silverToCopper;
//			VanillaTweaks.Log("Coin recipes start: {0}", coinRecipesStart);
//			VanillaTweaks.Log("Coin recipes end: {0}", coinRecipesEnd);
			if(coinRecipesStart == -1 || coinRecipesEnd == -1)
			{
				return;
			}
			//Adding existing coin recipes to a temporary cache
			var coinRecipes = new List<Recipe>();
			for(int i = coinRecipesStart; i <= coinRecipesEnd; i++)
			{
				coinRecipes.Add(Main.recipe[i]);
			}
			//Moving back all the recipes that come after them
			for(int i = coinRecipesEnd + 1; i < Recipe.numRecipes; i++)
			{
				Main.recipe[i - coinRecipes.Count] = Main.recipe[i];
			}
			//Putting the cached coin recipes at the end
			for(int i = 0; i < coinRecipes.Count; i++)
			{
				Main.recipe[Recipe.numRecipes - coinRecipes.Count + i] = coinRecipes[i];
			}
		}
	}
}
