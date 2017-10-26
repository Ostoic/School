using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spells
{
    public class BigHeal : Spell
    {
        private int healAmount = 20;

        void Setup()
        {
            // Bigheal costs 8 mana
            ManaCost = 8;
        }

        public override void Trigger(Unit target)
        {
            // Heal the target
            target.RegenerateHealth(healAmount);

            // Drain mana from the caster
            caster.UseMana(this.ManaCost);
        }
    }
}