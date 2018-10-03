using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outOfBounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(this.transform.position.x-Level1Creation.endPt)>30||Mathf.Abs(this.transform.position.x-Level2Creation.endPt)>30){
			Destroy (this.gameObject);		
	}
}
}