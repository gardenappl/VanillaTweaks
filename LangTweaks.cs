
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
			if(ClientConfig.Instance.CobaltShieldRename)
			{
				Lang.GetItemName(ItemID.CobaltShield).Override = Language.GetText("Mods.VanillaTweaks.ItemName.CobaltShield");
			}
			if(ClientConfig.Instance.SandstoneRename)
			{
				Lang.GetItemName(ItemID.SandstoneBrick).Override = Language.GetText("Mods.VanillaTweaks.ItemName.SandstoneBrick");
				Lang.GetItemName(ItemID.SandstoneBrickWall).Override = Language.GetText("Mods.VanillaTweaks.ItemName.SandstoneBrickWall");
				Lang.GetItemName(ItemID.SandstoneSlab).Override = Language.GetText("Mods.VanillaTweaks.ItemName.SandstoneSlab");
				if(VanillaTweaks.MiscellaniaLoaded)
				{
					int type = ModLoader.GetMod("GoldensMisc").ItemType("SandstoneSlabWall");
					if(type > 0)
						Lang.GetItemName(type).Override = Language.GetText("Mods.VanillaTweaks.ItemName.SandstoneSlabWall");
						//textValueMethod.Invoke(Lang.GetItemName(type), new object[]{ Language.GetTextValue("Mods.GoldensMisc.ItemName.SandstoneSlabWall") });
				}
			}
		}
		
		public static void EditTooltips(LanguageManager manager)
		{
			var bindFlags = BindingFlags.Static | BindingFlags.NonPublic;
			var tooltipsField = typeof(Lang).GetField("_itemTooltipCache", bindFlags);
			var tooltips = (ItemTooltip[])tooltipsField.GetValue(null);
			if(ServerConfig.Instance.ObsidianArmorTweak)
			{
				tooltips[ItemID.ObsidianHelm] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.ObsidianArmor");
				tooltips[ItemID.ObsidianShirt] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.ObsidianArmor");
				tooltips[ItemID.ObsidianPants] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.ObsidianArmor");
			}
			if(ServerConfig.Instance.SwatHelmetTweak)
			{
				if(VanillaTweaks.MiscellaniaLoaded && ModLoader.GetMod("GoldensMisc").ItemType("ReinforcedVest") > 0)
					tooltips[ItemID.SWATHelmet] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.MiscellaniaTooltip.SwatHelmet");
				else
					tooltips[ItemID.SWATHelmet] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.SwatHelmet");
			}
			if(ServerConfig.Instance.MeteorArmorDamageTweak)
			{
				tooltips[ItemID.MeteorHelmet] = ItemTooltip.None;
				tooltips[ItemID.MeteorSuit] = ItemTooltip.None;
				tooltips[ItemID.MeteorLeggings] = ItemTooltip.None;
			}
			if(ServerConfig.Instance.EskimoArmorTweak)
			{
				tooltips[ItemID.EskimoHood] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.Eskimo");
				tooltips[ItemID.EskimoCoat] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.Eskimo");
				tooltips[ItemID.EskimoPants] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.Eskimo");
			}
			if(ServerConfig.Instance.PharaohSetTweak)
			{
				tooltips[ItemID.PharaohsMask] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.Pharaoh");
				tooltips[ItemID.PharaohsRobe] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.Pharaoh");
			}
			if(ServerConfig.Instance.CrimsonArmorTweak)
			{
				tooltips[ItemID.CrimsonHelmet] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.Crimson");
				tooltips[ItemID.CrimsonScalemail] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.Crimson");
				tooltips[ItemID.CrimsonGreaves] = ItemTooltip.FromLanguageKey("Mods.VanillaTweaks.ItemTooltip.Crimson");
			}
		}
	}
}
