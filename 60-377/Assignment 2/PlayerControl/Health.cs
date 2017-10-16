using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private bool safe = false;

    void OnTriggerEnter(Collider collide)
    {
        if (collide.tag == "SafeZone")
            safe = true;
    }

    void OnTriggerExit(Collider collide)
    {
        if (collide.tag == "SafeZone")
            safe = false;
    }

    public bool IsSafe()
    {
        return safe;
    }
}
