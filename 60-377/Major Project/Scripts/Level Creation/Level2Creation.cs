using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Creation : MonoBehaviour {
	GameObject Play;
	GameObject floor;
	GameObject nextNormalPlatform;
	GameObject nextHorizontalPlatform;
	GameObject nextVerticalPlatform;
	GameObject nextEnemyPlatform;

		int jumpDist=3;
		int spawnPt=0;

		int zoneCount=0;

		public static int endPt=10;
		int nextPtx;
		int nextPty;
		int ceiling=6;

		int newSize;

		// Use this for initialization

		private int platformSize()
		{
			return (Random.Range(1, 3));
		}

		void newScene(int nextx,int nexty, int end){
			while (nextx < end) {

			if (Random.Range (1, 20) == 2) {
				Instantiate (Resources.Load ("Powerup"), new Vector3 (nextx, 2, 0), Quaternion.identity);
			}
			if (Random.Range (1, 20) == 2) {
				Instantiate (Resources.Load ("Collectible"), new Vector3 (nextx, 2, 0), Quaternion.identity);
			}

			if (Random.Range (1, 10) == 2) {
				nextHorizontalPlatform=(GameObject)Instantiate (Resources.Load ("horizontalPlatform"), new Vector3 (nextx, nexty, 0), Quaternion.identity);
				nextHorizontalPlatform.AddComponent<Level2OutOfBounds> ();
			} else if (Random.Range (1, 10) == 3) {
				nextVerticalPlatform=(GameObject) Instantiate (Resources.Load ("VerticalPlatform"), new Vector3 (nextx, nexty, 0), Quaternion.identity);
				nextVerticalPlatform.AddComponent<Level2OutOfBounds> ();
			} else if (Random.Range (1, 10) == 4) {
				newSize = platformSize();
				nextEnemyPlatform=(GameObject)Instantiate (Resources.Load ("EnemySpawnPlatform"), new Vector3 (nextx, nexty, 0), Quaternion.identity);
				nextEnemyPlatform.AddComponent<Level2OutOfBounds> ();
				nextEnemyPlatform.transform.localScale = new Vector3 (platformSize(), 1, 10);
			} else {
				nextNormalPlatform=(GameObject)	Instantiate (Resources.Load ("Plat"), new Vector3 (nextx + (newSize), nexty, 0), Quaternion.identity);
				nextNormalPlatform.AddComponent<Level2OutOfBounds> ();
			}

				nextx += Random.Range (spawnPt, spawnPt + jumpDist);
				nexty = Random.Range (1, nexty + 4);
				if (nexty >= ceiling - 2) {
					nextPty = 5;
				}

			}
			nextPtx=nextx;
			nextPty=nexty;

	
		floor.transform.position+=new Vector3(10,0,0);
		zoneCount++;
		endPt+=10;
			if (zoneCount == 10) {
				Instantiate(Resources.Load("levelComplete"), new Vector3(105, 1, 0), Quaternion.identity);
			}

		}
		void Start () {
			Play=(GameObject.FindGameObjectWithTag("Player"));

			floor=(GameObject) Instantiate(Resources.Load("Floor"),new Vector3(-5,0,0), Quaternion.identity);
		endPt = 10;
			nextPtx = spawnPt;
			nextPty = Random.Range (1, 3);

			newScene(nextPtx,nextPty,endPt);
		}

		// Update is called once per frame
		void Update () {
			Play=(GameObject.FindGameObjectWithTag("Player"));

			//if(Input.GetKeyDown("p")){//change to player x coordinate
			if (zoneCount<10&&Play.transform.position.x > (endPt - 13)) {
				newScene (nextPtx, nextPty, endPt);
			}
		}
	}