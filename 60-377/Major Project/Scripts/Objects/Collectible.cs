using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    [RequireComponent(typeof(Scoreboard))]
    public class Collectible : MonoBehaviour
    {
        private Scoreboard scoreboard;

        private void Start()
        {
            scoreboard = GetComponent<Scoreboard>();
        }

        public virtual void Collect()
        {
            this.scoreboard.RegisterItemCollected();
        }
    }
}