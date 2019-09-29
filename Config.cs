using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader.Config;

namespace VanillaTweaks
{
	[Label("$Mods.VanillaTweaks.Config.ServerConfig")]
	class ServerConfig : ModConfig
	{
		[JsonIgnore]
		public const string ConfigName = "Server";

		public override bool Autoload(ref string name)
		{
			name = ConfigName;
			return base.Autoload(ref name);
		}

		public override ConfigScope Mode => ConfigScope.ServerSide;

		public static ServerConfig Instance;

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
		{
			message = Language.GetTextValue("Mods.VanillaTweaks.Config.ServerBlocked");
			return false;
		}

		[Label("$Mods.VanillaTweaks.Config.GladiatorArmorTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.GladiatorArmorTweak.Desc")]
		[DefaultValue(true)]
		public bool GladiatorArmorTweak;

		[Label("$Mods.VanillaTweaks.Config.ObsidianArmorTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.ObsidianArmorTweak.Desc")]
		[DefaultValue(true)]
		public bool ObsidianArmorTweak;

		[Label("$Mods.VanillaTweaks.Config.MeteorArmorDamageTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.MeteorArmorDamageTweak.Desc")]
		[DefaultValue(true)]
		public bool MeteorArmorDamageTweak;

		[Label("$Mods.VanillaTweaks.Config.MeteorArmorDefenseTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.MeteorArmorDefenseTweak.Desc")]
		[DefaultValue(true)]
		public bool MeteorArmorDefenseTweak;

		[Label("$Mods.VanillaTweaks.Config.EskimoArmorTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.EskimoArmorTweak.Desc")]
		[DefaultValue(true)]
		public bool EskimoArmorTweak;

		[Label("$Mods.VanillaTweaks.Config.EskimoArmorDropTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.EskimoArmorDropTweak.Desc")]
		[DefaultValue(true)]
		public bool EskimoArmorDropTweak;

		[Label("$Mods.VanillaTweaks.Config.RainArmorTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.RainArmorTweak.Desc")]
		[DefaultValue(true)]
		public bool RainArmorTweak;

		[Label("$Mods.VanillaTweaks.Config.CactusArmorTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.CactusArmorTweak.Desc")]
		[DefaultValue(true)]
		public bool CactusArmorTweak;

		[Label("$Mods.VanillaTweaks.Config.PharaohSetTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.PharaohSetTweak.Desc")]
		[DefaultValue(true)]
		public bool PharaohSetTweak;

		[Label("$Mods.VanillaTweaks.Config.CrimsonArmorTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.CrimsonArmorTweak.Desc")]
		[DefaultValue(true)]
		public bool CrimsonArmorTweak;

		[Label("$Mods.VanillaTweaks.Config.SwatHelmetTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.SwatHelmetTweak.Desc")]
		[DefaultValue(true)]
		public bool SwatHelmetTweak;

		[Label("$Mods.VanillaTweaks.Config.FishBowlTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.FishBowlTweak.Desc")]
		[DefaultValue(true)]
		public bool FishBowlTweak;

		[Label("$Mods.VanillaTweaks.Config.VikingHelmetTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.VikingHelmetTweak.Desc")]
		[DefaultValue(true)]
		public bool VikingHelmetTweak;

		[Label("$Mods.VanillaTweaks.Config.HammerTweaks")]
		[Tooltip("$Mods.VanillaTweaks.Config.HammerTweaks.Desc")]
		[DefaultValue(true)]
		public bool HammerTweaks;

		[Label("$Mods.VanillaTweaks.Config.GoldCritterDropTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.GoldCritterDropTweak.Desc")]
		[DefaultValue(true)]
		public bool GoldCritterDropTweak;

		[Label("$Mods.VanillaTweaks.Config.UndeadMinerTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.UndeadMinerTweak.Desc")]
		[DefaultValue(true)]
		public bool UndeadMinerTweak;

