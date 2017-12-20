using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powerups
{
    public class Health : Powerup
    {
        public override void Collect(Classes.Player player)
        {
            // Give player the ability to cast Blink.
            player.ReceiveBuff((Spells.Buff)player.GetSpell("Health"));
            player.CastSpell("Health");
            this.GetUI(player).SetSpellText("Health Shield", 1);
            GameObject.Instantiate(Resources.Load("Effects\\GreenEffect"), player.transform.position, Quaternion.identity);
        }
    }
}