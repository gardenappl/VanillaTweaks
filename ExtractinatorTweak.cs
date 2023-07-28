using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.Linq;

using static Terraria.ModLoader.ModContent;

namespace VanillaTweaks
{
	//original code by Hulvdan, modified by goldenapple
	class ExtractinatorTweak : GlobalItem
	{
		struct ExtractableItem
		{
			public ExtractableItem(Item item)
			{
				UseTime = item.useTime;
				UseAnimation = item.useAnimation;
				Name = item.Name;
			}
			public int UseTime;
			public int UseAnimation;
			public string Name;
        }

        static readonly int[] VanillaExtractables = { 
			//Blocks
			ItemID.SiltBlock, ItemID.SlushBlock, ItemID.DesertFossil, 
			//Fishing Junk
			ItemID.OldShoe, ItemID.TinCan, ItemID.Seaweed,
            //Glowing Moss
			ItemID.KryptonMoss, ItemID.ArgonMoss, ItemID.LavaMoss, 
			ItemID.RainbowMoss, ItemID.XenonMoss, ItemID.VioletMoss
		};

        static Dictionary<int, ExtractableItem> ExtractItemsCache = new ();

		static void SpeedUpExtract(Item item)
		{
			Tile extractinatorTile;
			if(GetInstance<ServerConfig>().ExtractSpeedMultiplier == 1f)
				return;
			
			switch(Main.tile[Player.tileTargetX, Player.tileTargetY].TileType)
            {
				case TileID.Extractinator:
					extractinatorTile = Main.tile[Player.tileTargetX, Player.tileTargetY];
					break;
				case TileID.ChlorophyteExtractinator:
					extractinatorTile = Main.tile[Player.tileTargetX, Player.tileTargetY];
					break;
				default:
					return;
			}

			if(!ExtractItemsCache.ContainsKey(item.type) && IsExtractable(item, extractinatorTile))
				ExtractItemsCache.Add(item.type, new ExtractableItem(item));
			
			if(ExtractItemsCache.ContainsKey(item.type))
			{
				var extractItem = ExtractItemsCache[item.type];
				if (Main.tile[Player.tileTargetX, Player.tileTargetY].TileType == TileID.Extractinator)
				{
					//useTime must be 2 or higher or else items dissapear
					item.useTime = Math.Max(2, (int)(extractItem.UseTime / GetInstance<ServerConfig>().ExtractSpeedMultiplier));
					//useAnimation less than 4 looks really weird as there aren't enough frames
					item.useAnimation = Math.Max(6, (int)(extractItem.UseAnimation / GetInstance<ServerConfig>().ExtractSpeedMultiplier));
				}
				else
				{
					item.useTime = extractItem.UseTime;
					item.useAnimation = extractItem.UseAnimation;
				}
			}
		}
		
		public override bool CanUseItem(Item item, Player player)
		{
			SpeedUpExtract(item);
			return base.CanUseItem(item, player);
		}
		
		static bool IsExtractable(Item item, Tile tile)
		{
			if(VanillaExtractables.Contains(item.type))
				return true;
			
			int resultType = 0;
			int resultStack = 0;
			ItemLoader.ExtractinatorUse(ref resultType, ref resultStack, item.type, tile.TileType);
			return resultType != 0 || resultStack != 0;
		}
	}
}