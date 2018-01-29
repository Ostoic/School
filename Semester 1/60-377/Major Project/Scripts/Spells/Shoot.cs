using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Classes;
using Objects;

namespace Spells
{
    public class Shoot : Spell
    {
        public Shoot(Unit caster)
            : base(caster)
        {
            this.SetCooldown(2.0f);
            this.SetCharges(Internal.SpellCharges.Infinity);
        }

        public override bool Cast(Unit target)
        {
            if (base.Cast(target))
            {
                Transform transform = this.caster.GetComponent<Transform>();
                GameObject obj = (GameObject)GameObject.Instantiate(Resources.Load("Projectile"), new Vector3(transform.position.x, transform.position.y + 1, 0), Quaternion.identity);
                Projectile projectile = obj.GetComponent<Projectile>();

                if (projectile)
                {
                    projectile.SetTarget(target.gameObject);
                    return true;
                }
                else
                    Debug.LogError("Unable to instantiate projectile");
            }

            return false;
        }

        //weaponCoolDown += Time.deltaTime;
        //if (weaponCoolDown > 2 && Vector3.Distance(transform.position, player.transform.position) < 3)
        //{
        //    Instantiate(Resources.Load("Projectile"), new Vector3(transform.position.x, transform.position.y + 1, 0), Quaternion.identity);
        //    weaponCoolDown = 0;
        //}
    }
}