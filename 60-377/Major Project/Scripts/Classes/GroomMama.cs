using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroomMama : MonoBehaviour {//GroomMama moves around and gives birth to more groomba
	int Direction=-1;//GroomMama can move in both positive and negative x directions!
	float timer=0;
	float nextTimer=3;//every 3 seconds more groombas are born
	Rigidbody jumpBody;
    Classes.Player playerClass;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if ((int)timer % nextTimer == 0&&timer>1) {//Happens every 3 seconds
			Direction *= -1;//switch direction
			Instantiate (Resources.Load ("Groomba"), new Vector3 (transform.position.x-1, transform.position.y + 1, 0), Quaternion.identity);//make two babies
			Instantiate (Resources.Load ("Groomba"), new Vector3 (transform.position.x+1, transform.position.y + 1, 0), Quaternion.identity);//make two babies
			nextTimer += 3;
		}
		transform.position += new Vector3 (Direction, 0, 0) * Time.deltaTime;
	}
}
