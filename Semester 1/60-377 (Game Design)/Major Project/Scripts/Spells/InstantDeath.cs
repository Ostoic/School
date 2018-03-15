using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Classes;

namespace Spells
{
    public class InstantDeath : Spell
    {
        public InstantDeath(Unit caster) : base(caster)
        {
            this.SetCooldown(0);
        }

        public override bool Cast(Unit target)
        {
            if (base.Cast(target))
            {
                // Kill target
                target.Damage(target.GetMaxHealth());
                return true;
            }

            return false;
        }
    }
}