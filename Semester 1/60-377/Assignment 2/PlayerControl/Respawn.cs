using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    Transform spawnPoint;
    MoveSphere sphereMover;

    public void Trigger()
    {
        sphereMover.WorldTeleport(spawnPoint);
        sphereMover.ResetVelocity();
    }

    public void NextSpawn(Transform point)
    {
        spawnPoint = point;
    }

	void Start ()
    {
        spawnPoint = GameObject.Find("Spawn Point: Start").transform;

        if (!(sphereMover = GetComponent<MoveSphere>()))
            Debug.LogError("Unable to find sphere movement script");
    }

}
