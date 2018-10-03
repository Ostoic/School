using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powerups
{
    public abstract class Powerup
    { 
        protected MenuUI.PlayerUI GetUI(Classes.Player player)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("UI");
            return obj.GetComponentInParent<MenuUI.PlayerUI>();
        }

        public abstract void Collect(Classes.Player player);
    }
}