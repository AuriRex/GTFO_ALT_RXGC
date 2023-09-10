using HarmonyLib;
using LevelGeneration;

namespace RXGCHelper
{
    public class Patches
    {
        [HarmonyPatch(typeof(LG_HSUActivator_Core))]
        [HarmonyPatch(nameof(LG_HSUActivator_Core.PostCullingSetup))]
        public static class LG_HSUActivator_Core_PostCullingSetup_Patch
        {
            public static void Postfix(LG_HSUActivator_Core __instance)
            {
                RXGCHelperPlugin.LogWarn($"Yeeting the machines!");

                var parent = __instance.gameObject.transform.parent;

                for (int i = 0; i < parent.childCount; i++)
                {
                    var child = parent.GetChild(i);

                    if (child.name.StartsWith("HSU_Activator_machine(Clone)"))
                    {
                        RXGCHelperPlugin.LogWarn($"Moving GO: {child.name}");
                        child.transform.position += new UnityEngine.Vector3(0, -20, 0);
                    }
                }
            }
        }
    }
}
