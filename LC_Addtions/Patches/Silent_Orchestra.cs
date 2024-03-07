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

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();

        }

        public override void ItemActivate(bool used, bool buttonDown = true)
        {
            base.ItemActivate(used, buttonDown);
            if (buttonDown)
            {
                
                audioSource.PlayOneShot(LC_Addtions.SoundFX[0]);

            }
        }
    }
}
