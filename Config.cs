
using System;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;

namespace VanillaTweaks
{
	public static class Config
	{
		public static bool GladiatorArmorTweak = true;
		const string GladiatorArmorTweakKey = "GladiatorArmorTweak";
		
		public static bool ObsidianArmorTweak = true;
		const string ObsidianArmorTweakKey = "ObsidianArmorTweak";
		
		public static bool MeteorArmorDamageTweak = true;
		const string MeteorArmorDamageTweakKey = "MeteorArmorDamageTweak";
		
		public static bool EskimoArmorTweak = true;
		const string EskimoArmorTweakKey = "EskimoArmorTweak";
		
		public static bool RainArmorTweak = true;
		const string RainArmorTweakKey = "RainArmorTweak";
		
		public static bool HammerTweaks = true;
		const string HammerTweaksKey = "HammerTweaks";
		
		public static bool NightsEdgeAutoswing = true;
		const string NightsEdgeAutoswingKey = "NightsEdgeAutoswing";
		
		public static bool TrueSwordsAutoswing = true;
		const string TrueSwordsAutoswingKey = "TrueSwordsAutoswing";
		
		public static bool SwatHelmetTweak = true;
		const string SwatHelmetTweakKey = "SwatHelmetTweak";
		
		public static bool SkullTweak = true;
		const string SkullTweakKey = "SkullTweak";
		
		public static bool FishBowlTweak = true;
		const string FishBowlTweakKey = "FishBowlTweak";
		
		public static bool SandstoneRename = true;
		const string SandstoneRenameKey = "SandstoneRename";
		
		public static bool CobaltShieldRename = true;
		const string CobaltShieldRenameKey = "CobaltShieldRename";
		
		public static bool BoneBlockFix = true;
		const string BoneBlockFixKey = "BoneBlockFix";
		
		public static bool GoldCritterDropTweak = true;
		const string GoldCritterDropTweakKey = "GoldCritterDropTweak";
		
		public static float ExtractSpeedMultiplier = 5f;
		const string ExtractSpeedMultiplierKey = "ExtractSpeedMultiplier";
		
		public static int JestersArrowCraft = 50;
		const string JestersArrowCraftKey = "JestersArrowCraft";
		
		public static bool FavoriteTooltipRemove = true;
		const string FavoriteTooltipRemoveKey = "FavoriteTooltipRemove";
		
		public static bool WhoopieCushionTweak = true;
		const string WhoopieCushionTweakKey = "WhoopieCushionTweak";
		
        public static bool WanderingEyeLensTweak = true;
		const string WanderingEyeLensTweakKey = "WanderingEyeLensTweak";
	
        public static bool DripplerLensTweak = true;	
		const string DripplerLensTweakKey = "DripplerLensTweak";
		
        public static bool CoinsTweak = true;
		const string CoinsTweakKey = "CoinsTweak";		
		
        public static bool MolotovTweak = true;
		const string MolotovTweakKey = "MolotovTweak";		
		
		public static bool VikingHelmetTweak = true;
		const string VikingHelmetTweakKey = "VikingHelmetTweak";
		
		public static bool CactusArmorTweak = true;
		const string CactusArmorTweakKey = "CactusArmorTweak";	
				
		public static bool MeteorArmorDefenseTweak = true;
		const string MeteorArmorDefenseTweakKey = "MeteorArmorDefenseTweak";
		
		
		static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "Vanilla Tweaks.json");
		
		static string OldConfigFolderPath = Path.Combine(Main.SavePath, "Mod Configs", "Vanilla Tweaks");
		static string OldConfigPath = Path.Combine(OldConfigFolderPath, "config.json");
		static string OldConfigVersionPath = Path.Combine(OldConfigFolderPath, "config.version");
		
