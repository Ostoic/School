using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class Scoreboard : MonoBehaviour
    {
        private int itemsCollected = 0;
        private int kills = 0;

        public int GetKills()
        {
            return this.kills;
        }

        public int GetItemsCollected()
        {
            return this.itemsCollected;
        }

        public void RegisterKill()
        {
            Debug.Log("Enemy killed");
            this.kills++;
        }

        public void RegisterItemCollected()
        {
            Debug.Log("Item collected");
            this.itemsCollected++;
        }
    }
}