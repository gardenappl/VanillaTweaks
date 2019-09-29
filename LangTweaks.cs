
using System;
using System.Collections.Generic;
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
		class ReplacedTooltipLine
		{
			public ItemTooltip Line;
			public short ItemID;

			public ReplacedTooltipLine(ItemTooltip line, short itemID)
			{
				this.Line = line;
				this.ItemID = itemID;
			}
		}

		static List<ReplacedTooltipLine> ReplacedTooltips = new List<ReplacedTooltipLine>();

		public static void EditNames(LanguageManager manager)
		{
			if (ClientConfig.Instance == null)
			{
				VanillaTweaks.Instance.Logger.Error("config is null"); //not sure why this happens, can't reproduce
				return;
			}
			if (ClientConfig.Instance.CobaltShieldRename)
			{
				Lang.GetItemName(ItemID.CobaltShield).Override = Language.GetText("Mods.VanillaTweaks.ItemName.CobaltShield");
			}
			if (ClientConfig.Instance.SandstoneRename)
			{
				Lang.GetItemName(ItemID.SandstoneBrick).Override = Language.GetText("Mods.VanillaTweaks.ItemName.SandstoneBrick");
				Lang.GetItemName(ItemID.SandstoneBrickWall).Override = Language.GetText("Mods.VanillaTweaks.ItemName.SandstoneBrickWall");
				Lang.GetItemName(ItemID.SandstoneSlab).Override = Language.GetText("Mods.VanillaTweaks.ItemName.SandstoneSlab");
				if (VanillaTweaks.MiscellaniaLoaded)
				{
					int type = ModLoader.GetMod("GoldensMisc").ItemType("SandstoneSlabWall");
					if (type > 0)
						Lang.GetItemName(type).Override = Language.GetText("Mods.VanillaTweaks.ItemName.SandstoneSlabWall");
					//textValueMethod.Invoke(Lang.GetItemName(type), new object[]{ Language.GetTextValue("Mods.GoldensMisc.ItemName.SandstoneSlabWall") });
				}
			}
		}

		static void ReplaceTooltip(ItemTooltip[] tooltipArray, string newTooltip, short itemID)
		{
			ReplacedTooltips.Add(new ReplacedTooltipLine(tooltipArray[itemID], itemID));
			if (newTooltip == null)
				tooltipArray[itemID] = ItemTooltip.None;
			else
				tooltipArray[itemID] = ItemTooltip.FromLanguageKey(newTooltip);
		}

		public static void EditTooltips()
		{
			var bindFlags = BindingFlags.Static | BindingFlags.NonPublic;
			var tooltipsField = typeof(Lang).GetField("_itemTooltipCache", bindFlags);
			var tooltips = (ItemTooltip[])tooltipsField.GetValue(null);
			if (ServerConfig.Instance.ObsidianArmorTweak)
			{
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.ObsidianArmor", ItemID.ObsidianHelm);
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.ObsidianArmor", ItemID.ObsidianShirt);
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.ObsidianArmor", ItemID.ObsidianPants);
			}
			if (ServerConfig.Instance.SwatHelmetTweak)
			{
				if (VanillaTweaks.MiscellaniaLoaded && ModLoader.GetMod("GoldensMisc").ItemType("ReinforcedVest") > 0)
					ReplaceTooltip(tooltips, "Mods.VanillaTweaks.MiscellaniaTooltip.SwatHelmet", ItemID.SWATHelmet);
				else
					ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.SwatHelmet", ItemID.SWATHelmet);
			}
			if (ServerConfig.Instance.MeteorArmorDamageTweak)
			{
				ReplaceTooltip(tooltips, null, ItemID.MeteorHelmet);
				ReplaceTooltip(tooltips, null, ItemID.MeteorSuit);
				ReplaceTooltip(tooltips, null, ItemID.MeteorLeggings);
			}
			if (ServerConfig.Instance.EskimoArmorTweak)
			{
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.Eskimo", ItemID.EskimoHood);
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.Eskimo", ItemID.EskimoCoat);
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.Eskimo", ItemID.EskimoPants);
			}
			if (ServerConfig.Instance.PharaohSetTweak)
			{
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.Pharaoh", ItemID.PharaohsMask);
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.Pharaoh", ItemID.PharaohsRobe);
			}
			if (ServerConfig.Instance.CrimsonArmorTweak)
			{
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.Crimson", ItemID.CrimsonHelmet);
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.Crimson", ItemID.CrimsonScalemail);
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.Crimson", ItemID.CrimsonGreaves);
			}
		}

		public static void ResetTooltips()
		{
			var bindFlags = BindingFlags.Static | BindingFlags.NonPublic;
			var tooltipsField = typeof(Lang).GetField("_itemTooltipCache", bindFlags);
			var tooltips = (ItemTooltip[])tooltipsField.GetValue(null);
			foreach (var tooltip in ReplacedTooltips)
			{
				tooltips[tooltip.ItemID] = tooltip.Line;
			}
			ReplacedTooltips.Clear();
		}
	}
}
