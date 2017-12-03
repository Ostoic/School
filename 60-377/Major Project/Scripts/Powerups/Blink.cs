using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powerups
{
    public class Blink : Powerup
    {
        public override void Collect(Classes.Player player)
        {
            Debug.Log("Blink powerup");

            // Give player the ability to cast Blink.
            Spells.Blink blink = (Spells.Blink)player.GetSpell("Blink");
            player.ReceiveBuff(blink);
        }
    }
}