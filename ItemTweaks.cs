﻿
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

using static Terraria.ModLoader.ModContent;

namespace VanillaTweaks
{
	public class ItemTweaks : GlobalItem
	{
		const string GladiatorSet = "miscellania_gladiator";
		const string ObsidianSet = "miscellania_obsidian";
		const string SWATSet = "miscellania_swat";
		const string EskimoSet = "miscellania_eskimo";
		const string CactusSet = "miscellania_cactus";
		const string VikingSet = "miscellania_viking";
		const string PharaohSet = "miscellania_pharaoh";
		
		public override void SetDefaults(Item item)
		{
			switch(item.type)
			{
				case ItemID.MeteorHamaxe:
					if(GetInstance<ServerConfig>().HammerTweaks)
					{
						item.hammer = 50;
						item.axe = 70 / 5;
					}
					return;
				case ItemID.MoltenHamaxe:
					if(GetInstance<ServerConfig>().HammerTweaks)
						item.axe = 80 / 5;
					return;
				case ItemID.TheBreaker:
				case ItemID.FleshGrinder:
					if(GetInstance<ServerConfig>().HammerTweaks)
						item.hammer = 65;
					return;
				case ItemID.GladiatorHelmet:
					if(GetInstance<ServerConfig>().GladiatorArmorTweak)
					{
						item.rare = ItemRarityID.Blue;
						item.defense = 5;
					}
					return;
				case ItemID.GladiatorBreastplate:
					if(GetInstance<ServerConfig>().GladiatorArmorTweak)
					{
						item.rare = ItemRarityID.Blue;
						item.defense = 6;
					}
					return;
				case ItemID.GladiatorLeggings:
					if(GetInstance<ServerConfig>().GladiatorArmorTweak)
					{
						item.rare = ItemRarityID.Blue;
						item.defense = 5;
					}
					return;
				case ItemID.ObsidianHelm:
				case ItemID.ObsidianShirt:
				case ItemID.ObsidianPants:
					if(GetInstance<ServerConfig>().ObsidianArmorTweak)
						item.rare = ItemRarityID.Blue;
					return;
				case ItemID.MeteorHelmet:
				case ItemID.MeteorLeggings:
					if(GetInstance<ServerConfig>().MeteorArmorDefenseTweak)
						item.defense = 4;
					return;
				case ItemID.MeteorSuit:
					if(GetInstance<ServerConfig>().MeteorArmorDefenseTweak)
						item.defense = 5;
					return;
				case ItemID.EskimoHood:
				case ItemID.EskimoPants:
				case ItemID.PinkEskimoHood:
				case ItemID.PinkEskimoPants:
					if(GetInstance<ServerConfig>().EskimoArmorTweak)
					{
						item.defense = 3;
						item.rare = ItemRarityID.Blue;
					}
					return;
				case ItemID.EskimoCoat:
				case ItemID.PinkEskimoCoat:
					if(GetInstance<ServerConfig>().EskimoArmorTweak)
					{
						item.defense = 4;
						item.rare = ItemRarityID.Blue;
					}
					return;
				case ItemID.CactusLeggings:
				case ItemID.CactusHelmet:
					if(GetInstance<ServerConfig>().CactusArmorTweak)
						item.defense = 1;
					return;
				case ItemID.CactusBreastplate:
					if(GetInstance<ServerConfig>().CactusArmorTweak)
						item.defense = 2;
					return;
				case ItemID.PharaohsMask:
					if(GetInstance<ServerConfig>().PharaohSetTweak)
					{
						item.vanity = false;
						item.defense = 3;
					}
					return;
				case ItemID.PharaohsRobe:
					if(GetInstance<ServerConfig>().PharaohSetTweak)
					{
						item.vanity = false;
						item.defense = 4;
					}
					return;
				case ItemID.NightsEdge:
					if(GetInstance<ClientConfig>().NightsEdgeAutoswing)
						item.autoReuse = true;
					else
						item.autoReuse = false;
					return;
				case ItemID.TrueExcalibur:
				case ItemID.TrueNightsEdge:
					if(GetInstance<ClientConfig>().TrueSwordsAutoswing)
						item.autoReuse = true;
					else
						item.autoReuse = false;
					return;
				case ItemID.SWATHelmet:
					if(GetInstance<ServerConfig>().SwatHelmetTweak)
					{
						item.vanity = false;
						item.rare = ItemRarityID.Yellow;
						item.defense = 17;
					}
					return;
//				case ItemID.Skull:
//					if(GetInstance<ServerConfig>().SkullTweak)
//					{
//						item.vanity = false;
//						item.defense = 3;
//					}
//					return;
				case ItemID.FishBowl:
					if(GetInstance<ServerConfig>().FishBowlTweak)
					{
						item.vanity = false;
						item.defense = 1;
					}
					return;
				case ItemID.WhoopieCushion:
					if(GetInstance<ServerConfig>().EasterEgg)
					{
						item.useTime = 5;
						item.useAnimation = 5;
						item.reuseDelay = 0;
						item.autoReuse = true;
					}
					return;
				case ItemID.RainHat:
				case ItemID.RainCoat:
					if(GetInstance<ServerConfig>().RainArmorTweak)
					{
						item.vanity = true;
						item.defense = 0;
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
					if(GetInstance<ServerConfig>().ObsidianArmorTweak)
						player.GetCritChance(DamageClass.Ranged) += 3;
					return;
				case ItemID.MeteorHelmet:
				case ItemID.MeteorSuit:
				case ItemID.MeteorLeggings:
					if(GetInstance<ServerConfig>().MeteorArmorDamageTweak)
						player.GetDamage(DamageClass.Magic) -= 0.09f;
					return;
				case ItemID.SWATHelmet:
					if(GetInstance<ServerConfig>().SwatHelmetTweak)
					{
						player.GetCritChance(DamageClass.Ranged) += 10;
						player.GetDamage(DamageClass.Ranged) += 0.15f;
					}
					return;
				case ItemID.EskimoHood:
				case ItemID.EskimoCoat:
				case ItemID.EskimoPants:
				case ItemID.PinkEskimoHood:
				case ItemID.PinkEskimoCoat:
				case ItemID.PinkEskimoPants:
					if(GetInstance<ServerConfig>().EskimoArmorTweak)
						player.arcticDivingGear = true;
					return;
				case ItemID.PharaohsMask:
				case ItemID.PharaohsRobe:
					if(GetInstance<ServerConfig>().PharaohSetTweak)
						player.GetDamage(DamageClass.Summon) += 0.05f;
					return;
				case ItemID.CrimsonHelmet:
				case ItemID.CrimsonScalemail:
				case ItemID.CrimsonGreaves:
					if(GetInstance<ServerConfig>().CrimsonArmorTweak)
					{
						player.GetDamage(DamageClass.Melee) += 0.04f;
						player.GetDamage(DamageClass.Generic) -= 0.02f;
					}
					return;
			}
		}
		
		public override string IsArmorSet(Item head, Item body, Item legs)
		{
			if (head.type == ItemID.GladiatorHelmet && body.type == ItemID.GladiatorBreastplate && legs.type == ItemID.GladiatorLeggings)
				return GladiatorSet;
			
			if(head.type == ItemID.ObsidianHelm && body.type == ItemID.ObsidianShirt && legs.type == ItemID.ObsidianPants)
				return ObsidianSet;
			
			if(head.type == ItemID.SWATHelmet && VanillaTweaks.reinforcedVestModItem != null)
			{
				int reinforcedVest = VanillaTweaks.reinforcedVestModItem.Type;
				if(reinforcedVest > 0 && body.type == reinforcedVest)
					return SWATSet;
			}
			
			if((head.type == ItemID.EskimoHood || head.type == ItemID.PinkEskimoHood) &&
			   (body.type == ItemID.EskimoCoat || body.type == ItemID.PinkEskimoCoat) &&
			   (legs.type == ItemID.EskimoPants || legs.type == ItemID.PinkEskimoPants))
				return EskimoSet;
			
			if(head.type == ItemID.CactusHelmet && body.type == ItemID.CactusBreastplate && legs.type == ItemID.CactusLeggings)
				return CactusSet;
			
			if(head.type == ItemID.VikingHelmet &&
			  (body.type == ItemID.IronChainmail || body.type == ItemID.LeadChainmail) &&
			  (legs.type == ItemID.IronGreaves || legs.type == ItemID.LeadGreaves))
				return VikingSet;
			
			if(head.type == ItemID.PharaohsMask && body.type == ItemID.PharaohsRobe)
				return PharaohSet;

			return base.IsArmorSet(head, body, legs);
		}
		
		public override void UpdateArmorSet(Player player, string armorSet)
		{
			if(armorSet == GladiatorSet && GetInstance<ServerConfig>().GladiatorArmorTweak)
			{
				player.setBonus = Language.GetTextValue("Mods.VanillaTweaks.ArmorSet.Gladiator");
				player.GetCritChance(DamageClass.Generic) += 15;
				player.noKnockback = false;
			}
			else if(armorSet == ObsidianSet && GetInstance<ServerConfig>().ObsidianArmorTweak)
			{
				player.setBonus = Language.GetTextValue("Mods.VanillaTweaks.ArmorSet.Obsidian");
				player.moveSpeed += 0.1f;
				player.GetDamage(DamageClass.Summon) -= 0.15f;
				player.whipRangeMultiplier -= 0.5f;
				player.whipUseTimeMultiplier *= 0.74074f;
			}
			else if(armorSet == SWATSet && GetInstance<ServerConfig>().SwatHelmetTweak)
			{
				player.setBonus = Language.GetTextValue("Mods.VanillaTweaks.ArmorSet.Swat");
				player.endurance += 0.25f;
				player.GetDamage(DamageClass.Ranged) += 0.05f;
				player.ammoCost80 = true;
			}
			else if(armorSet == EskimoSet && GetInstance<ServerConfig>().EskimoArmorTweak)
			{
				player.setBonus = Language.GetTextValue("Mods.VanillaTweaks.ArmorSet.Eskimo");
				player.statDefense += 4;
				player.resistCold = true;
				player.buffImmune[BuffID.Chilled] = true;
				player.buffImmune[BuffID.Frozen] = true;
				player.buffImmune[BuffID.Frostburn] = true;
			}
			else if(armorSet == CactusSet && GetInstance<ServerConfig>().CactusArmorTweak)
			{
				player.setBonus = Language.GetTextValue("Mods.VanillaTweaks.ArmorSet.Cactus");
				player.thorns += 0.25f;
				player.cactusThorns = false;
			}
			else if(armorSet == VikingSet && GetInstance<ServerConfig>().VikingHelmetTweak)
			{
				player.setBonus = Language.GetTextValue("Mods.VanillaTweaks.ArmorSet.Viking");
				player.GetDamage(DamageClass.Generic) += 0.05f;
			}
			else if(armorSet == PharaohSet && GetInstance<ServerConfig>().PharaohSetTweak)
			{
				player.setBonus = Language.GetTextValue("Mods.VanillaTweaks.ArmorSet.Pharaoh");
				player.maxMinions++;
			}
		}
		
		public override void ArmorSetShadows(Player player, string armorSet)
		{
			if(armorSet == ObsidianSet && GetInstance<ServerConfig>().ObsidianArmorTweak)
				player.armorEffectDrawShadow = true;
		}
		
		public override bool PreDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			if(ShouldFlip(item))
			{
				spriteBatch.Draw(Terraria.GameContent.TextureAssets.Item[item.type].Value, position, null, drawColor, 0f, origin, scale, SpriteEffects.FlipHorizontally, 0f);
				return false;
			}
			return true;
		}
		
