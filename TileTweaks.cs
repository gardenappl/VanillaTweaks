
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaTweaks
{
	public class TileTweaks : GlobalTile
	{
		public override bool Drop(int x, int y, int type)
		{
			if(type == TileID.BoneBlock && Config.BoneBlockFix)
			{
				Item.NewItem(x * 16, y * 16, 16, 16, ItemID.Bone);
				return false;
			}
			return true;
		}
	}
}
