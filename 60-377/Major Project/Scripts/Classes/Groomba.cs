using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Spells.NonPlayer;

public class Groomba : MonoBehaviour {
	int Direction=-1;
	float timer=0;
	Rigidbody jumpBody;
	GameObject player;
	// Use this for initialization
	void Start () {
		jumpBody = this.GetComponent<Rigidbody> ();
		player=(GameObject.FindGameObjectWithTag("Player"));
	}

	void OnTriggerEnter(Collider collision)
	{
		Debug.Log (collision.gameObject.tag);
		if (collision.gameObject.tag == "FootHead") 
		{
			Debug.Log ("FootHead");
			Destroy (this.gameObject);

		}
		else if(collision.gameObject.tag == "Sides") {
			Debug.Log ("Sides");
			Classes.Player playerC = player.GetComponent<Classes.Player> ();
			playerC.Damage (1);

			Invulnerability inv = (Invulnerability)playerC.GetSpell ("NP_Invulnerability");
            inv.SetDuration(1);
            playerC.ReceiveBuff(inv);
            inv.Cast();


		}
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if ((int)timer % 3 == 0&&timer>1) {
			Direction *= -1;
			jumpBody.AddForce (Vector3.up * 75);
		}
		transform.position += new Vector3 (Direction, 0, 0) * Time.deltaTime;
	}
}
