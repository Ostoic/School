using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Classes;

namespace Objects
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Classes.Player))]
    public class Collector : MonoBehaviour
    {
        void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Collectible")
            {
                Collectible collectible = collider.GetComponent<Collectible>();
                if (collectible == null)
                {
                    Debug.LogError("Collectible is missing Objects.Collectible script!");
                    return;
                }

                collectible.Collect(this.GetComponent<Player>());

                Destroy(collider.gameObject);
            }
        }
    }
}
