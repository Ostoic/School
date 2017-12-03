using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Objects;

namespace Objects
{
    [RequireComponent(typeof(Renderer))]
    public class RandomPowerup : Collectible
    {
        private Color[] colors = { Color.red, Color.black, Color.green, Color.yellow, Color.cyan };
        private int currentIndex = 0;

        Material material;

        private Powerups.Powerup ChoosePowerup(int choice)
        {
            switch (choice)
            {
                case 1: return new Powerups.Invulnerability();
                case 2: return new Powerups.Blink();
                case 3: return new Powerups.Health();
                case 4: return new Powerups.Gravity();
                case 5: return new Powerups.Laser();
                default: return null; 
            }
        }

        public override void Collect(Classes.Player player)
        {
            Powerups.Powerup powerup = this.ChoosePowerup(Random.Range(1, 6));

            if (powerup != null)
                powerup.Collect(player);
        }

        void Startup()
        {
            this.material = this.GetComponent<Renderer>().material;
        }

        protected virtual void Update()
        {
            // Color stuff here
            //this.currentIndex = (this.currentIndex + 1) % 5;
            //this.material.color = colors[this.currentIndex];
        }
    }
}