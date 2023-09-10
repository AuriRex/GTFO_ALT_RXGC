using BepInEx;
using BepInEx.Unity.IL2CPP;
using System.Reflection;

namespace RXGCHelper
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class RXGCHelperPlugin : BasePlugin
    {
        public const string PLUGIN_GUID = "dev.aurirex.gtfo.rxgchelper";
        public const string PLUGIN_NAME = "RXGCHelper";
        public const string PLUGIN_VERSION = "1.0.0";

        private static RXGCHelperPlugin _instance;

        private HarmonyLib.Harmony _harmony = new HarmonyLib.Harmony(PLUGIN_GUID);

        public override void Load()
        {
            _instance = this;

            _harmony.PatchAll(Assembly.GetExecutingAssembly());

            Log.LogMessage("Loaded and patched!");
        }

        internal static void LogMsg(string v)
        {
            _instance.Log.LogMessage(v);
        }

        internal static void LogWarn(string v)
        {
            _instance.Log.LogWarning(v);
        }
    }
}