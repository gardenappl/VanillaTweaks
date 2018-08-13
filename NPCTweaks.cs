
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaTweaks
{
	public class NPCTweaks : GlobalNPC
	{
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
					if(Config.GoldCritterDropTweak)
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldCoin, 2);
					return;
				case NPCID.ZombieEskimo:
				case NPCID.ArmedZombieEskimo:
					if(Config.EskimoArmorDropTweak)
					{
						if(Main.rand.Next(Main.expertMode ? 5 : 10) == 0)
							Item.NewItem(npc.Hitbox, Utils.SelectRandom(Main.rand, ItemID.EskimoHood, ItemID.EskimoCoat, ItemID.EskimoPants));
					}
					return;
			}
		}
	}
}
