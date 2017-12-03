using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Classes
{
    public class CreateEnemy : Unit
    {
		int EnemyNum;
        // Use this for initialization
        void Start()
        {
			EnemyNum=Random.Range(1,6);
			if (EnemyNum == 1) {
				Instantiate (Resources.Load ("EnemyOne"), new Vector3 (transform.position.x, transform.position.y + 1, 0), Quaternion.identity);
		}
			else if (EnemyNum == 2) {
				Instantiate (Resources.Load ("EnemyTwo"), new Vector3 (transform.position.x, transform.position.y + 1, 0), Quaternion.identity);
			} else if (EnemyNum == 3) {
				Instantiate (Resources.Load ("GroomMama"), new Vector3 (transform.position.x, transform.position.y + 1, 0), Quaternion.identity);
			} else if (EnemyNum == 4) {
				Instantiate (Resources.Load ("Fireball"), new Vector3 (transform.position.x, transform.position.y + 7, 0), Quaternion.identity);
			} else {
				Instantiate (Resources.Load ("Groomba"), new Vector3 (transform.position.x, transform.position.y + 1, 0), Quaternion.identity);
			}
        }
    }
}