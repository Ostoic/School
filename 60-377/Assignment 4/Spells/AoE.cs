using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Spells
{
    public class AoE : Spell
    {
        void Setup()
        {
            // AoE costs 0 mana
            ManaCost = 0;
        }

        public override void Trigger(Unit target)
        {
            // Downcast to DPS 
            Boss bossCaster = this.caster.GetComponent<Boss>();
            Error.DebugAssert(ref bossCaster, "Attack spell called from non-DPS class");

            // Target will receive aoe damage from the boss caster
            target.ReceiveDamage(bossCaster.GetAoEDamage());
        }
    }
}