using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powerups
{
    public class Laser : Powerup
    {
        public override void Collect(Classes.Player player)
        {
            // Give player the ability to cast Laser.
            player.ReceiveBuff((Spells.Buff)player.GetSpell("Laser"));
            player.CastSpell("Laser");

            this.GetUI(player).SetSpellText("Laser", 30);
            GameObject.Instantiate(Resources.Load("Effects\\RedEffect"), player.transform.position, Quaternion.identity);
        }
    }
}