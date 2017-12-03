using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Classes;

namespace Spells
{
    public class Health : Spell
    {
        public Health(Player caster)
            : base(caster)
        {
            this.SetCooldown(0);
            this.SetCharges(1);
        }

        public override bool Cast(Unit target)
        {
            if (base.Cast(target))
            {
                if (this.caster.IsFullHealth())
                    this.caster.Overheal(1);
                else
                    this.caster.RestoreHealth(1);
                return true;
            }

            return false;
        }
    }
}