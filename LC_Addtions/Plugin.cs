using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LC_Addtions.Patches;
using LethalLib.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;
using static LethalLib.Modules.ContentLoader;

namespace LC_Addtions
{
    [BepInPlugin(modGUID, modName, modVersion)]
    [BepInDependency(LethalLib.Plugin.ModGUID)]
    public class LC_Addtions : BaseUnityPlugin
    {
        private const string modGUID = "Goldfish.LC_Additions";
        private const string modName = "LC_Additions";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static LC_Addtions Instance;

        internal ManualLogSource mls;

        internal static List<AudioClip> SoundFX;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            string assetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "lc_additions_assets");
            AssetBundle bundle = AssetBundle.LoadFromFile(assetDir);

            Item SilentOrchestra = bundle.LoadAsset<Item>("Assets/LC_Additions/Silent_Orchestra/Silent Orchestra.asset");
            Silent_Orchestra script = SilentOrchestra.spawnPrefab.AddComponent<Silent_Orchestra>();
            script.grabbable = true;
            script.itemProperties = SilentOrchestra;

            NetworkPrefabs.RegisterNetworkPrefab(SilentOrchestra.spawnPrefab);
            Utilities.FixMixerGroups(SilentOrchestra.spawnPrefab);
            Items.RegisterScrap(SilentOrchestra, 10000, Levels.LevelTypes.All);



            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("boo");

            harmony.PatchAll(typeof(LC_Addtions));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
            harmony.PatchAll(typeof(Silent_Orchestra));

            SoundFX = new List<AudioClip>();
            SoundFX = bundle.LoadAllAssets<AudioClip>().ToList();

        }

    }
}
