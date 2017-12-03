using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Classes;

namespace Spells
{
    public class InvertGravity : Buff
    {
        public InvertGravity(Player caster) : base(caster)
        {
            this.SetCooldown(0);
            this.SetCharges(1);
        }

        public override void Uncast()
        {

        }

        public override bool Cast(Unit target)
        {
            if (this.caster.HasBuff("InvertGravity") && base.Cast(target))
            {
                Physics.gravity *= -1;
                this.caster.GetComponent<Objects.Biped>().ReverseGravity();
                return true;
            }

            return false;
        }
    }
}