using BepInEx;
using GameNetcodeStuff;
using HarmonyLib;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LC_Addtions.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class Silent_Orchestra : PhysicsProp
    {

        public AudioSource audioSource;
        private float audioTimer = 0;
        private float damageTimer = 0;

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = 0.5f;

        }
        public override void LateUpdate()
        {

            base.LateUpdate();
            if (audioTimer > 0)
            {
                
                audioTimer -= Time.deltaTime;
                damageTimer -= Time.deltaTime;

                //Collider[] hitCollider = new Collider[10];
                //float radius = 25;
                //int players = Physics.OverlapSphereNonAlloc(base.transform.position, radius, hitCollider, StartOfRound.Instance.playersMask);
                //for (int i = 0; i < players; i++)
                //{
                //    Vector3 playerToObjectdirection = (base.transform.position - hitCollider[i].transform.position).normalized;
                //    hitCollider[i].gameplayCamera.transform.rotation = playerToObjectdirection;
                //}

            }
            if (audioTimer > 37 && audioTimer < 49.5) 
            { 
                if (playerHeldBy != null && damageTimer <= 0) 
                {
                    playerHeldBy.DamagePlayer(10);
                    damageTimer = 0.5f;
                }
            }
        }

        public override void GrabItem()
        {
            base.GrabItem();
            if (audioTimer <= 0 ) 
            {
                audioSource.PlayOneShot(LC_Addtions.SoundFX[0]);
                audioTimer = 90;
            }
        }
    }
}
