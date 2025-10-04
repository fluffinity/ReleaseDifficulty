using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using GlobalEnums;
using HarmonyLib;
using UnityEngine;

[BepInPlugin(ReleaseDifficultyMod.ModID, ReleaseDifficultyMod.ModName, ReleaseDifficultyMod.ModVersion)]
public sealed class ReleaseDifficultyMod : BaseUnityPlugin
{
    const string ModID = "xyz.fluffinity.silksong.releaseDifficulty";
    const string ModName = "Release Difficulty";
    const string ModVersion = "0.0.1";

    internal static ConfigEntry<bool> Enable;
    internal static ManualLogSource LogSrc;

    private void Awake()
    {
        LogSrc = BepInEx.Logging.Logger.CreateLogSource(ReleaseDifficultyMod.ModName);
        Enable = Config.Bind("General", "EnableReleaseDifficulty", true, "Enable the difficulty of the game at release");
        LogSrc.LogInfo("Mod loaded and initialized");
        Harmony.CreateAndPatchAll(typeof(ReleaseDifficultyMod.PatchHeroController), null);
        LogSrc.LogInfo("Patched all methods");

    }

    [HarmonyPatch(typeof(HeroController), "TakeDamage")]
    static class PatchHeroController
    {
        private static void Prefix(ref GameObject go, ref CollisionSide damageSide, ref int damageAmount, ref HazardType hazardType, ref DamagePropertyFlags damagePropertyFlags)
        {
            LogSrc.LogDebug($"HealthManager.TakeDamage({go.name}, {damageSide}, {damageAmount}, {hazardType}, {damagePropertyFlags})");
            if (!ReleaseDifficultyMod.Enable.Value)
            {
                return;
            }
            if(hazardType == HazardType.SPIKES || hazardType == HazardType.SINK)
            {
                if(go.name.Contains("Cog Damager") || go.name.Contains("Sand Centipede"))
                {
                    // Workaround to not let the implementation of HeroController.TakeDamage reset the damage amount to 1
                    // The current implementation of TakeDamage checks the hazard type and sets the damage amount to a hard coded value
                    // which means that setting damageAmount is useless in this case. If this ever changes we can directly set damageAmount
                    hazardType = HazardType.STEAM;
                }
                //KETTENSÄGEN!!!!!!!
            }
        }
    }
}
