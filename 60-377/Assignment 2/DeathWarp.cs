using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWarp : MonoBehaviour
{
    Respawn respawn;
    Health health;

    void Start ()
    {
        if (!(respawn = GetComponent<Respawn>()))
            Debug.LogError("Unable to set up respawn script");

        if (!(health = GetComponent<Health>()))
            Debug.LogError("Unable to get health script");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "DeathZone")
            if (!health.IsSafe())
                respawn.Trigger();
    }
}
