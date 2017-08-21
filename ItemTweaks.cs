
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.UI;

namespace VanillaTweaks
{
	public class ItemTweaks : GlobalItem
	{
		const string GladiatorSet = "miscellania_gladiator";
		const string ObsidianSet = "miscellania_obsidian";
		const string RainSet = "miscellania_rain";
		const string SWATSet = "miscellania_swat";
		const string EskimoSet = "miscellania_eskimo";
		const string CactusSet = "miscellania_cactus";
		const string VikingSet = "miscellania_viking";
		
		public override void SetDefaults(Item item)
		{
			switch(item.type)
			{
				case ItemID.MeteorHamaxe:
					if(Config.HammerTweaks)
					{
						item.hammer = 50;
						item.axe = 70 / 5;
					}
					return;
				case ItemID.MoltenHamaxe:
					if(Config.HammerTweaks)
						item.axe = 80 / 5;
					return;
				case ItemID.TheBreaker:
				case ItemID.FleshGrinder:
					if(Config.HammerTweaks)
						item.hammer = 65;
					return;
				case ItemID.GladiatorHelmet:
					if(Config.GladiatorArmorTweak)
					{
						item.rare = 1;
						item.defense = 5;
					}
					return;
				case ItemID.GladiatorBreastplate:
					if(Config.GladiatorArmorTweak)
					{
						item.rare = 1;
						item.defense = 6;
					}
					return;
				case ItemID.GladiatorLeggings:
					if(Config.GladiatorArmorTweak)
					{
						item.rare = 1;
						item.defense = 5;
					}
					return;
				case ItemID.ObsidianHelm:
				case ItemID.ObsidianShirt:
				case ItemID.ObsidianPants:
					if(Config.ObsidianArmorTweak)
						item.rare = 1;
					return;
				case ItemID.MeteorHelmet:
				case ItemID.MeteorLeggings:
					if(Config.MeteorArmorDefenseTweak)
						item.defense = 4;
					return;
				case ItemID.MeteorSuit:
					if(Config.MeteorArmorDefenseTweak)
						item.defense = 5;
					return;
				case ItemID.EskimoHood:
				case ItemID.EskimoPants:
				case ItemID.PinkEskimoHood:
				case ItemID.PinkEskimoPants:
					if(Config.EskimoArmorTweak)
					{
						item.defense = 3;
						item.rare = 1;
					}
					return;
				case ItemID.EskimoCoat:
				case ItemID.PinkEskimoCoat:
					if(Config.EskimoArmorTweak)
					{
						item.defense = 4;
						item.rare = 1;
					}
					return;
				case ItemID.CactusLeggings:
				case ItemID.CactusHelmet:
					if(Config.CactusArmorTweak)
					{
						item.defense = 1;
					}
					return;
				case ItemID.CactusBreastplate:
					if(Config.CactusArmorTweak)
					{
						item.defense = 2;
					}
					return;
				case ItemID.NightsEdge:
					if(Config.NightsEdgeAutoswing)
						item.autoReuse = true;
					return;
				case ItemID.TrueExcalibur:
				case ItemID.TrueNightsEdge:
					if(Config.TrueSwordsAutoswing)
						item.autoReuse = true;
					return;
				case ItemID.SWATHelmet:
					if(Config.SwatHelmetTweak)
					{
						item.vanity = false;
						item.rare = 8;
						item.defense = 17;
					}
					return;
//				case ItemID.Skull:
//					if(Config.SkullTweak)
//					{
//						item.vanity = false;
//						item.defense = 3;
//					}
//					return;
				case ItemID.FishBowl:
					if(Config.FishBowlTweak)
					{
						item.vanity = false;
						item.defense = 1;
					}
					return;
				case ItemID.WhoopieCushion:
					if(Config.WhoopieCushionTweak)
					{
					item.useTime = 5;
					item.useAnimation = 5;
					item.reuseDelay = 0;
					item.autoReuse = true;
					}
					return;
			}
		}
		
		public override void UpdateEquip(Item item, Player player)
		{
			switch(item.type)
			{
				case ItemID.ObsidianHelm:
				case ItemID.ObsidianShirt:
				case ItemID.ObsidianPants:
					if(Config.ObsidianArmorTweak)
						player.rangedCrit += 3;
					return;
				case ItemID.MeteorHelmet:
				case ItemID.MeteorSuit:
				case ItemID.MeteorLeggings:
					if(Config.MeteorArmorDamageTweak)
						player.magicDamage -= 0.07f;
					return;
				case ItemID.SWATHelmet:
					if(Config.SwatHelmetTweak)
					{
						player.rangedCrit += 10;
						player.rangedDamage += 0.15f;
					}
					return;
				case ItemID.EskimoHood:
				case ItemID.EskimoCoat:
				case ItemID.EskimoPants:
				case ItemID.PinkEskimoHood:
				case ItemID.PinkEskimoCoat:
				case ItemID.PinkEskimoPants:
					if(Config.EskimoArmorTweak)
						player.arcticDivingGear = true;
					return;
			}
		}
		
