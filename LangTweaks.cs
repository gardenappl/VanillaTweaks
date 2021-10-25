
using System;
using System.Collections.Generic;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

using static Terraria.ModLoader.ModContent;

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
			if (GetInstance<ClientConfig>().CobaltShieldRename)
			{
				Lang.GetItemName(ItemID.CobaltShield).Override = Language.GetText("Mods.VanillaTweaks.ItemName.CobaltShield");
			}
			if (GetInstance<ClientConfig>().SandstoneRename)
			{
				Lang.GetItemName(ItemID.SandstoneBrick).Override = Language.GetText("Mods.VanillaTweaks.ItemName.SandstoneBrick");
				Lang.GetItemName(ItemID.SandstoneBrickWall).Override = Language.GetText("Mods.VanillaTweaks.ItemName.SandstoneBrickWall");
				Lang.GetItemName(ItemID.SandstoneSlab).Override = Language.GetText("Mods.VanillaTweaks.ItemName.SandstoneSlab");
				if (VanillaTweaks.MiscellaniaLoaded)
				{
					ModLoader.TryGetMod("GoldensMisc", out Mod MiscellaniaMod);
					bool FoundWall = MiscellaniaMod.TryFind<ModItem>("SandstoneSlabWall", out ModItem SandstoneSlabWall);
					if (FoundWall)
						Lang.GetItemName(SandstoneSlabWall.Type).Override = Language.GetText("Mods.VanillaTweaks.ItemName.SandstoneSlabWall");
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
				
			if (GetInstance<ServerConfig>().ObsidianArmorTweak)
			{
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.ObsidianArmor", ItemID.ObsidianHelm);
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.ObsidianArmor", ItemID.ObsidianShirt);
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.ObsidianArmor", ItemID.ObsidianPants);
			}
			if (GetInstance<ServerConfig>().SwatHelmetTweak)
			{
				if (VanillaTweaks.reinforcedVestModItem != null)
					ReplaceTooltip(tooltips, "Mods.VanillaTweaks.MiscellaniaTooltip.SwatHelmet", ItemID.SWATHelmet);
				else
					ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.SwatHelmet", ItemID.SWATHelmet);
			}
			if (GetInstance<ServerConfig>().MeteorArmorDamageTweak)
			{
				ReplaceTooltip(tooltips, null, ItemID.MeteorHelmet);
				ReplaceTooltip(tooltips, null, ItemID.MeteorSuit);
				ReplaceTooltip(tooltips, null, ItemID.MeteorLeggings);
			}
			if (GetInstance<ServerConfig>().EskimoArmorTweak)
			{
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.Eskimo", ItemID.EskimoHood);
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.Eskimo", ItemID.EskimoCoat);
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.Eskimo", ItemID.EskimoPants);
			}
			if (GetInstance<ServerConfig>().PharaohSetTweak)
			{
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.Pharaoh", ItemID.PharaohsMask);
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.Pharaoh", ItemID.PharaohsRobe);
			}
			if (GetInstance<ServerConfig>().CrimsonArmorTweak)
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
