
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace VanillaTweaks.Items
{
	public class ItemTweaks : GlobalItem
	{
		const string GladiatorSet = "gladiator";
		const string ObsidianSet = "obsidian";
		
		public override void SetDefaults(Item item)
		{
			switch(item.type)
			{
				case ItemID.MeteorHamaxe:
					item.hammer = 50;
					item.axe = 70 / 5; //For some reason Terraria multiplies axe power by 5. Don't ask me why.
					break;
				case ItemID.MoltenHamaxe:
					item.axe = 80 / 5;
					break;
				case ItemID.TheBreaker:
				case ItemID.FleshGrinder:
					item.hammer = 65;
					break;
				case ItemID.GladiatorHelmet:
					item.rare = 1;
					item.defense = 5;
					break;
				case ItemID.GladiatorBreastplate:
					item.rare = 1;
					item.defense = 6;
					break;
				case ItemID.GladiatorLeggings:
					item.rare = 1;
					item.defense = 5;
					break;
				case ItemID.ObsidianHelm:
				case ItemID.ObsidianShirt:
				case ItemID.ObsidianPants:
					item.rare = 1;
					AddTooltip(item, "3% increased ranged critical strike chance");
					break;
				case ItemID.MeteorHelmet:
					item.toolTip = string.Empty;
					item.defense = 4;
					break;
				case ItemID.MeteorSuit:
					item.toolTip = string.Empty;
					item.defense = 5;
					break;
				case ItemID.MeteorLeggings:
					item.toolTip = string.Empty;
					item.defense = 4;
					break;
				case ItemID.TrueExcalibur:
				case ItemID.TrueNightsEdge:
				case ItemID.NightsEdge:
					item.autoReuse = true;
					break;
				case ItemID.SandstoneBrick:
					item.name = "Sand Brick";
					break;
				case ItemID.SandstoneBrickWall:
					item.name = "Sand Brick Wall";
					break;
				case ItemID.SandstoneSlab:
					item.name = "Sand Slab";
					break;
				case ItemID.CobaltShield:
					item.name = "Guardian's Shield";
					break;
				case ItemID.WhoopieCushion:
					item.useTime = 5;
					item.useAnimation = 5;
					item.reuseDelay = 0;
					item.autoReuse = true;
					break;
				case ItemID.Skull:
					item.vanity = false;
					item.defense = 3;
					break;
				case ItemID.SWATHelmet:
					item.vanity = false;
					item.rare = 8;
					item.defense = 14;
					AddTooltip(item, "15% increased ranged damage");
					AddTooltip(item, "5% increased ranged critical strike chance");
					break;
				case ItemID.FishBowl:
					item.vanity = false;
					item.defense = 1;
					break;
			}
		}
		
		public override void UpdateEquip(Item item, Player player)
		{
			switch(item.type)
			{
				case ItemID.ObsidianHelm:
				case ItemID.ObsidianShirt:
				case ItemID.ObsidianPants:
					player.rangedCrit += 3;
					break;
				case ItemID.MeteorHelmet:
				case ItemID.MeteorSuit:
				case ItemID.MeteorLeggings:
					player.magicDamage /= 1.07f;
					break;
				case ItemID.SWATHelmet:
					player.rangedCrit += 5;
					player.rangedDamage *= 1.15f;
					break;
			}
		}
		
		public override string IsArmorSet(Item head, Item body, Item legs)
		{
			if(head.type == ItemID.GladiatorHelmet && body.type == ItemID.GladiatorBreastplate && legs.type == ItemID.GladiatorLeggings)
				return GladiatorSet;
			if(head.type == ItemID.ObsidianHelm && body.type == ItemID.ObsidianShirt && legs.type == ItemID.ObsidianPants)
				return ObsidianSet;
			return string.Empty;
		}
		
		public override void UpdateArmorSet(Player player, string armorSet)
		{
			switch(armorSet)
			{
				case GladiatorSet:
					player.setBonus = "15% increased critical strike chance";
					player.meleeCrit += 15;
					player.rangedCrit += 15;
					player.magicCrit += 15;
					player.thrownCrit += 15;
					break;
				case ObsidianSet:
					player.setBonus = "10% increased movement speed";
					player.moveSpeed *= 1.1f;
					break;
			}
		}
		
		public override void ArmorSetShadows(Player player, string armorSet, ref bool longTrail, ref bool smallPulse, ref bool largePulse, ref bool shortTrail)
		{
			switch(armorSet)
			{
				case ObsidianSet:
					longTrail = true;
					break;
			}
		}
		
		public override bool PreDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			if(item.type == ItemID.Skull)
			{
				spriteBatch.Draw(Main.itemTexture[item.type], position, null, drawColor, 0f, origin, scale, SpriteEffects.FlipHorizontally, 0f);
				return false;
			}
			return true;
		}
		
		public override bool PreDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale)
		{
			if(item.type == ItemID.Skull)
			{
				spriteBatch.Draw(Main.itemTexture[item.type], item.position - Main.screenPosition, null, lightColor.MultiplyRGB(alphaColor), rotation, Vector2.Zero, scale, SpriteEffects.FlipHorizontally, 0f);
				return false;
			}
			return true;
		}
	}
}
