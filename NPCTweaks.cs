
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
			switch (npc.type)
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
					npc.value = 10000f;
					break;
			}
		}


		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			switch(npc.type)
			{
				case NPCID.ZombieEskimo:
				case NPCID.ArmedZombieEskimo:
					if (GetInstance<ServerConfig>().SnowArmorDropTweak)
					{
						int[] eskimoOptions = new int[] { (int)ItemID.EskimoHood, (int)ItemID.EskimoCoat, (int)ItemID.EskimoPants };

						foreach (var rule in npcLoot.Get(false))
						{
							if (rule is OneFromOptionsDropRule drop)
                            {
								if (drop.dropIds[0] == eskimoOptions[0] &&
									drop.dropIds[1] == eskimoOptions[1] &&
									drop.dropIds[2] == eskimoOptions[2])
								{
									npcLoot.Remove(drop);
									var expertRule = new OneFromOptionsDropRule(5, 1, eskimoOptions);
									var normalRule = new OneFromOptionsDropRule(10, 1, eskimoOptions);
									var newDrop = new DropBasedOnExpertMode(normalRule, expertRule);
									npcLoot.Add(newDrop);
								}
							}
							
						}
					}
					break;
			}
		}

	}
}
