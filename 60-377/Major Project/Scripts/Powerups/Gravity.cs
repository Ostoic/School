using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powerups
{
    public class Gravity : Powerup
    {
        public override void Collect(Classes.Player player)
        {
            Debug.Log("Gravity powerup");
            Spells.InvertGravity invert = (Spells.InvertGravity)player.GetSpell("InvertGravity");
            player.ReceiveBuff(invert);
            invert.Cast();
        }
    }
}