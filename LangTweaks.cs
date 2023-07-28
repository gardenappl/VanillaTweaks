
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
				Line = line;
				ItemID = itemID;
			}
		}

		static List<ReplacedTooltipLine> ReplacedTooltips = new ();

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
				
			if (GetInstance<ServerConfig>().SwatHelmetTweak)
			{
				if (VanillaTweaks.Miscellania_ReinforcedVest != null)
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
			if (GetInstance<ServerConfig>().SnowArmorTweak)
			{
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.Snow", ItemID.EskimoHood);
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.Snow", ItemID.EskimoCoat);
				ReplaceTooltip(tooltips, "Mods.VanillaTweaks.ItemTooltip.Snow", ItemID.EskimoPants);
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
