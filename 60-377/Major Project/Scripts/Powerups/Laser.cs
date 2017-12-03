using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powerups
{
    public class Laser : Powerup
    {
        public override void Collect(Classes.Player player)
        {
            Debug.Log("Laser powerup");
            // Give player the ability to cast Blink.
            //player.CastSpell("Laser");
        }
    }
}