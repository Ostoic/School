using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Classes;

namespace Spells
{
    public class Laser : Buff
    {
        private Vector3 targetLocation;

        public Laser(Player caster)
            : base(caster)
        {
            this.SetDuration(30);
        }

        public override void Uncast()
        {
        }

        public override bool Cast(Unit target)
        {
            // If casting teleport was successfull, and we can blink..
            if (this.caster.HasBuff("Laser") && base.Cast(target))
            {
                return true;
            }

            return false;
        }
    }
}