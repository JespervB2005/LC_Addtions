using DunGen;
using GameNetcodeStuff;
using HarmonyLib;
using LethalLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LC_Addtions.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]

    internal class PlayerControllerBPatch
    {

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void PlayerPatch(ref float ___sprintMeter, ref Camera ___gameplayCamera, ref Transform ___thisPlayerBody)
        {
            ___sprintMeter = 1f;

            //Vector3 vector = Vector3.back;

            //___gameplayCamera.transform.LookAt(Vector3.zero);

            //Collider[] hitCollider = new Collider[1];
            //float radius = 10000;
            //int players = Physics.OverlapSphereNonAlloc(___thisPlayerBody.transform.position, radius, hitCollider, 6);
            //for (int i = 0; i < players; i++)
            //{
            //    ___gameplayCamera.transform.LookAt(hitCollider[i].transform.position);

            //    Vector3 playerToObjectdirection = (hitCollider[i].transform.position - ___thisPlayerBody.transform.position).normalized;
            //    Quaternion quaternion = Quaternion.Euler(playerToObjectdirection.x, playerToObjectdirection.y, playerToObjectdirection.z);
            //    ___gameplayCamera.transform.rotation = quaternion;
            //}
        }

    }
}