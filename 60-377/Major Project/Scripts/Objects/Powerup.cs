using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class Powerup : Collectible
    {
        void Startup()
        {
            Debug.Log("Powerup Start");
        }

        public override void Collect()
        {

        }
    }
}