using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Classes;

namespace Spells
{
    public class HeadStomp : Spell
    {
        public HeadStomp(Unit caster) : base(caster) { }

        /// <summary>
        /// HeadStomp is a spell that is cast when the player steps on an 
        /// enemy's head. It deals 1 damage to the enemy.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public override bool Cast(Unit target)
        {
            // Ensure all conditions are satisfied to cast the spell.
            if (base.Cast(target))
            {
                // Deal 1 damage.
                target.Damage(1);
                return true;
            }

            return false;
        }
    }
}