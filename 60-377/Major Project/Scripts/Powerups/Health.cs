using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powerups
{
    public class Health : Powerup
    {
        public override void Collect(Classes.Player player)
        {
            Debug.Log("Health powerup");
            // Give player the ability to cast Blink.
            player.CastSpell("Health");
        }
    }
}