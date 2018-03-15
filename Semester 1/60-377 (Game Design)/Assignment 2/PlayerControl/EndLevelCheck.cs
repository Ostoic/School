using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelCheck : MonoBehaviour
{
	void Start ()
    {
		
	}

    void OnTriggerEnter(Collider collide)
    {
        if (collide.tag == "EndLevel")
            collide.gameObject.GetComponent<EndLevel>().Trigger();
    }
}
