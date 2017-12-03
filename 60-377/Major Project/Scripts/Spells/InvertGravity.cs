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
            this.SetCharges(2);
            this.SetDuration(2);
        }

        public override void Uncast()
        {
            this.caster.GetComponent<Objects.Player>().SetColor(Color.white);
            Gravity.Reverse();
        }

        public override bool Cast(Unit target)
        {
            if (this.caster.HasBuff("InvertGravity") && base.Cast(target))
            {
                this.caster.GetComponent<Objects.Player>().SetColor(new Color(138, 43, 226));
                Gravity.Reverse();
                return true;
            }

            return false;
        }
    }
}