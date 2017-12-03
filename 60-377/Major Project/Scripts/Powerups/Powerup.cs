using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Powerups
{
    public abstract class Powerup 
    {
        public abstract void Collect(Classes.Player player);
    }
}