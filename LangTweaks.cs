
using System;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace VanillaTweaks
{
	public static class LangTweaks
	{
		public static void EditNames(LanguageManager manager)
		{
			var bindFlags = BindingFlags.Instance | BindingFlags.NonPublic;
			var textValueMethod = typeof(LocalizedText).GetMethod("SetValue", bindFlags);
	
			if(Config.CobaltShieldRename)
			{
				textValueMethod.Invoke(Lang.GetItemName(ItemID.CobaltShield), new object[]{ Language.GetTextValue("Mods.GoldensMisc.ItemName.CobaltShield") });
			}
			if(Config.SandstoneRename && manager.ActiveCulture != GameCulture.Russian)
			{
				textValueMethod.Invoke(Lang.GetItemName(ItemID.SandstoneBrick), new object[]{ Language.GetTextValue("Mods.GoldensMisc.ItemName.SandstoneBrick") });
				textValueMethod.Invoke(Lang.GetItemName(ItemID.SandstoneBrickWall), new object[]{ Language.GetTextValue("Mods.GoldensMisc.ItemName.SandstoneBrickWall") });
				textValueMethod.Invoke(Lang.GetItemName(ItemID.SandstoneSlab), new object[]{ Language.GetTextValue("Mods.GoldensMisc.ItemName.SandstoneSlab") });
				if(VanillaTweaks.MiscellaniaLoaded)
				{
					int type = ModLoader.GetMod("GoldensMisc").ItemType("SandstoneSlabWall");
					if(type > 0)
						textValueMethod.Invoke(Lang.GetItemName(type), new object[]{ Language.GetTextValue("Mods.GoldensMisc.ItemName.SandstoneSlabWall") });
				}
			}
		}
		
		public static void EditTooltips(LanguageManager manager)
		{
			var bindFlags = BindingFlags.Static | BindingFlags.NonPublic;
			var tooltipsField = typeof(Lang).GetField("_itemTooltipCache", bindFlags);
			var tooltips = (ItemTooltip[])tooltipsField.GetValue(null);
			if(Config.ObsidianArmorTweak)
			{
				tooltips[ItemID.ObsidianHelm] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.ObsidianArmor");
				tooltips[ItemID.ObsidianShirt] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.ObsidianArmor");
				tooltips[ItemID.ObsidianPants] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.ObsidianArmor");
			}
			if(Config.MeteorArmorDamageTweak)
			{
				tooltips[ItemID.MeteorHelmet] = null;
				tooltips[ItemID.MeteorSuit] = null;
				tooltips[ItemID.MeteorLeggings] = null;
			}
			if(Config.EskimoArmorTweak)
			{
				tooltips[ItemID.EskimoHood] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.Eskimo");
				tooltips[ItemID.EskimoCoat] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.Eskimo");
				tooltips[ItemID.EskimoPants] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.Eskimo");
			}
			if(Config.PharaohSetTweak)
			{
				tooltips[ItemID.PharaohsMask] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.Pharaoh");
				tooltips[ItemID.PharaohsRobe] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.Pharaoh");
			}
		}
	}
}
