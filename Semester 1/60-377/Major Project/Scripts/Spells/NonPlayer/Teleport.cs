using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Classes;

namespace Spells
{
    namespace NonPlayer
    {
        public class Teleport : Spell
        {
            private Vector3 targetLocation;

            /// <summary>
            /// Teleport constructor that sets the default teleport position to the caster's position.
            /// </summary>
            /// <param name="caster">The caster of the spell.</param>
            public Teleport(Unit caster) : base(caster)
            {
                this.targetLocation = caster.transform.position;
                this.SetCooldown(0);
            }

            /// <summary>
            /// Set transform position to the target transform.
            /// </summary>
            /// <param name="target"></param>
            /// <returns>True if the teleport was successful, false otherwise.</returns>
            private bool WorldTeleport(Vector3 targetLocation)
            {
                Transform casterTransform = this.caster.GetComponent<Transform>();

                if (casterTransform)
                {
                    casterTransform.position = targetLocation;
                    return true;
                }
                else
                {
                    Debug.LogError("Caster must have Transform component to use Spells.Teleport");
                    return false;
                }
            }

            /// <summary>
            /// Set teleport location.
            /// </summary>
            /// <param name="targetLocation">The location to teleport to.</param>
            public void SetLocation(Vector3 targetLocation)
            {
                this.targetLocation = targetLocation;
            }

            /// <summary>
            /// Define teleport cast behaviour.
            /// </summary>
            /// <param name="target">Unused parameter</param>
            /// <returns>True if the cast was successful, false otherwise.</returns>
            public override bool Cast(Unit target)
            {
                if (base.Cast(target))
                    return WorldTeleport(this.targetLocation);

                return false;
            }

        }
    }

}