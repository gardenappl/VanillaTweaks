
using System;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

using static Terraria.ModLoader.ModContent;

namespace VanillaTweaks
{
	public class NPCTweaks : GlobalNPC
	{
		public override void SetDefaults(NPC npc)
		{
			switch(npc.type)
			{
				case NPCID.UndeadMiner:
					if(GetInstance<ServerConfig>().UndeadMinerRareLifeform)
						npc.rarity = 1;
					break;
			}
		}

		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
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
					if (GetInstance<ServerConfig>().GoldCritterDropTweak)
						npcLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 2, 2));
					break;
				case NPCID.ZombieEskimo:
				case NPCID.ArmedZombieEskimo:
					if (GetInstance<ServerConfig>().EskimoArmorDropTweak)
                    {
						int[] eskimoPool = new int[] { ItemID.EskimoCoat, ItemID.EskimoHood, ItemID.EskimoPants };
						npcLoot.Add(ItemDropRule.NormalvsExpertOneFromOptions(10, 5, eskimoPool));
					}
					break;
				case NPCID.UndeadMiner:
					if(GetInstance<ServerConfig>().UndeadMinerDrop)
					{
						int[] minerPool = new int[] { ItemID.MiningShirt, ItemID.MiningPants};
						npcLoot.Add(ItemDropRule.NormalvsExpertOneFromOptions(4, 3, minerPool));
					}
					break;
			}
		}

		public override void SetupTravelShop(int[] shop, ref int nextSlot)
		{
			if(GetInstance<ServerConfig>().FishingPoleTweaks && !Main.hardMode)
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
					if(GetInstance<ServerConfig>().FishingPoleTweaks && Main.hardMode && Main.moonPhase < 3 && NPC.AnyNPCs(NPCID.Angler))
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
