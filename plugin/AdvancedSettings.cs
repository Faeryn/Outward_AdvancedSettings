using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace AdvancedSettings {
	[BepInPlugin(GUID, NAME, VERSION)]
	public class AdvancedSettings : BaseUnityPlugin {
		public const string GUID = "faeryn.advancedsettings";
		public const string NAME = "AdvancedSettings";
		public const string VERSION = "0.1.0";
		internal static ManualLogSource Log;
		
		public static ConfigEntry<bool> EnableTAA;

		internal void Awake() {
			Log = this.Logger;
			Log.LogMessage($"Starting {NAME} {VERSION}");
			InitializeConfig();
			new Harmony(GUID).PatchAll();
		}

		private void InitializeConfig() {
			EnableTAA = Config.Bind("AdvancedSettings", "Enable Temporal Antialiasing", true, "Changes the antialiasing mode to TAA. Note: It only takes effect if Antialiasing is enabled in the Settings menu.");
			EnableTAA.SettingChanged += (sender, args) => {
				CameraQuality.RefreshAllCameras();
			};
		}
	}
}