		public override bool PreDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
		{
			if(ShouldFlip(item))
			{
				spriteBatch.Draw(Terraria.GameContent.TextureAssets.Item[item.type].Value, item.position - Main.screenPosition, null, lightColor.MultiplyRGB(alphaColor), rotation, Vector2.Zero, scale, SpriteEffects.FlipHorizontally, 0f);
				return false;
			}
			return true;
		}
		
		static bool ShouldFlip(Item item)
		{
			bool skull = item.type == ItemID.Skull && GetInstance<ClientConfig>().SkullTweak;
			bool joke = DateTime.Now.Month == 4 && DateTime.Now.Day == 1;
			return (skull || joke) && !(skull && joke);
		}
		
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			if(GetInstance<ClientConfig>().FavoriteTooltipRemove)
				tooltips.RemoveAll(line => line.mod == "Terraria" && line.Name.StartsWith("Favorite"));
			switch(item.type)
			{
				case ItemID.EskimoHood:
				case ItemID.EskimoCoat:
				case ItemID.EskimoPants:
				case ItemID.PinkEskimoHood:
				case ItemID.PinkEskimoCoat:
				case ItemID.PinkEskimoPants:
					if(GetInstance<ServerConfig>().EskimoArmorTweak && !Main.expertMode)
						tooltips.RemoveAll(line => line.mod == "Terraria" && line.Name.StartsWith("Tooltip"));
					return;
			}
		}
	}
}
