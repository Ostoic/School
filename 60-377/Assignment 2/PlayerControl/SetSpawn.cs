using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawn : MonoBehaviour {

    Respawn respawn;

	void Start ()
    {
        if (!(respawn = GetComponent<Respawn>()))
            Debug.LogError("Unable to get respawn script!");
	}

    void OnTriggerEnter(Collider collide)
    {
        if (collide.tag == "Respawn")
            respawn.NextSpawn(collide.gameObject.transform);

    }
}
