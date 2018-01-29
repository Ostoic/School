using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Classes;

namespace Spells
{
    public class Blink : Buff
    {
        private Vector3 targetLocation;

        public Blink(Player caster)
            : base(caster)
        {
            this.SetCooldown(0);
            this.SetCharges(5);
        }

        private void ResetJumps()
        {
            Objects.Player player = this.caster.GetComponent<Objects.Player>();
            Rigidbody rb = this.caster.GetComponent<Rigidbody>();

            if (rb != null)
                rb.velocity = Vector3.zero;

            if (player != null)
                player.ResetJumps();
        }

        /// <summary>
        /// Set teleport location.
        /// </summary>
        /// <param name="targetLocation">The location to teleport to.</param>
        public void SetLocation(Vector3 targetLocation)
        {
            this.targetLocation = targetLocation;
        }

        public override void Uncast()
        {
            this.SetCharges(5);
            this.caster.gameObject.GetComponent<Objects.Player>().SetColor(Color.white);
        }

        public override bool Cast(Unit target)
        {
            // If casting teleport was successfull, and we can blink..
            if (this.caster.HasBuff("Blink") && base.Cast(target))
            {
                NonPlayer.Teleport teleport = (NonPlayer.Teleport)this.caster.GetSpell("NP_Teleport");
                teleport.SetLocation(this.targetLocation);
                teleport.Cast();

                this.ResetJumps();
                this.caster.gameObject.GetComponent<Objects.Player>().SetColor(Color.blue);

                NonPlayer.Invulnerability invulnerability = (NonPlayer.Invulnerability)this.caster.GetSpell("NP_Invulnerability");
                invulnerability.SetDuration(2);
                invulnerability.Cast();

                this.caster.ReceiveBuff(invulnerability);
                return true;
            }

            return false;
        }
    }
}