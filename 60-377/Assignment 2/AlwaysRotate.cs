using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysRotate : MonoBehaviour
{
    public float rotateSpeed = 45;
    public Vector3 direction = Vector3.up;
	
	void Update ()
    {
        transform.Rotate(direction * rotateSpeed * Time.deltaTime);
	}
}
