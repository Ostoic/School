using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class Collectible : MonoBehaviour
    {
        public virtual void Collect(Classes.Player player)
        {
            player.GetComponent<Scoreboard>().RegisterItemCollected();
        }
    }
}