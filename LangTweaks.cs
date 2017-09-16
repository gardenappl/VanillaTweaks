﻿
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
		public static void AddText()
		{
			var mod = VanillaTweaks.Instance;
			var text = mod.CreateTranslation("ItemTooltip.ObsidianArmor");
			text.SetDefault("3% increased ranged critical strike chance");
			text.AddTranslation(GameCulture.Russian, "Увеличивает шанс крит. удара в дальнем бою на 3%");
			mod.AddTranslation(text);
			text = mod.CreateTranslation("ItemTooltip.SwatHelmet");
			text.SetDefault("15% increased ranged damage\n10% increased ranged critical strike chance");
			text.AddTranslation(GameCulture.Russian, "Увеличивает урон в дальнем бою на 15%\nУвеличивает шанс крит. удара в дальнем бою на 3%");
			mod.AddTranslation(text);
			text = mod.CreateTranslation("ItemTooltip.Eskimo");
			text.SetDefault("Allows touching cold water without freezing");
			text.AddTranslation(GameCulture.Russian, "Повзоляет прикасаться к холодной воде, не замерзая");
			mod.AddTranslation(text);
			text = mod.CreateTranslation("ItemTooltip.Pharaoh");
			text.SetDefault("Increases minion damage by 5%");
			text.AddTranslation(GameCulture.Russian, "Увеличивает урон питомцев на 5%"); //каких нахуй питомцев?
			mod.AddTranslation(text);
			
			text = mod.CreateTranslation("ArmorSet.Obsidian");
			text.SetDefault("10% increased movement speed");
			text.AddTranslation(GameCulture.Russian, "Увеличивает скорость движения на 10%");
			mod.AddTranslation(text);
			text = mod.CreateTranslation("ArmorSet.Gladiator");
			text.SetDefault("15% increased critical strike chance");
			text.AddTranslation(GameCulture.Russian, "Увеличивает шанс крит. удара на 15%");
			mod.AddTranslation(text);
			text = mod.CreateTranslation("ArmorSet.Rain");
			text.SetDefault("1 defense\nGrants immunity to Water Guns");
			text.AddTranslation(GameCulture.Russian, "1 ед. защиты\nДаёт невосприимчивость к Водяному пистолету");
			mod.AddTranslation(text);
			text = mod.CreateTranslation("ArmorSet.Swat");
			text.SetDefault("Reduces damage taken by 25%\n20% increased ranged damage and chance not to consume ammo");
			text.AddTranslation(GameCulture.Russian, "Получаемый урон снижен на 25%\nУвеличивает урон в дальнем бою на 20%\nШанс 20 % не потратить боеприпасы");
			mod.AddTranslation(text);
			text = mod.CreateTranslation("ArmorSet.Eskimo");
			text.SetDefault("4 defense\nProvides warmth and immunity to chill, frostburn and freezing effects");
			text.AddTranslation(GameCulture.Russian, "4 ед. защиты\nДаёт тепло и защищает от замораживающих эффектов и ледяного ожога");
			mod.AddTranslation(text);
			text = mod.CreateTranslation("ArmorSet.Viking");
			text.SetDefault("5% increased damage");
			text.AddTranslation(GameCulture.Russian, "Увеличивает урон в ближнем бою на 5%");
			mod.AddTranslation(text);
			text = mod.CreateTranslation("ArmorSet.Cactus");
			text.SetDefault("Attackers also take damage");
			text.AddTranslation(GameCulture.Russian, "Атакующие тоже получают урон");
			mod.AddTranslation(text);
			text = mod.CreateTranslation("ArmorSet.Pharaoh");
			text.SetDefault("Increases your max number of minions");
			text.AddTranslation(GameCulture.Russian, "Увеличивает ваше максимальное количество питомцев");
			mod.AddTranslation(text);
		}
		
		public static void EditNames(LanguageManager manager)
		{
			var bindFlags = BindingFlags.Instance | BindingFlags.NonPublic;
			var textValueMethod = typeof(LocalizedText).GetMethod("SetValue", bindFlags);
			
			/* Translation Start */
			if(manager.ActiveCulture == GameCulture.English)
			{
				if(Config.CobaltShieldRename)
				{
					textValueMethod.Invoke(Lang.GetItemName(ItemID.CobaltShield), new object[]{ "Guardian's Shield" });
				}
				if(Config.SandstoneRename)
				{
					textValueMethod.Invoke(Lang.GetItemName(ItemID.SandstoneBrick), new object[]{ "Sand Brick" });
					textValueMethod.Invoke(Lang.GetItemName(ItemID.SandstoneBrickWall), new object[]{ "Sand Brick Wall" });
					textValueMethod.Invoke(Lang.GetItemName(ItemID.SandstoneSlab), new object[]{ "Sand Slab" });
					if(VanillaTweaks.MiscellaniaLoaded)
					{
						int type = ModLoader.GetMod("GoldensMisc").ItemType("SandstoneSlabWall");
						if(type > 0)
							textValueMethod.Invoke(Lang.GetItemName(type), new object[]{ "Sand Slab Wall"});
					}
				}
			}
			else if(manager.ActiveCulture == GameCulture.Russian)
			{
				if(Config.CobaltShieldRename)
				{
					textValueMethod.Invoke(Lang.GetItemName(ItemID.CobaltShield), new object[]{ "Щит хранителя" });
				}
				//Sandstone stuff actually has correct names in Russian
			}
			/* Translation End */
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
