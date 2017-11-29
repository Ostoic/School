using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class Collectible : MonoBehaviour
    {
        private Scoreboard scoreboard;
        private void Start()
        {
            Debug.Log("Collectible Start");
            GameObject go = GameObject.FindGameObjectWithTag("Player");
            if (go == null)
            {
                Debug.LogError("Player GameObject not found!");
                return;
            }

            this.scoreboard = go.GetComponent<Scoreboard>();
        }

        public virtual void Collect()
        {
            this.scoreboard.RegisterItemCollected();
        }
    }
}