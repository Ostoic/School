using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spells
{
    public class SmallHeal : Spell
    {
        void Setup()
        {
            // SmallHeal costs 5 mana
            ManaCost = 5.0f;
        }

        public override void Trigger(Unit target)
        {
        }

    }
}