		static readonly Preferences setting = new Preferences(ConfigPath);
		
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
					File.Delete(OldConfigVersionPath);
				if(Directory.GetFiles(OldConfigFolderPath).Length == 0 && Directory.GetDirectories(OldConfigFolderPath).Length == 0)
					Directory.Delete(OldConfigFolderPath);
				else
					VanillaTweaks.Log("Old config folder still cotains some files/directories. They will not get deleted.");
			}
			if(!ReadConfig())
				VanillaTweaks.Log("Failed to read config file! Recreating config...");
			SaveConfig();
		}
		
		public static bool ReadConfig()
		{
			if(setting.Load())
			{
				setting.Get(GladiatorArmorTweakKey, ref GladiatorArmorTweak);
				setting.Get(ObsidianArmorTweakKey, ref ObsidianArmorTweak);
				setting.Get(MeteorArmorDefenseTweakKey, ref MeteorArmorDefenseTweak);
				setting.Get(EskimoArmorTweakKey, ref EskimoArmorTweak);
				setting.Get(RainArmorTweakKey, ref RainArmorTweak);
				setting.Get(HammerTweaksKey, ref HammerTweaks);
				setting.Get(NightsEdgeAutoswingKey, ref NightsEdgeAutoswing);
				setting.Get(TrueSwordsAutoswingKey, ref TrueSwordsAutoswing);
				setting.Get(SwatHelmetTweakKey, ref SwatHelmetTweak);
				setting.Get(SkullTweakKey, ref SkullTweak);
				setting.Get(FishBowlTweakKey, ref FishBowlTweak);
				setting.Get(SandstoneRenameKey, ref SandstoneRename);
				setting.Get(CobaltShieldRenameKey, ref CobaltShieldRename);
				setting.Get(BoneBlockFixKey, ref BoneBlockFix);
				setting.Get(GoldCritterDropTweakKey, ref GoldCritterDropTweak);
				setting.Get("ExtractSpeedMulitplier", ref ExtractSpeedMultiplier); //bit of a typo there :P
				setting.Get(ExtractSpeedMultiplierKey, ref ExtractSpeedMultiplier);
				setting.Get(JestersArrowCraftKey, ref JestersArrowCraft);
				setting.Get(FavoriteTooltipRemoveKey, ref FavoriteTooltipRemove);
				setting.Get(VikingHelmetTweakKey, ref VikingHelmetTweak);
				setting.Get(CactusArmorTweakKey, ref CactusArmorTweak);
				setting.Get(MeteorArmorDamageTweakKey, ref MeteorArmorDamageTweak);
				setting.Get(MolotovTweakKey, ref MolotovTweak);
				setting.Get(DripplerLensTweakKey, ref DripplerLensTweak);
				setting.Get(WanderingEyeLensTweakKey, ref WanderingEyeLensTweak);
				setting.Get(WhoopieCushionTweakKey, ref WhoopieCushionTweak);
				setting.Get(CoinsTweakKey, ref CoinsTweak);
				return true;
			}
			return false;
		}
		
		public static void SaveConfig()
		{
			setting.Clear();
			setting.Put(GladiatorArmorTweakKey, GladiatorArmorTweak);
			setting.Put(ObsidianArmorTweakKey, ObsidianArmorTweak);
			setting.Put(MeteorArmorDefenseTweakKey, MeteorArmorDefenseTweak);
			setting.Put(EskimoArmorTweakKey, EskimoArmorTweak);
			setting.Put(RainArmorTweakKey, RainArmorTweak);
			setting.Put(HammerTweaksKey, HammerTweaks);
			setting.Put(NightsEdgeAutoswingKey, NightsEdgeAutoswing);
			setting.Put(TrueSwordsAutoswingKey, TrueSwordsAutoswing);
			setting.Put(SwatHelmetTweakKey, SwatHelmetTweak);
			setting.Put(SkullTweakKey, SkullTweak);
			setting.Put(FishBowlTweakKey, FishBowlTweak);
			setting.Put(SandstoneRenameKey, SandstoneRename);
			setting.Put(CobaltShieldRenameKey, CobaltShieldRename);
			setting.Put(BoneBlockFixKey, BoneBlockFix);
			setting.Put(GoldCritterDropTweakKey, GoldCritterDropTweak);
			setting.Put(ExtractSpeedMultiplierKey, ExtractSpeedMultiplier);
			setting.Put(JestersArrowCraftKey, JestersArrowCraft);
			setting.Put(FavoriteTooltipRemoveKey, FavoriteTooltipRemove);
			setting.Put(VikingHelmetTweakKey, VikingHelmetTweak);
			setting.Put(CactusArmorTweakKey, CactusArmorTweak);
			setting.Put(MeteorArmorDamageTweakKey, MeteorArmorDamageTweak);
			setting.Put(MolotovTweakKey, MolotovTweak);
			setting.Put(DripplerLensTweakKey, DripplerLensTweak);
			setting.Put(WanderingEyeLensTweakKey, WanderingEyeLensTweak);
			setting.Put(WhoopieCushionTweakKey, WhoopieCushionTweak);
			setting.Put(CoinsTweakKey, CoinsTweak);
			setting.Save();
		}
		
		//TODO: Transmations
		public static void LoadFKConfig(Mod mod)
		{
			var setting = FKTModSettings.ModSettingsAPI.CreateModSettingConfig(mod);

			setting.AddComment("Features marked with an asterisk (*) require an item reset to update properly.\n" +
			                   "An item can be reset by either re-entering the world or by placing it into an Item Frame, Weapon Rack or Mannequin.");
			setting.AddComment("Features marked with two asterisks (**) require a mod reload to update properly.");
			setting.AddComment("Most values are only modifiable in singleplayer.");
			
			const float commentScale = 0.8f;
			
			setting.AddComment("Defense increased*, set bonus: +15% crit chance", commentScale);
			setting.AddBool(GladiatorArmorTweakKey, "Gladiator Armor Tweaks", false);
			setting.AddComment("+3% ranged crit chance for each piece, set bonus: +10% move speed and shadow trail", commentScale);
			setting.AddBool(ObsidianArmorTweakKey, "Obsidian Armor Tweaks", false);
			setting.AddComment("Defense decreased*", commentScale);
			setting.AddBool(MeteorArmorDefenseTweakKey, "Meteor Armor Defense Tweaks", false);
			setting.AddComment("Defense increased*, immunity to cold water, set bonus: Warmth buff, immunity to Frostburn, Chilled and Frozen", commentScale);
			setting.AddBool(EskimoArmorTweakKey, "Eskimo Armor Tweaks", false);
			setting.AddComment("Set bonus: +1 defense, immunity to being wet", commentScale);
			setting.AddBool(RainArmorTweakKey, "Rain Armor Tweaks", false);
			setting.AddComment("Rebalances a few hammers/hamaxes", commentScale);
			setting.AddBool(HammerTweaksKey, "Hammer Tweaks*", false);
			setting.AddBool(NightsEdgeAutoswingKey, "Night's Edge Autoswing*", true);
			setting.AddBool(TrueSwordsAutoswingKey, "True Swords Autoswing*", true);
			setting.AddComment("+14 defense, +15% ranged damage (all types), +5% ranged crit chance\n" + 
			                   "If Miscellania is installed, equipping a SWAT Helmet and a Reinforced Vest grants a set bonus", commentScale);
			setting.AddBool(SwatHelmetTweakKey, "SWAT Helmet Tweaks*", false);
			setting.AddComment("Flips the Skull sprite so that it faces to the right like other armor/vanity", commentScale);
			setting.AddBool(SkullTweakKey, "Skull Flip", true);
			setting.AddComment("+1 defense", commentScale);
			setting.AddBool(FishBowlTweakKey, "Fish Bowl Tweaks*", false);
			setting.AddComment("Renames items such as Sandstone Brick to Sand Brick", commentScale);
			setting.AddBool(SandstoneRenameKey, "Rename Sandstone Items**", true);
			setting.AddComment("Renames the Cobalt Shield to Guardian's Shield", commentScale);
			setting.AddBool(CobaltShieldRenameKey, "Rename Cobalt Shield**", true);
			setting.AddComment("Bone Block Walls craft back into Bones**, Bone Blocks drop raw Bones when mined", commentScale);
			setting.AddBool(BoneBlockFixKey, "Bone Block Fix", false);
			setting.AddComment("Gold critters drop 1 Gold when killed (as opposed to 5 Gold when sold)", commentScale);
			setting.AddBool(GoldCritterDropTweakKey, "Gold Critters Drop Coins", false);
			setting.AddFloat(ExtractSpeedMultiplierKey, "Extractinator Speed Multiplier", 0f, 5f, false);
			setting.AddBool(FavoriteTooltipRemoveKey, "Remove \"Favorite Item\" Tooltips", true);
			setting.AddComment("Setting this value to 0 will remove the recipe entirely", commentScale);
			setting.AddInt(JestersArrowCraftKey, "Jester's Arrows Crafted per Star**", 0, 100, false);
			setting.AddComment("Gives 5% damage when used with iron or lead armor", commentScale);
			setting.AddBool(VikingHelmetTweakKey, "Iron or Lead Viking Tweaks", true);
			setting.AddComment("changes the set bonus of cactus to reflect 25% of melee damage", commentScale);
			setting.AddBool(CactusArmorTweakKey, "Cactus Armor Tweaks", true);
			setting.AddComment("no magic bonuses", commentScale);
			setting.AddBool(MeteorArmorDamageTweakKey, "Meteor Armor Damage Tweaks", true);
			setting.AddComment("adds a verison of the mobile recipe for molotovs", commentScale);
			setting.AddBool(MolotovTweakKey, "Molotov Craft Tweaks**", true);
			setting.AddComment("Dripplers have a chance to drop to drop up to 6 lenses", commentScale);
			setting.AddBool(DripplerLensTweakKey, "Drippler lenses Tweaks", true);
			setting.AddComment("increases lens drop rate slightly from Wandering Eyes", commentScale);
			setting.AddBool(WanderingEyeLensTweakKey, "Wandering Eye lenses Tweaks", true);
			setting.AddComment("Whoopie Cushion can be used more often and is auto reuseable*", commentScale);
			setting.AddBool(WhoopieCushionTweakKey, "Whoopie Cushion timing tweaks", true);
			setting.AddComment("Makes Coin conversion at the end of recipe list**", commentScale);
			setting.AddBool(CoinsTweakKey, "Coins Positioning Tweak", true);
		}
		
		public static void UpdateFKConfig(Mod mod)
		{
			FKTModSettings.ModSetting setting;
			if(FKTModSettings.ModSettingsAPI.TryGetModSetting(mod, out setting))
			{
				setting.Get(GladiatorArmorTweakKey, ref GladiatorArmorTweak);
				setting.Get(ObsidianArmorTweakKey, ref ObsidianArmorTweak);
				setting.Get(MeteorArmorDefenseTweakKey, ref MeteorArmorDefenseTweak);
				setting.Get(EskimoArmorTweakKey, ref EskimoArmorTweak);
				setting.Get(RainArmorTweakKey, ref RainArmorTweak);
				setting.Get(HammerTweaksKey, ref HammerTweaks);
				setting.Get(NightsEdgeAutoswingKey, ref NightsEdgeAutoswing);
				setting.Get(TrueSwordsAutoswingKey, ref TrueSwordsAutoswing);
				setting.Get(SwatHelmetTweakKey, ref SwatHelmetTweak);
				setting.Get(SkullTweakKey, ref SkullTweak);
				setting.Get(FishBowlTweakKey, ref FishBowlTweak);
				setting.Get(SandstoneRenameKey, ref SandstoneRename);
				setting.Get(CobaltShieldRenameKey, ref CobaltShieldRename);
				setting.Get(BoneBlockFixKey, ref BoneBlockFix);
				setting.Get(GoldCritterDropTweakKey, ref GoldCritterDropTweak);
				setting.Get(ExtractSpeedMultiplierKey, ref ExtractSpeedMultiplier);
				setting.Get(FavoriteTooltipRemoveKey, ref FavoriteTooltipRemove);
				setting.Get(JestersArrowCraftKey, ref JestersArrowCraft);
				setting.Get(VikingHelmetTweakKey, ref VikingHelmetTweak);
				setting.Get(CactusArmorTweakKey, ref CactusArmorTweak);
				setting.Get(MeteorArmorDamageTweakKey, ref MeteorArmorDamageTweak);
				setting.Get(MolotovTweakKey, ref MolotovTweak);
				setting.Get(DripplerLensTweakKey, ref DripplerLensTweak);
				setting.Get(WanderingEyeLensTweakKey, ref WanderingEyeLensTweak);
				setting.Get(WhoopieCushionTweakKey, ref WhoopieCushionTweak);
				setting.Get(CoinsTweakKey, ref CoinsTweak);
			}
		}
		
		class MultiplayerSyncWorld : ModWorld
		{
			public override void NetSend(BinaryWriter writer)
			{
				var data = new BitsByte();
				data[0] = GladiatorArmorTweak;
				data[1] = ObsidianArmorTweak;
				data[2] = MeteorArmorDamageTweak;
				data[3] = RainArmorTweak;
				data[4] = HammerTweaks;
				data[5] = NightsEdgeAutoswing;
				data[6] = TrueSwordsAutoswing;
				data[7] = SwatHelmetTweak;
				writer.Write((byte)data);
				data.ClearAll();
				data[0] = FishBowlTweak;
				data[1] = BoneBlockFix;
				data[2] = GoldCritterDropTweak;
				data[3] = EskimoArmorTweak;
				data[4] = VikingHelmetTweak;
				data[5] = WanderingEyeLensTweak;
				data[6] = DripplerLensTweak;
				data[7] = CactusArmorTweak;
				writer.Write((byte)data);
				data.ClearAll();
				data[0] = CoinsTweak;
				data[1] = WhoopieCushionTweak;
				data[2] = MolotovTweak;
				data[3] = MeteorArmorDefenseTweak;
				writer.Write((byte)data);
				writer.Write(ExtractSpeedMultiplier);
				writer.Write((short)JestersArrowCraft);
			}
			
			public override void NetReceive(BinaryReader reader)
			{
				SaveConfig();
				var data = (BitsByte)reader.ReadByte();
				GladiatorArmorTweak = data[0];
				ObsidianArmorTweak = data[1];
				MeteorArmorDamageTweak = data[2];
				RainArmorTweak = data[3];
				HammerTweaks = data[4];
				NightsEdgeAutoswing = data[5];
				TrueSwordsAutoswing = data[6];
				SwatHelmetTweak = data[7];
				data = (BitsByte)reader.ReadByte();
				FishBowlTweak = data[0];
				BoneBlockFix = data[1];
				GoldCritterDropTweak = data[2];
				EskimoArmorTweak = data[3];
				VikingHelmetTweak = data[4];
				WanderingEyeLensTweak = data[5];
				DripplerLensTweak = data[6];
				CactusArmorTweak = data[7];
				data = (BitsByte)reader.ReadByte();
				CoinsTweak = data[0];
				WhoopieCushionTweak = data[1];
				MolotovTweak = data[2];
				MeteorArmorDefenseTweak = data[3];
				ExtractSpeedMultiplier = reader.ReadSingle();
				JestersArrowCraft = reader.ReadInt16();
			}
		}
		
		class MultiplayerSyncPlayer : ModPlayer
		{
			public override void PlayerDisconnect(Player player)
			{
				ReadConfig();
			}
		}
	}
}
