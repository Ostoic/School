using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powerups
{
    public class Gravity : Powerup
    {
        public override void Collect(Classes.Player player)
        {
            Spells.InvertGravity invert = (Spells.InvertGravity)player.GetSpell("InvertGravity");
            player.ReceiveBuff(invert);
            invert.Cast();

            this.GetUI(player).SetSpellText("Invert Gravity", 1);
            GameObject.Instantiate(Resources.Load("Effects\\PurpleEffect"), player.transform.position, Quaternion.identity);
        }
    }
}