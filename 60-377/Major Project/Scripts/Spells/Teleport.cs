using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Classes;

namespace Spells
{
    public class Teleport : Spell
    {
        private Transform targetLocation;

        public Teleport(Unit caster) : base(caster)
        {
            this.targetLocation = caster.transform;
        }

        private bool WorldTeleport(Transform target)
        {
            Transform casterTransform = this.caster.GetComponent<Transform>();

            if (casterTransform)
            {
                casterTransform.position = targetLocation.position;
                casterTransform.rotation = targetLocation.rotation;
                return true;
            }
            else
            {
                Debug.LogError("Unit must have Transform component to use Spells.Teleport");
                return false;
            }
        }

        /// <summary>
        /// Set teleport location.
        /// </summary>
        /// <param name="targetLocation"></param>
        public void SetLocation(Transform targetLocation)
        {
            this.targetLocation = targetLocation;
        }

        /// <summary>
        /// Define teleport cast behaviour.
        /// </summary>
        /// <param name="target"></param>
        /// <returns>True if the cast was successful, false otherwise.</returns>
        public override bool Cast(Unit target)
        {
            if (base.Cast(target))
            {
                GameObject go = target.GetComponent<GameObject>();

                if (go)
                    return WorldTeleport(this.targetLocation);

                else
                {
                    Debug.LogError("Unit must have a GameObject component to use Spells.Teleport");
                    return false;
                }
            }

            return false;
        }

    }
}