		public override string IsArmorSet(Item head, Item body, Item legs)
		{
			if(head.type == ItemID.GladiatorHelmet && body.type == ItemID.GladiatorBreastplate && legs.type == ItemID.GladiatorLeggings)
				return GladiatorSet;
			
			if(head.type == ItemID.ObsidianHelm && body.type == ItemID.ObsidianShirt && legs.type == ItemID.ObsidianPants)
				return ObsidianSet;
			
			if(head.type == ItemID.RainHat && body.type == ItemID.RainCoat)
				return RainSet;
			
			if(head.type == ItemID.SWATHelmet && VanillaTweaks.MiscellaniaLoaded)
			{
				int reinforcedVest = ModLoader.GetMod("GoldensMisc").ItemType("ReinforcedVest");
				if(reinforcedVest > 0 && body.type == reinforcedVest)
					return SWATSet;
			}
			if((head.type == ItemID.EskimoHood || head.type == ItemID.PinkEskimoHood) &&
			   (body.type == ItemID.EskimoCoat || body.type == ItemID.PinkEskimoCoat) && 
			   (legs.type == ItemID.EskimoPants || legs.type == ItemID.PinkEskimoPants))
				return EskimoSet;
			if(head.type == ItemID.CactusHelmet && body.type == ItemID.CactusBreastplate && legs.type == ItemID.CactusLeggings)
			{
				return CactusSet;
			}
			if(head.type == ItemID.VikingHelmet && 
			    (body.type == ItemID.IronChainmail || body.type == ItemID.LeadChainmail) && 
			    (legs.type == ItemID.IronGreaves || legs.type == ItemID.LeadGreaves))
				return VikingSet;

			return base.IsArmorSet(head, body, legs);
		}
		
		public override void UpdateArmorSet(Player player, string armorSet)
		{
			if(armorSet == GladiatorSet && Config.GladiatorArmorTweak)
			{
				player.setBonus = Language.GetTextValue("Mods.VanillaTweaks.ArmorSet.Gladiator");
				player.meleeCrit += 15;
				player.rangedCrit += 15;
				player.magicCrit += 15;
				player.thrownCrit += 15;
			}
			else if(armorSet == ObsidianSet && Config.ObsidianArmorTweak)
			{
				player.setBonus = Language.GetTextValue("Mods.VanillaTweaks.ArmorSet.Obsidian");
				player.moveSpeed += 0.1f;
			}
			else if(armorSet == RainSet && Config.RainArmorTweak)
			{
				player.setBonus = Language.GetTextValue("Mods.VanillaTweaks.ArmorSet.Rain");
				player.statDefense++;
				player.buffImmune[BuffID.Wet] = true;
			}
			else if(armorSet == SWATSet && Config.SwatHelmetTweak)
			{
				player.setBonus = Language.GetTextValue("Mods.VanillaTweaks.ArmorSet.Swat");
				player.endurance += 0.25f;
				player.rangedDamage += 0.2f;
				player.ammoCost80 = true;
			}
			else if(armorSet == EskimoSet && Config.EskimoArmorTweak)
			{
				player.setBonus = Language.GetTextValue("Mods.VanillaTweaks.ArmorSet.Eskimo");
				player.statDefense += 4;
				player.resistCold = true;
				player.buffImmune[BuffID.Chilled] = true;
				player.buffImmune[BuffID.Frozen] = true;
				player.buffImmune[BuffID.Frostburn] = true;
			}
			else if(armorSet == CactusSet && Config.CactusArmorTweak)
			{
				player.setBonus =  Language.GetTextValue("Mods.VanillaTweaks.ArmorSet.Cactus");
				player.thorns += 0.25f;
				player.statDefense--;
			}
			else if(armorSet == VikingSet && Config.VikingHelmetTweak)
			{
				player.setBonus =  Language.GetTextValue("Mods.VanillaTweaks.ArmorSet.Viking"); 
				player.rangedDamage *= 1.05f;
				player.meleeDamage *= 1.05f;
				player.thrownDamage *= 1.05f;
				player.minionDamage *= 1.05f;
				player.magicDamage *= 1.05f;
			}
		}
		
		public override void ArmorSetShadows(Player player, string armorSet)
		{
			if(armorSet == ObsidianSet && Config.ObsidianArmorTweak)
			{
				player.armorEffectDrawShadow = true;
			}
		}
		
		public override bool PreDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			if(ShouldFlip(item))
			{
				spriteBatch.Draw(Main.itemTexture[item.type], position, null, drawColor, 0f, origin, scale, SpriteEffects.FlipHorizontally, 0f);
				return false;
			}
			return true;
		}
		
		public override bool PreDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
		{
			if(ShouldFlip(item))
			{
				spriteBatch.Draw(Main.itemTexture[item.type], item.position - Main.screenPosition, null, lightColor.MultiplyRGB(alphaColor), rotation, Vector2.Zero, scale, SpriteEffects.FlipHorizontally, 0f);
				return false;
			}
			return true;
		}
		
		static bool ShouldFlip(Item item)
		{
			bool skull = item.type == ItemID.Skull && Config.SkullTweak;
			bool joke = DateTime.Now.Month == 4 && DateTime.Now.Day == 1;
			return (skull || joke) && !(skull && joke);
		}
		
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			if(Config.FavoriteTooltipRemove)
				tooltips.RemoveAll(line => line.mod == "Terraria" && line.Name.StartsWith("Favorite"));
			switch(item.type)
			{
				case ItemID.EskimoHood:
				case ItemID.EskimoCoat:
				case ItemID.EskimoPants:
				case ItemID.PinkEskimoHood:
				case ItemID.PinkEskimoCoat:
				case ItemID.PinkEskimoPants:
					if(Config.EskimoArmorTweak && !Main.expertMode)
						tooltips.RemoveAll(line => line.mod == "Terraria" && line.Name.StartsWith("Tooltip"));
					return;
			}
		}
	}
}
