using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classes
{
    [RequireComponent(typeof(Objects.Biped), typeof(Objects.Scoreboard), typeof(Rigidbody))]
    public class Player : Unit
    {
        void Start()
        {
            // Powerup spells
            this.LearnSpell("Blink", new Spells.Blink(this));
            this.LearnSpell("Health", new Spells.Health(this));
            this.LearnSpell("InvertGravity", new Spells.InvertGravity(this));
            this.LearnSpell("Invulnerability", new Spells.Invulnerability(this));

            // Default player spells
            //this.LearnSpell("Laser", new Spells.Laser(this));
            this.LearnSpell("HeadStomp", new Spells.HeadStomp(this));

            // Add Non-Player spells that can only be invoked by means of Player spells.
            this.LearnSpell("NP_Teleport",  new Spells.NonPlayer.Teleport(this));
            this.LearnSpell("NP_Invulnerability", new Spells.NonPlayer.Invulnerability(this));
        }
    }
}