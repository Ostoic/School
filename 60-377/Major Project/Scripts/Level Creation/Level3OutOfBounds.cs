using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3OutOfBounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (this.transform.position.x - Level3Creation.endPt) > 30) {
            Debug.Log("Destroy");
			Destroy (this.gameObject);	
		}
		if (transform.position.y < -3)Destroy (this.gameObject);
	}
}
