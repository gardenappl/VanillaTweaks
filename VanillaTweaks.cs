
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaTweaks
{
	public class VanillaTweaks : Mod
	{
		public VanillaTweaks()
		{
			Properties = new ModProperties
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
		
//		public override void Load()
//		{
//			Main.tileSpelunker[TileID.ShadowOrbs] = true;
//			Main.tileValue[TileID.ShadowOrbs] = 510; //chest = 500 cobalt = 600
//		}
//		
//		public override void Unload() //Reverting changes
//		{	
//			Main.tileSpelunker[TileID.ShadowOrbs] = false;
//			Main.tileValue[TileID.ShadowOrbs] = 0;
//			Main.tileSetsLoaded[TileID.ShadowOrbs] = false;
//		}
	}
}
