using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spells
{
    public class SmallHeal : Spell
    {
        private int healAmount = 15;

        void Setup()
        {
            // SmallHeal costs 5 mana
            ManaCost = 5;
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
