
using log4net;
using System;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace VanillaTweaks
{
	public static class LegacyConfig
	{
		static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "Vanilla Tweaks.json");
		static string OldConfigFolderPath = Path.Combine(Main.SavePath, "Mod Configs", "Vanilla Tweaks");
		static string OldConfigPath = Path.Combine(OldConfigFolderPath, "config.json");
		static string OldConfigVersionPath = Path.Combine(OldConfigFolderPath, "config.version");

		static readonly Preferences Settings = new Preferences(ConfigPath);

		static bool GladiatorArmorTweak = true;
		const string GladiatorArmorTweakKey = "GladiatorArmorTweak";

		static bool ObsidianArmorTweak = true;
		const string ObsidianArmorTweakKey = "ObsidianArmorTweak";

		static bool MeteorArmorDamageTweak = true;
		const string MeteorArmorDamageTweakKey = "MeteorArmorDamageTweak";

		static bool EskimoArmorTweak = true;
		const string EskimoArmorTweakKey = "EskimoArmorTweak";

		static bool EskimoArmorDropTweak = true;
		const string EskimoArmorDropTweakKey = "EskimoArmorDropTweak";

		static bool RainArmorTweak = true;
		const string RainArmorTweakKey = "RainArmorTweak";

		static bool HammerTweaks = true;
		const string HammerTweaksKey = "HammerTweaks";

		static bool NightsEdgeAutoswing = true;
		const string NightsEdgeAutoswingKey = "NightsEdgeAutoswing";

		static bool TrueSwordsAutoswing = true;
		const string TrueSwordsAutoswingKey = "TrueSwordsAutoswing";

		static bool SwatHelmetTweak = true;
		const string SwatHelmetTweakKey = "SwatHelmetTweak";

		static bool SkullTweak = true;
		const string SkullTweakKey = "SkullTweak";

		static bool FishBowlTweak = true;
		const string FishBowlTweakKey = "FishBowlTweak";

		static bool SandstoneRename = true;
		const string SandstoneRenameKey = "SandstoneRename";

		static bool CobaltShieldRename = true;
		const string CobaltShieldRenameKey = "CobaltShieldRename";

		static bool BoneBlockFix = true;
		const string BoneBlockFixKey = "BoneBlockFix";

		static bool GoldCritterDropTweak = true;
		const string GoldCritterDropTweakKey = "GoldCritterDropTweak";

		static float ExtractSpeedMultiplier = 5f;
		const string ExtractSpeedMultiplierKey = "ExtractSpeedMultiplier";

		static int JestersArrowCraft = 50;
		const string JestersArrowCraftKey = "JestersArrowCraft";

		static bool FavoriteTooltipRemove = true;
		const string FavoriteTooltipRemoveKey = "FavoriteTooltipRemove";

		static bool WhoopieCushionTweak = true;
		const string WhoopieCushionTweakKey = "EasterEgg";

		static bool CoinsTweak = true;
		const string CoinsTweakKey = "CoinRecipesAtEndofList";

		static int MolotovCraft = 25;
		const string MolotovTweakKey = "MolotovBlueGelCraft";

		static bool VikingHelmetTweak = true;
		const string VikingHelmetTweakKey = "VikingHelmetTweak";

		static bool CactusArmorTweak = true;
		const string CactusArmorTweakKey = "CactusArmorTweak";

		static bool MeteorArmorDefenseTweak = true;
		const string MeteorArmorDefenseTweakKey = "MeteorArmorDefenseTweak";

		static bool PharaohSetTweak = true;
		const string PharaohSetTweakKey = "PharaohSetTweak";

		static bool CrimsonArmorTweak = true;
		const string CrimsonArmorTweakKey = "CrimsonArmorTweak";

		static bool UndeadMinerTweak = true;
		const string UndeadMinerTweakKey = "UndeadMinerDrop";

		static bool FishingPoleTweak = true;
		const string FishingPoleTweakKey = "FishingPoleTweaks";

		//Make our own logger because it's too early in the mod load process to use VanillaTweaks.Instance
		static ILog Logger = LogManager.GetLogger("VanillaTweaksConfig");

		public static void Load()
		{
			if (Directory.Exists(OldConfigFolderPath))
			{
				if (File.Exists(OldConfigPath))
				{
					Logger.Warn("Found config file in old folder! Moving config...");
					File.Move(OldConfigPath, ConfigPath);
				}
				if (File.Exists(OldConfigVersionPath))
					File.Delete(OldConfigVersionPath);
				if (Directory.GetFiles(OldConfigFolderPath).Length == 0 && Directory.GetDirectories(OldConfigFolderPath).Length == 0)
					Directory.Delete(OldConfigFolderPath);
				else
					Logger.Warn("Old config folder still cotains some files/directories. They will not get deleted.");
			}

			if (!File.Exists(ConfigPath))
				return;

			if (!ReadConfig())
			{
				Logger.Warn("Failed to read legacy config file! Deleting...");
				File.Delete(ConfigPath);
				return;
			}
			MoveToNewFormat();
		}

		public static bool ReadConfig()
		{
			if (Settings.Load())
			{
				Settings.Get(GladiatorArmorTweakKey, ref GladiatorArmorTweak);
				Settings.Get(ObsidianArmorTweakKey, ref ObsidianArmorTweak);
				Settings.Get(MeteorArmorDefenseTweakKey, ref MeteorArmorDefenseTweak);
				Settings.Get(MeteorArmorDamageTweakKey, ref MeteorArmorDamageTweak);
				Settings.Get(EskimoArmorTweakKey, ref EskimoArmorTweak);
				Settings.Get(EskimoArmorDropTweakKey, ref EskimoArmorDropTweak);
				Settings.Get(RainArmorTweakKey, ref RainArmorTweak);
				Settings.Get(HammerTweaksKey, ref HammerTweaks);
				Settings.Get(NightsEdgeAutoswingKey, ref NightsEdgeAutoswing);
				Settings.Get(TrueSwordsAutoswingKey, ref TrueSwordsAutoswing);
				Settings.Get(SwatHelmetTweakKey, ref SwatHelmetTweak);
				Settings.Get(SkullTweakKey, ref SkullTweak);
				Settings.Get(FishBowlTweakKey, ref FishBowlTweak);
				Settings.Get(SandstoneRenameKey, ref SandstoneRename);
				Settings.Get(CobaltShieldRenameKey, ref CobaltShieldRename);
				Settings.Get(BoneBlockFixKey, ref BoneBlockFix);
				Settings.Get(GoldCritterDropTweakKey, ref GoldCritterDropTweak);
				Settings.Get("ExtractSpeedMulitplier", ref ExtractSpeedMultiplier); //bit of a typo there :P
				Settings.Get(ExtractSpeedMultiplierKey, ref ExtractSpeedMultiplier);
				Settings.Get(JestersArrowCraftKey, ref JestersArrowCraft);
				Settings.Get(FavoriteTooltipRemoveKey, ref FavoriteTooltipRemove);
				Settings.Get(VikingHelmetTweakKey, ref VikingHelmetTweak);
				Settings.Get(CactusArmorTweakKey, ref CactusArmorTweak);
				Settings.Get(MolotovTweakKey, ref MolotovCraft);
				Settings.Get(WhoopieCushionTweakKey, ref WhoopieCushionTweak);
				Settings.Get(CoinsTweakKey, ref CoinsTweak);
				Settings.Get(PharaohSetTweakKey, ref PharaohSetTweak);
				Settings.Get(CrimsonArmorTweakKey, ref CrimsonArmorTweak);
				Settings.Get(UndeadMinerTweakKey, ref UndeadMinerTweak);
				Settings.Get(FishingPoleTweakKey, ref FishingPoleTweak);
				return true;
			}
			return false;
		}

		static void MoveToNewFormat()
		{
			Logger.Warn("Migrating to new format...");

			var newConfigPathServer = Path.Combine(ConfigManager.ModConfigPath,
					nameof(VanillaTweaks) + '_' + ServerConfig.ConfigName + ".json");
			var newConfigServer = new Preferences(newConfigPathServer);
			newConfigServer.Put(GladiatorArmorTweakKey, GladiatorArmorTweak);
			newConfigServer.Put(ObsidianArmorTweakKey, ObsidianArmorTweak);
			newConfigServer.Put(MeteorArmorDefenseTweakKey, MeteorArmorDefenseTweak);
			newConfigServer.Put(MeteorArmorDamageTweakKey, MeteorArmorDamageTweak);
			newConfigServer.Put(EskimoArmorTweakKey, EskimoArmorTweak);
			newConfigServer.Put(EskimoArmorDropTweakKey, EskimoArmorDropTweak);
			newConfigServer.Put(RainArmorTweakKey, RainArmorTweak);
			newConfigServer.Put(PharaohSetTweakKey, PharaohSetTweak);
			newConfigServer.Put(VikingHelmetTweakKey, VikingHelmetTweak);
			newConfigServer.Put(CactusArmorTweakKey, CactusArmorTweak);
			newConfigServer.Put(HammerTweaksKey, HammerTweaks);
			newConfigServer.Put(SwatHelmetTweakKey, SwatHelmetTweak);
			newConfigServer.Put(FishBowlTweakKey, FishBowlTweak);
			newConfigServer.Put(BoneBlockFixKey, BoneBlockFix);
			newConfigServer.Put(GoldCritterDropTweakKey, GoldCritterDropTweak);
			newConfigServer.Put(ExtractSpeedMultiplierKey, ExtractSpeedMultiplier);
			newConfigServer.Put(JestersArrowCraftKey, JestersArrowCraft);
			newConfigServer.Put(MolotovTweakKey, MolotovCraft);
			newConfigServer.Put(WhoopieCushionTweakKey, WhoopieCushionTweak);
			newConfigServer.Put(CrimsonArmorTweakKey, CrimsonArmorTweak);
			newConfigServer.Put(UndeadMinerTweakKey, UndeadMinerTweak);
			newConfigServer.Put("UndeadMinerRareLifeform", UndeadMinerTweak);
			newConfigServer.Put(FishingPoleTweakKey, FishingPoleTweak);
			newConfigServer.Put(CoinsTweakKey, CoinsTweak);
			newConfigServer.Save();

			var newConfigPathClient = Path.Combine(ConfigManager.ModConfigPath,
					nameof(VanillaTweaks) + '_' + ClientConfig.ConfigName + ".json");
			var newConfigClient = new Preferences(newConfigPathClient);
			newConfigClient.Put(FavoriteTooltipRemoveKey, FavoriteTooltipRemove);
			newConfigClient.Put(SkullTweakKey, SkullTweak);
			newConfigClient.Put(SandstoneRenameKey, SandstoneRename);
			newConfigClient.Put(CobaltShieldRenameKey, CobaltShieldRename);
			newConfigClient.Put(NightsEdgeAutoswingKey, NightsEdgeAutoswing);
			newConfigClient.Put(TrueSwordsAutoswingKey, TrueSwordsAutoswing);
			newConfigClient.Save();

			File.Delete(ConfigPath);
		}
	}
}
