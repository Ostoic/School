using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classes
{
    public class Enemy : Unit
    {
        Player target;
        GameObject targetObj;

        protected virtual void Start()
        {
            this.targetObj = GameObject.FindGameObjectWithTag("Player");
            this.target = this.targetObj.GetComponent<Player>();
        }

        void OnTriggerEnter(Collider collision)
        {
            Debug.Log(collision.gameObject.tag);
            if (collision.gameObject.tag == "FootHead")
            {
                Objects.Player playerObj = collision.gameObject.GetComponentInParent<Objects.Player>();
                playerObj.ResetJumps();
                this.Damage(1);
            }

            else if (collision.gameObject.tag == "Sides")
            {
                Classes.Player player = collision.gameObject.GetComponentInParent<Classes.Player>();
                player.Damage(1);

                // Give the player 1 second of invincibility after being damaged.
                Spells.Spell sp = player.GetSpell("NP_Invulnerability");

                if (sp == null) Debug.Log("Unable to get Invulnerability spell");
                Spells.Invulnerability inv = (Spells.Invulnerability)sp;
                inv.SetDuration(1);
                player.ReceiveBuff(inv);
                inv.Cast();
            }

            else if  (collision.gameObject.tag == "Projectile")
                this.Damage(1);
        }

        protected override void OnDestroy()
        {
            this.target.GetComponent<Objects.Scoreboard>().RegisterKill();
        }
    }
}