
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
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldCoin, 2);
					}
					return;
				case NPCID.Drippler:
					if(Config.DripplerLensTweak)
					{
						for(int i = 0; i <= 6; i++)
						{
							if(Main.rand.Next(0,16) == 0)
							{
								Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Lens, 1);
							}
							else
							{
								if(Main.rand.Next(0,500) == 0)
								{
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackLens, 1);
								}
							}
						}
					}
					return;					
				case NPCID.WanderingEye:
					if(Config.WanderingEyeLensTweak)
					{
						if(Main.rand.Next(0,6) == 0)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Lens, 1);
						}
						else
						{
							if(Main.rand.Next(0,200) == 0)
							{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackLens, 1);
							}
						}
					}
					return;
			}
		}
	}
}
