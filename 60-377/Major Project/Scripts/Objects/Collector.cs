using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Spells;

namespace Objects
{
    [DisallowMultipleComponent]
    public class Collector : MonoBehaviour
    {
        void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Collectible")
            {
                Collectible collectible = collider.GetComponent<Collectible>();
                collectible.Collect();

                Destroy(collider.gameObject);
            }
        }
    }
}
