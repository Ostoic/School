using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateIt : MonoBehaviour {

    public Vector3 speed = new Vector3(30, 60, 90);

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(speed * Time.deltaTime);
        //transform.eulerAngles += speed * Time.deltaTime;
    }
}
