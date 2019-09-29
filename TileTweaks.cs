
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaTweaks
{
	public class TileTweaks : GlobalTile
	{
		public override bool Drop(int i, int j, int type)
		{
			if(type == TileID.BoneBlock && ServerConfig.Instance.BoneBlockFix)
			{
				Item.NewItem(i * 16, j * 16, 16, 16, ItemID.Bone);
				return false;
			}
			return true;
		}
	}
}
