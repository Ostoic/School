using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Classes;

namespace Spells
{
    public class GroombaBirth : Spell
    {
        Vector3 position;

        public GroombaBirth(Unit caster)
            : base(caster)
        {
            this.SetCooldown(5);
            position = this.caster.transform.position;
        }

        public void SetBirthplace(Vector3 position)
        {
            this.position = position;
        }

        public override bool Cast(Unit target)
        {
            if (base.Cast(target))
            {
                GameObject.Instantiate(Resources.Load("Groomba"), new Vector3(this.position.x, this.position.y, 0), Quaternion.identity);
                return true;
            }

            return false;
        }
    }
}