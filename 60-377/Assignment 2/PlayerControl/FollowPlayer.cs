using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float zOffset = -10.0f;
    public float yOffset = 10.0f;

    private Transform player;
    private MoveSphere control;
    private Vector3 targetPosition;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        control = player.GetComponent<MoveSphere>();
        targetPosition = new Vector3(player.position.x, player.position.y + 10, player.position.z - 10);
    }

    void UpdateTarget()
    {
        targetPosition.x = player.position.x;
        targetPosition.y = player.position.y + yOffset;
        targetPosition.z = player.position.z + zOffset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdateTarget();
        transform.position = targetPosition;
        transform.LookAt(player.transform);
    }
}
