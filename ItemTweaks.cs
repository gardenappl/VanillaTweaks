
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

using static Terraria.ModLoader.ModContent;

namespace VanillaTweaks
{
	public class ItemTweaks : GlobalItem
	{
		const string SWATSet = "miscellania_swat";
		const string EskimoSet = "miscellania_eskimo";
		const string VikingSet = "miscellania_viking";
		const string PharaohSet = "miscellania_pharaoh";

		public override void SetDefaults(Item item)
		{

			if (GetInstance<ClientConfig>().SandstoneRename)
			{
				if (VanillaTweaks.Miscellania != null && VanillaTweaks.Miscellania_SandstoneSlabWall != null && item.type == VanillaTweaks.Miscellania_SandstoneSlabWall.Item.type)
				{
					item.SetNameOverride(Language.GetTextValue("Mods.VanillaTweaks.Items.SandstoneSlabWall.DisplayName"));
				}
			}

			switch (item.type)
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
					if(GetInstance<ServerConfig>().SnowArmorTweak)
					{
						item.defense = 3;
						item.rare = ItemRarityID.Blue;
					}
					return;
				case ItemID.EskimoCoat:
				case ItemID.PinkEskimoCoat:
					if(GetInstance<ServerConfig>().SnowArmorTweak)
					{
						item.defense = 4;
						item.rare = ItemRarityID.Blue;
					}
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
				case ItemID.GoldGoldfishBowl:
					if (GetInstance<ServerConfig>().FishBowlTweak)
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
				case ItemID.CobaltShield:
					if (GetInstance<ClientConfig>().CobaltShieldRename)
					{
						item.SetNameOverride(Language.GetTextValue("Mods.VanillaTweaks.Items.CobaltShield.DisplayName"));
					}
					return;
				case ItemID.SandstoneBrick:
					if (GetInstance<ClientConfig>().SandstoneRename)
					{
						item.SetNameOverride(Language.GetTextValue("Mods.VanillaTweaks.Items.SandstoneBrick.DisplayName"));
					}
					return;
				case ItemID.SandstoneBrickWall:
					if (GetInstance<ClientConfig>().SandstoneRename)
					{
						item.SetNameOverride(Language.GetTextValue("Mods.VanillaTweaks.Items.SandstoneBrickWall.DisplayName"));
					}
					return;
				case ItemID.SandstoneSlab:
					if (GetInstance<ClientConfig>().SandstoneRename)
					{
						item.SetNameOverride(Language.GetTextValue("Mods.VanillaTweaks.Items.SandstoneSlab.DisplayName"));
					}
					return;
			}
		}

        public override void UpdateEquip(Item item, Player player)
		{
			switch(item.type)
			{
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
					if(GetInstance<ServerConfig>().SnowArmorTweak)
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
			
			if(head.type == ItemID.SWATHelmet && VanillaTweaks.Miscellania_ReinforcedVest != null)
			{
				int reinforcedVest = VanillaTweaks.Miscellania_ReinforcedVest.Type;
				if(body.type == reinforcedVest)
					return SWATSet;
			}
			
			if((head.type == ItemID.EskimoHood || head.type == ItemID.PinkEskimoHood) &&
			   (body.type == ItemID.EskimoCoat || body.type == ItemID.PinkEskimoCoat) &&
			   (legs.type == ItemID.EskimoPants || legs.type == ItemID.PinkEskimoPants))
				return EskimoSet;
			
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

			if(armorSet == SWATSet && GetInstance<ServerConfig>().SwatHelmetTweak)
			{
				player.setBonus = Language.GetTextValue("Mods.VanillaTweaks.ArmorSet.Swat");
				player.endurance += 0.25f;
				player.GetDamage(DamageClass.Ranged) += 0.05f;
				player.ammoCost80 = true;
			}
			else if(armorSet == EskimoSet && GetInstance<ServerConfig>().SnowArmorTweak)
			{
				player.setBonus = Language.GetTextValue("Mods.VanillaTweaks.ArmorSet.Snow");
				player.statDefense += 4;
				player.resistCold = true;
				player.buffImmune[BuffID.Chilled] = true;
				player.buffImmune[BuffID.Frozen] = true;
				player.buffImmune[BuffID.Frostburn] = true;
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
		
		public override bool PreDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			if(ShouldFlip(item))
			{
				Texture2D texture = TextureAssets.Item[item.type].Value;
				DrawAnimation drawAnimation = Main.itemAnimations[item.type];
				Rectangle currentFrame = (drawAnimation == null) ? texture.Frame(1, 1, 0, 0, 0, 0) : drawAnimation.GetFrame(texture, -1);
				spriteBatch.Draw(texture, position, currentFrame, drawColor, 0f, origin, scale, SpriteEffects.FlipHorizontally, 0f);
				return false;
			}
			return true;
		}
		
		public override bool PreDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
		{
			if(ShouldFlip(item))
            {
                Texture2D texture = TextureAssets.Item[item.type].Value;
				DrawAnimation drawAnimation = Main.itemAnimations[item.type];
				Rectangle currentFrame = (drawAnimation == null) ? texture.Frame(1, 1, 0, 0, 0, 0) : Main.itemAnimations[item.type].GetFrame(texture, Main.itemFrameCounter[item.whoAmI]);
				spriteBatch.Draw(texture, item.position - Main.screenPosition, currentFrame, alphaColor, rotation, Vector2.Zero, scale, SpriteEffects.FlipHorizontally, 0f);
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
				tooltips.RemoveAll(line => line.Mod == "Terraria" && line.Name.StartsWith("Favorite"));
			switch (item.type)
			{
				case ItemID.EskimoHood:
				case ItemID.EskimoCoat:
				case ItemID.EskimoPants:
				case ItemID.PinkEskimoHood:
				case ItemID.PinkEskimoCoat:
				case ItemID.PinkEskimoPants:
					if(GetInstance<ServerConfig>().SnowArmorTweak && !Main.expertMode)
						tooltips.RemoveAll(line => line.Mod == "Terraria" && line.Name.StartsWith("Tooltip"));
					return;
			}
		}
	}
}
