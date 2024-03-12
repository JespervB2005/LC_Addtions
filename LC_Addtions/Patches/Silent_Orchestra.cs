using BepInEx;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LC_Addtions.Patches
{

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
