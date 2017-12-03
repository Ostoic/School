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
            this.SetCooldown(0);
        }

        public void SetLocation(Vector3 target)
        {
            this.targetLocation = target;
        }

        public override void Uncast()
        {
            this.caster.gameObject.GetComponent<Objects.Player>().SetColor(Color.red);
        }

        public override bool Cast(Unit target)
        {
            if (this.caster.HasBuff("Laser") && base.Cast(target))
            {
                this.caster.gameObject.GetComponent<Objects.Player>().SetColor(Color.red);
                GameObject obj = (GameObject)GameObject.Instantiate(Resources.Load("Laser"), this.caster.transform.position + this.caster.transform.forward, Quaternion.identity);
                if (obj)
                {
                    Objects.Laser projectile = obj.GetComponent<Objects.Laser>();
                    projectile.SetSpeed(60);
                    projectile.SetTarget(this.targetLocation);
                }

                return true;
            }

            return false;
        }
    }
}