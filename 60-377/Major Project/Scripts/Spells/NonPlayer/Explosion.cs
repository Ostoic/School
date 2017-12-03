using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Classes;

namespace Spells
{
    public class Explosion : Spell
    {
        Rigidbody targetBody;

        /// <summary>
        /// Explosion constructor that sets the default rigidbody explosion to the caster's rigidbody.
        /// </summary>
        /// <param name="caster">The caster of the spell.</param>
        public Explosion(Unit caster) : base(caster)
        {
            this.targetBody = caster.GetComponent<Rigidbody>();
            this.SetCooldown(0);
            this.SetCharges(Internal.SpellCharges.Infinity);
        }

        private bool ApplyForce(Rigidbody target)
        {
			Rigidbody casterBody = this.caster.GetComponent<Rigidbody>();

			if (casterBody)
			{				
				target.AddExplosionForce(1000, this.caster.transform.position, 3, 3.0f);
				return true;
			}
			else
			{
				Debug.LogError("Caster must have Transform component to use Spells.Explosion");
				return false;
			}
        }

        /// <summary>
        /// Set rigidbody to which the explosive force is being applied.
        /// </summary>
        public void SetBody(Rigidbody targetBody)
        {
            this.targetBody = targetBody;
        }

        public override bool Cast(Unit target)
        {
			if (base.Cast(target))
            {
                if (ApplyForce(this.targetBody))
                {
                    target.Damage(1);
                    return true;
                }
            }

			return false;
		}
    }
}