using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeIt : MonoBehaviour
{
    public float speed = 1.0f;

    Vector3 largeScale;
    Vector3 baseScale;

    Vector3 targetScale;
    Vector3 nextScale;

    // Generic swap
    static void Swap<T>(ref T lhs, ref T rhs)
    {
        T temp = lhs;
        lhs = rhs;
        rhs = temp;
    }

    // Use this for initialization
    void Start ()
    {
        baseScale = transform.localScale;

        // 4 times the original scale
        largeScale = baseScale * 4;

        // Start from the base scale
        targetScale = largeScale;

        // After resizing 4 times the base, 
        // resize down to the base scale
        nextScale = baseScale;
    }

    void update_target_scale()
    {
        if (transform.localScale == targetScale)
        {
            Swap<Vector3>(ref targetScale, ref nextScale);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        update_target_scale();

        // We don't need to normalize any vectors since that's a part of the implementation of 
        // Vector3.MoveTowards. The third parameter is the distance to "move towards" the target
        transform.localScale =
            Vector3.MoveTowards(transform.localScale, targetScale, speed * Time.deltaTime);
    }
}
