using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    void OnTriggerEnter(Collider collide)
    {
        if (collide.tag == "Collectible")
            Destroy(collide.gameObject);
    }
}
