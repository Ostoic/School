using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spells
{
    public class BigHeal : Spell
    {
        void Setup()
        {
            // Bigheal costs 8 mana
            ManaCost = 8.0f;
        }

        public override void Trigger(Unit target)
        {
        }
    }
}