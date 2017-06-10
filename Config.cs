
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
        
        static int ConfigVersion;
        const int LatestVersion = 1;
        static string ConfigFolderPath = Path.Combine(Main.SavePath, "Mod Configs", "Vanilla Tweaks");
        static string ConfigPath = Path.Combine(ConfigFolderPath, "config.json");
        static string ConfigVersionPath = Path.Combine(ConfigFolderPath, "config.version");
        
        static readonly Preferences Configuration = new Preferences(ConfigPath);
        
        public static void Load()
        {
            if(File.Exists(ConfigVersionPath))
            {
                try
                {
                    int.TryParse(File.ReadAllText(ConfigVersionPath), out ConfigVersion);
                }
                catch(Exception e)
                {
                    VanillaTweaks.Log("Unable to read config version!");
                    VanillaTweaks.Log(e.ToString());
                    ConfigVersion = 0;
                }
            }
            else
            {
                ConfigVersion = 0;
            }
            
            if(ConfigVersion < LatestVersion)
            {
                VanillaTweaks.Log("Config is outdated! Current version: {0} Latest version: {1}", ConfigVersion, LatestVersion);
            }
            if(ConfigVersion > LatestVersion)
            {
                VanillaTweaks.Log("Config is from the future?! Current version: {0} Latest version: {1}", ConfigVersion, LatestVersion);
            }
//            BossExpertise.Log("Reading config...");
            if(!ReadConfig())
            {
                VanillaTweaks.Log("Failed to read config file! Recreating config...");
                SaveConfig();
            }
            else if(ConfigVersion != LatestVersion)
            {
                VanillaTweaks.Log("Replacing config with newest version...");
                File.WriteAllText(ConfigVersionPath, LatestVersion.ToString());
                SaveConfig();
            }
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
            Configuration.Save();
        }
    }
}
