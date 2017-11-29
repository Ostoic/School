using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Classes;

namespace Spells
{
    public class InvertGravity : Spell
    {
        public InvertGravity(Player caster) : base(caster)
        {
            this.SetCooldown(10);
            this.SetCharges(2);
        }

        public override bool Cast(Unit target)
        {
            if (base.Cast(target))
            {
                Physics.gravity *= -1;
                this.caster.GetComponent<Objects.Biped>().ReverseGravity();
                return true;
            }

            return false;
        }
    }
}