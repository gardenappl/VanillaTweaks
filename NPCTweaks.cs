
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
				case NPCID.GoldDragonfly:
				case NPCID.GoldLadyBug:
				case NPCID.GoldWaterStrider:
				case NPCID.GoldSeahorse:
				case NPCID.GoldGoldfishWalker:
				case NPCID.GoldGoldfish:
					if (GetInstance<ServerConfig>().GoldCritterDropTweak)
						npcLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 2, 2));
					break;
				case NPCID.ZombieEskimo:
				case NPCID.ArmedZombieEskimo:
					if (GetInstance<ServerConfig>().SnowArmorDropTweak)
                    {
						int[] eskimoPool = new int[] { ItemID.EskimoCoat, ItemID.EskimoHood, ItemID.EskimoPants };
						npcLoot.Add(ItemDropRule.NormalvsExpertOneFromOptions(10, 5, eskimoPool));
					}
					break;
			}
		}

	}
}
