using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classes
{
    [RequireComponent(typeof(Objects.Biped))]
    public class Player : Unit
    {
        void Start()
        {
            // Add HeadStomp to the spell table.
            this.AddSpell("HeadStomp", new Spells.HeadStomp(this));
            this.AddSpell("Teleport",  new Spells.Teleport(this));
            this.AddSpell("InvertGravity", new Spells.InvertGravity(this));
        }
    }
}