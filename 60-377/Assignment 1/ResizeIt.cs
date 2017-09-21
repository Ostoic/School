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

        largeScale = baseScale * 4;
        targetScale = largeScale;
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

        transform.localScale =
            Vector3.MoveTowards(transform.localScale, targetScale, speed * Time.deltaTime);
    }
}
