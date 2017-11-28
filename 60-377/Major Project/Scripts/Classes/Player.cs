using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classes
{
    public class Player : Unit
    {
        void Start()
        {
            // Add HeadStomp to the spell table.
            this.AddSpell("HeadStomp", new Spells.HeadStomp(this));
        }
    }
}