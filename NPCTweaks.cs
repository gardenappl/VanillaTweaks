
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaTweaks
{
	public class NPCTweaks : GlobalNPC
	{
		public override void SetDefaults(NPC npc)
		{
			switch(npc.type)
			{
				case NPCID.UndeadMiner:
					if(ServerConfig.Instance.UndeadMinerTweak)
						npc.rarity = 1;
					break;
			}
		}

		public override void NPCLoot(NPC npc)
		{
			switch(npc.type)
			{
				case NPCID.GoldBird:
				case NPCID.GoldBunny:
				case NPCID.GoldButterfly:
				case NPCID.GoldFrog:
				case NPCID.GoldGrasshopper:
				case NPCID.GoldMouse:
				case NPCID.SquirrelGold: //Why Re-Logic why???
				case NPCID.GoldWorm:
					if(ServerConfig.Instance.GoldCritterDropTweak)
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldCoin, 2);
					break;
				case NPCID.ZombieEskimo:
				case NPCID.ArmedZombieEskimo:
					if(ServerConfig.Instance.EskimoArmorDropTweak && Main.rand.Next(Main.expertMode ? 5 : 10) == 0)
						Item.NewItem(npc.Hitbox, Utils.SelectRandom(Main.rand, ItemID.EskimoHood, ItemID.EskimoCoat, ItemID.EskimoPants));
					break;
				case NPCID.UndeadMiner:
					if(ServerConfig.Instance.UndeadMinerDropRateTweak && Main.rand.Next(Main.expertMode ? 3 : 4) == 0)
						Item.NewItem(npc.Hitbox, Utils.SelectRandom(Main.rand, ItemID.MiningShirt, ItemID.MiningPants));
					break;
			}
		}

		public override void SetupTravelShop(int[] shop, ref int nextSlot)
		{
			if(ServerConfig.Instance.FishingPoleTweak && !Main.hardMode)
			{
				for(int i = 0; i < shop.Length; i++)
				{
					if(shop[i] == ItemID.SittingDucksFishingRod)
					{
						for(int j = i + 1; j < shop.Length; j++)
						{
							shop[j - 1] = shop[j];
						}
						shop[shop.Length - 1] = 0;
						nextSlot--;
					}
				}
			}
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			switch(type)
			{
				case NPCID.Mechanic:
					if(ServerConfig.Instance.FishingPoleTweak && Main.hardMode && Main.moonPhase < 3 && NPC.AnyNPCs(NPCID.Angler))
					{
						bool mechRodFound = false;

						for(int i = 0; i < shop.item.Length; i++)
						{
							if(shop.item[i] != null && shop.item[i].type == ItemID.MechanicsRod)
							{
								mechRodFound = true;
								break;
							}
						}

						if(!mechRodFound)
						{
							shop.item[nextSlot].SetDefaults(ItemID.MechanicsRod);
							nextSlot++;
						}
					}
					break;
			}
		}
	}
}
