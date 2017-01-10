
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace VanillaTweaks
{
	public class ItemTweaks : GlobalItem
	{
		const string GladiatorSet = "gladiator";
		const string ObsidianSet = "obsidian";
		const string RainSet = "rain";
		
		public override void SetDefaults(Item item)
		{
			switch(item.type)
			{
				case ItemID.MeteorHamaxe:
					if(Config.HammerTweaks)
					{
						item.hammer = 50;
						item.axe = 70 / 5; //For some reason Terraria multiplies axe power by 5. Don't ask me why.
					}
					return;
				case ItemID.MoltenHamaxe:
					if(Config.HammerTweaks)
					{
						item.axe = 80 / 5;
					}
					return;
				case ItemID.TheBreaker:
				case ItemID.FleshGrinder:
					if(Config.HammerTweaks)
					{
						item.hammer = 65;
					}
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
					{
						item.rare = 1;
						AddTooltip(item, "3% increased ranged critical strike chance");
					}
					return;
				case ItemID.MeteorHelmet:
					if(Config.MeteorArmorTweak)
					{
						item.toolTip = string.Empty;
						item.defense = 4;
					}
					return;
				case ItemID.MeteorSuit:
					if(Config.MeteorArmorTweak)
					{
						item.toolTip = string.Empty;
						item.defense = 5;
					}
					return;
				case ItemID.MeteorLeggings:
					if(Config.MeteorArmorTweak)
					{
						item.toolTip = string.Empty;
						item.defense = 4;
					}
					return;
				case ItemID.NightsEdge:
					if(Config.NightsEdgeAutoswing)
					{
						item.autoReuse = true;
					}
					return;
				case ItemID.TrueExcalibur:
				case ItemID.TrueNightsEdge:
					if(Config.TrueSwordsAutoswing)
					{
						item.autoReuse = true;
					}
					return;
				case ItemID.SandstoneBrick:
					if(Config.SandstoneRename)
					{
						item.name = "Sand Brick";
					}
					return;
				case ItemID.SandstoneBrickWall:
					if(Config.SandstoneRename)
					{
						item.name = "Sand Brick Wall";
					}
					return;
				case ItemID.SandstoneSlab:
					if(Config.SandstoneRename)
					{
						item.name = "Sand Slab";
					}
					return;
				case ItemID.CobaltShield:
					if(Config.CobaltShieldRename)
					{
						item.name = "Guardian's Shield";
					}
					return;
				case ItemID.SWATHelmet:
					if(Config.SwatHelmetTweak)
					{
						item.vanity = false;
						item.rare = 8;
						item.defense = 14;
						AddTooltip(item, "15% increased ranged damage");
						AddTooltip(item, "5% increased ranged critical strike chance");
					}
					return;
				case ItemID.Skull:
					if(Config.SkullTweak)
					{
						item.vanity = false;
						item.defense = 3;
					}
					return;
				case ItemID.FishBowl:
					if(Config.FishBowlTweak)
					{
						item.vanity = false;
						item.defense = 1;
					}
					return;
				case ItemID.WhoopieCushion:
					item.useTime = 5;
					item.useAnimation = 5;
					item.reuseDelay = 0;
					item.autoReuse = true;
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
					break;
				case ItemID.MeteorHelmet:
				case ItemID.MeteorSuit:
				case ItemID.MeteorLeggings:
					if(Config.MeteorArmorTweak)
						player.magicDamage /= 1.07f;
					break;
				case ItemID.SWATHelmet:
					if(Config.SwatHelmetTweak)
					{
						player.rangedCrit += 5;
						player.rangedDamage *= 1.15f;
					}
					break;
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
			return string.Empty;
		}
		
		public override void UpdateArmorSet(Player player, string armorSet)
		{
			if(armorSet == GladiatorSet && Config.GladiatorArmorTweak)
			{
				player.setBonus = "15% increased critical strike chance";
				player.meleeCrit += 15;
				player.rangedCrit += 15;
				player.magicCrit += 15;
				player.thrownCrit += 15;
				return;
			}
			if(armorSet == ObsidianSet && Config.ObsidianArmorTweak)
			{
				player.setBonus = "10% increased movement speed";
				player.moveSpeed *= 1.1f;
				return;
			}
			if(armorSet == RainSet && Config.RainArmorTweak)
			{
				player.setBonus = "1 defense";
				player.statDefense++;
				player.buffImmune[BuffID.Wet] = true;
				return;
			}
		}
		
		public override void ArmorSetShadows(Player player, string armorSet)
		{
			if(armorSet == ObsidianSet && Config.ObsidianArmorTweak)
				player.armorEffectDrawShadow = true;
		}
		
		public override bool PreDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			if(item.type == ItemID.Skull && Config.SkullTweak)
			{
				spriteBatch.Draw(Main.itemTexture[item.type], position, null, drawColor, 0f, origin, scale, SpriteEffects.FlipHorizontally, 0f);
				return false;
			}
			return true;
		}
		
		public override bool PreDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
		{
			if(item.type == ItemID.Skull && Config.SkullTweak)
			{
//				var origin = new Vector2(item.width * .5f, item.height * .5f);
				spriteBatch.Draw(Main.itemTexture[item.type], item.position - Main.screenPosition, null, lightColor.MultiplyRGB(alphaColor), rotation, Vector2.Zero, scale, SpriteEffects.FlipHorizontally, 0f);
				return false;
			}
			return true;
		}
	}
}
