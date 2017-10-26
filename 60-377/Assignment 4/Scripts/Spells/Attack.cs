using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spells
{ 
    public class Attack : Spell
    {
        void Setup()
        {
            // Attack costs 0 mana
            ManaCost = 0;
        }

        public override void Trigger(Unit target)
        {
            // Downcast to DPS 
            DPS dpsCaster = caster.GetComponent<DPS>();
            Error.DebugAssert(ref dpsCaster, "Attack spell called from non-DPS class");

            // Target will receive damage from the dps caster
            target.ReceiveDamage(dpsCaster.GetDamage());
        }
    }
}
