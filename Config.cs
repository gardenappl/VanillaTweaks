
using System;
using System.IO;
using Terraria;
using Terraria.IO;

namespace VanillaTweaks
{
	public static class Config
	{
		public static bool GladiatorArmorTweak = true;
		public static bool ObsidianArmorTweak = true;
		public static bool MeteorArmorTweak = true;
		public static bool RainArmorTweak = true;
		public static bool HammerTweaks = true;
		public static bool NightsEdgeAutoswing = true;
		public static bool TrueSwordsAutoswing = true;
		public static bool SwatHelmetTweak = true;
		public static bool SkullTweak = true;
		public static bool FishBowlTweak = true;
		public static bool SandstoneRename = true;
		public static bool CobaltShieldRename = true;
		public static bool BoneBlockFix = true;
		public static bool GoldCritterDropTweak = true;
		public static float ExtractSpeedMultipltier = 5f;
		
		static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "Vanilla Tweaks.json");
		
		static string OldConfigFolderPath = Path.Combine(Main.SavePath, "Mod Configs", "Vanilla Tweaks");
		static string OldConfigPath = Path.Combine(OldConfigFolderPath, "config.json");
		static string OldConfigVersionPath = Path.Combine(OldConfigFolderPath, "config.version");
		
		static readonly Preferences Configuration = new Preferences(ConfigPath);
		
		public static void Load()
		{
			if(Directory.Exists(OldConfigFolderPath))
			{
				if(File.Exists(OldConfigPath))
				{
					VanillaTweaks.Log("Found config file in old folder! Moving config...");
					File.Move(OldConfigPath, ConfigPath);
				}
				if(File.Exists(OldConfigVersionPath))
				{
					File.Delete(OldConfigVersionPath);
				}
				if(Directory.GetFiles(OldConfigFolderPath).Length == 0 && Directory.GetDirectories(OldConfigFolderPath).Length == 0)
				{
					Directory.Delete(OldConfigFolderPath);
				}
				else
				{
					VanillaTweaks.Log("Old config folder still cotains some files/directories. They will not get deleted.");
				}
			}
			if(!ReadConfig())
			{
				VanillaTweaks.Log("Failed to read config file! Recreating config...");
			}
			SaveConfig();
		}
		
		static bool ReadConfig()
		{
			if(Configuration.Load())
			{
				Configuration.Get("GladiatorArmorTweak", ref GladiatorArmorTweak);
				Configuration.Get("ObsidianArmorTweak", ref ObsidianArmorTweak);
				Configuration.Get("MeteorArmorTweak", ref MeteorArmorTweak);
				Configuration.Get("HammerTweaks", ref HammerTweaks);
				Configuration.Get("NightsEdgeAutoswing", ref NightsEdgeAutoswing);
				Configuration.Get("TrueSwordsAutoswing", ref TrueSwordsAutoswing);
				Configuration.Get("SwatHelmetTweak", ref SwatHelmetTweak);
				Configuration.Get("SkullTweak", ref SkullTweak);
				Configuration.Get("FishBowlTweak", ref FishBowlTweak);
				Configuration.Get("SandstoneRename", ref SandstoneRename);
				Configuration.Get("CobaltShieldRename", ref CobaltShieldRename);
				Configuration.Get("BoneBlockFix", ref BoneBlockFix);
				Configuration.Get("SwatHelmetTweak", ref SwatHelmetTweak);
				Configuration.Get("GoldCritterDropTweak", ref GoldCritterDropTweak);
				Configuration.Get("ExtractSpeedMulitplier", ref ExtractSpeedMultipltier);
				return true;
			}
			return false;
		}
		
		static void SaveConfig()
		{
			Configuration.Clear();
			Configuration.Put("GladiatorArmorTweak", GladiatorArmorTweak);
			Configuration.Put("ObsidianArmorTweak", ObsidianArmorTweak);
			Configuration.Put("MeteorArmorTweak", MeteorArmorTweak);
			Configuration.Put("HammerTweaks", HammerTweaks);
			Configuration.Put("NightsEdgeAutoswing", NightsEdgeAutoswing);
			Configuration.Put("TrueSwordsAutoswing", TrueSwordsAutoswing);
			Configuration.Put("SwatHelmetTweak", SwatHelmetTweak);
			Configuration.Put("SkullTweak", SkullTweak);
			Configuration.Put("FishBowlTweak", FishBowlTweak);
			Configuration.Put("SandstoneRename", SandstoneRename);
			Configuration.Put("CobaltShieldRename", CobaltShieldRename);
			Configuration.Put("BoneBlockFix", BoneBlockFix);
			Configuration.Put("SwatHelmetTweak", SwatHelmetTweak);
			Configuration.Put("GoldCritterDropTweak", GoldCritterDropTweak);
			Configuration.Put("ExtractSpeedMulitplier", ExtractSpeedMultipltier);
			Configuration.Save();
		}
	}
}
