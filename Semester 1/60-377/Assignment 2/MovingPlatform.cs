using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 direction = Vector3.right;

    private Vector3 nextTarget;
    private Vector3 currentTarget;
    public static void Swap<T>(ref T left, ref T right)
    {
        T temp;
        temp = left;
        left = right;
        right = temp;
    }

    void Start ()
    {
        currentTarget = transform.position;
        nextTarget = transform.position + direction * 5;
	}
    void GetNextTarget()
    {
        if (Vector3.Distance(nextTarget, transform.position) < 0.1)
            Swap(ref nextTarget, ref currentTarget);
    }
	
	void Update ()
    {
        GetNextTarget();
        transform.position = Vector3.Lerp(transform.position, nextTarget, speed * Time.deltaTime);
	}
}
