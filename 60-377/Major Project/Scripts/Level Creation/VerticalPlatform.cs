using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour {
	int direction=1;//positive for right,negative for left
	float start;
	int zone=2;//able to move 2 units left and right
	// Use this for initialization
	void Start () {
		start = transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		if(transform.position.y>start+2){
			direction = -1;
		}
		else if(transform.position.y<start-2) {
			direction=1;
		}
		transform.position += Vector3.up*direction * Time.deltaTime;
	}
}
