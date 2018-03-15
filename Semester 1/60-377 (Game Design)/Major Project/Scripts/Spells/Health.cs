using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Classes;
using System;

namespace Spells
{
    public class Health : Buff
    {
        public Health(Player caster)
            : base(caster)
        {
            this.SetCooldown(0);
            this.SetDuration(5);
        }

        public override void Uncast()
        {
            if (this.caster.GetHealth() > this.caster.GetMaxHealth())
                this.caster.Damage(1);

            this.caster.gameObject.GetComponent<Objects.Player>().SetColor(Color.white);
        }

        public override bool Cast(Unit target)
        {
            if (base.Cast(target))
            {
                this.caster.gameObject.GetComponent<Objects.Player>().SetColor(Color.green);
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