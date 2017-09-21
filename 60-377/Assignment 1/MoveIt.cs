using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveIt : MonoBehaviour
{
    public float speed = 1.0f;

    Vector3 dest_pos = new Vector3(3, 0, 0);
    Vector3 dest_neg = new Vector3(-3, 0, 0);

    Vector3 current_destination;
    Vector3 next_destination;

    // Generic swap
    static void Swap<T>(ref T lhs, ref T rhs)
    {
        T temp = lhs;
        lhs = rhs;
        rhs = temp;
    }

    void Start ()
    {
        // Move in the positive direction initially
        current_destination = dest_pos;

        // Then move in the negative direction
        next_destination = dest_neg;
	}

    void update_destination()
    {
        // If we've arrived at our current destination,
        // swap our current and next destinations
        if (transform.position == current_destination)
        {
            Swap<Vector3>(ref next_destination, ref current_destination);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        update_destination();

        transform.position = 
            Vector3.MoveTowards(transform.position, current_destination, speed * Time.deltaTime);
	}
}
