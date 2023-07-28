using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader.Config;

namespace VanillaTweaks
{
	public class ServerConfig : ModConfig
	{
		[JsonIgnore]
		public const string ConfigName = "Server";

		public override bool Autoload(ref string name)
		{
			name = ConfigName;
			return base.Autoload(ref name);
		}

		public override ConfigScope Mode => ConfigScope.ServerSide;

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
		{
			if (Main.netMode != NetmodeID.MultiplayerClient)
            {
				message = Language.GetTextValue("Mods.VanillaTweaks.Configs.ServerConfig.ServerBlocked");
				return false;
			}
			return true;
		}

		[ReloadRequired]
		[DefaultValue(true)]
		public bool MeteorArmorDamageTweak;

		[DefaultValue(true)]
		public bool MeteorArmorDefenseTweak;

		[ReloadRequired]
		[DefaultValue(true)]
		public bool SnowArmorTweak;

		[DefaultValue(true)]
		public bool SnowArmorDropTweak;

		[DefaultValue(true)]
		public bool RainArmorTweak;

		[ReloadRequired]
		[DefaultValue(true)]
		public bool PharaohSetTweak;

		[ReloadRequired]
		[DefaultValue(true)]
		public bool CrimsonArmorTweak;

		[ReloadRequired]
		[DefaultValue(true)]
		public bool SwatHelmetTweak;

		[DefaultValue(true)]
		public bool FishBowlTweak;

		[DefaultValue(true)]
		public bool VikingHelmetTweak;

		[DefaultValue(true)]
		public bool HammerTweaks;

		[DefaultValue(true)]
		public bool GoldCritterDropTweak;

		[DefaultValue(true)]
		public bool EasterEgg;

		[Range(1f, 5f)]
		[DefaultValue(5f)]
		public float ExtractSpeedMultiplier;

		[ReloadRequired]
		[Range(0, 50)]
		[DefaultValue(25)]
		public int JestersArrowCraft;

		[ReloadRequired]
		[Range(0, 100)]
		[DefaultValue(25f)]
		public int MolotovBlueGelCraft;

		[ReloadRequired]
		[DefaultValue(true)]
		//I'm not sure what would happen if the server and the client had mismatched recipe lists...
		//Putting this in the ServerConfig just in case.
		public bool CoinRecipesAtEndofList;
		
	}

	public class ClientConfig : ModConfig
	{
		[JsonIgnore]
		public const string ConfigName = "Client";

		public override bool Autoload(ref string name)
		{
			name = ConfigName;
			return base.Autoload(ref name);
		}

		public override ConfigScope Mode => ConfigScope.ClientSide;

		[ReloadRequired]
		[DefaultValue(true)]
		public bool CobaltShieldRename;

		[ReloadRequired]
		[DefaultValue(true)]
		public bool SandstoneRename;

		[DefaultValue(true)]
		public bool FavoriteTooltipRemove;

		[DefaultValue(true)]
		public bool SkullTweak;
	}
}
