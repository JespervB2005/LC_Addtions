using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LC_Addtions.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_Addtions
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class LC_Addtions : BaseUnityPlugin
    {
        private const string modGUID = "Goldfish.LC_Additions";
        private const string modName = "LC_Additions";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static LC_Addtions Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("boo");

            harmony.PatchAll(typeof(LC_Addtions));
            harmony.PatchAll(typeof(PlayerControllerBPatch));

        }

    }
}