		[Label("$Mods.VanillaTweaks.Config.UndeadMinerDropRateTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.UndeadMinerDropRateTweak.Desc")]
		[DefaultValue(true)]
		public bool UndeadMinerDropRateTweak;

		[Label("$Mods.VanillaTweaks.Config.WhoopieCushionTweak")]
		[DefaultValue(true)]
		public bool WhoopieCushionTweak;

		[Label("$Mods.VanillaTweaks.Config.FishingPoleTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.FishingPoleTweak.Desc")]
		[ReloadRequired]
		[DefaultValue(true)]
		public bool FishingPoleTweak;

		[Label("$Mods.VanillaTweaks.Config.BoneBlockFix")]
		[Tooltip("$Mods.VanillaTweaks.Config.BoneBlockFix.Desc")]
		[DefaultValue(true)]
		public bool BoneBlockFix;

		[Label("$Mods.VanillaTweaks.Config.ExtractSpeedMultiplier")]
		[Tooltip("$Mods.VanillaTweaks.Config.ExtractSpeedMultiplier.Desc")]
		[Range(1f, 5f)]
		[DefaultValue(5f)]
		public float ExtractSpeedMultiplier;

		[Label("$Mods.VanillaTweaks.Config.JestersArrowCraft")]
		[Tooltip("$Mods.VanillaTweaks.Config.JestersArrowCraft.Desc")]
		[ReloadRequired]
		[Range(0, 50)]
		[DefaultValue(50)]
		public int JestersArrowCraft;

		[Label("$Mods.VanillaTweaks.Config.MolotovCraft")]
		[Tooltip("$Mods.VanillaTweaks.Config.MolotovCraft.Desc")]
		[ReloadRequired]
		[Range(0, 100)]
		[DefaultValue(25f)]
		public int MolotovCraft;

		[Label("$Mods.VanillaTweaks.Config.CoinsTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.CoinsTweak.Desc")]
		[ReloadRequired]
		[DefaultValue(true)]
		//I'm not sure what would happen if the server and the client had mismatched recipe lists...
		//Putting this in the ServerConfig just in case.
		public bool CoinsTweak;
		
	}

	[Label("$Mods.VanillaTweaks.Config.ClientConfig")]
	class ClientConfig : ModConfig
	{
		[JsonIgnore]
		public const string ConfigName = "Client";

		public override bool Autoload(ref string name)
		{
			name = ConfigName;
			return base.Autoload(ref name);
		}

		public override ConfigScope Mode => ConfigScope.ClientSide;

		public static ClientConfig Instance;

		[Label("$Mods.VanillaTweaks.Config.CobaltShieldRename")]
		[Tooltip("$Mods.VanillaTweaks.Config.CobaltShieldRename.Desc")]
		[ReloadRequired]
		[DefaultValue(true)]
		public bool CobaltShieldRename;

		[Label("$Mods.VanillaTweaks.Config.SandstoneRename")]
		[Tooltip("$Mods.VanillaTweaks.Config.SandstoneRename.Desc")]
		[ReloadRequired]
		[DefaultValue(true)]
		public bool SandstoneRename;

		[Label("$Mods.VanillaTweaks.Config.FavoriteTooltipRemove")]
		[DefaultValue(true)]
		public bool FavoriteTooltipRemove;

		[Label("$Mods.VanillaTweaks.Config.SkullTweak")]
		[Tooltip("$Mods.VanillaTweaks.Config.SkullTweak.Desc")]
		[DefaultValue(true)]
		public bool SkullTweak;

		[Label("$Mods.VanillaTweaks.Config.NightsEdgeAutoswing")]
		[Tooltip("$Mods.VanillaTweaks.Config.NightsEdgeAutoswing.Desc")]
		[DefaultValue(true)]
		public bool NightsEdgeAutoswing;

		[Label("$Mods.VanillaTweaks.Config.TrueSwordsAutoswing")]
		[Tooltip("$Mods.VanillaTweaks.Config.TrueSwordsAutoswing.Desc")]
		[DefaultValue(true)]
		public bool TrueSwordsAutoswing;
	}
}
