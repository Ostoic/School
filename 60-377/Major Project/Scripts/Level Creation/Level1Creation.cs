using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Creation : MonoBehaviour {
	
	int jumpDist=3;
	int spawnPt=0;
	public static int endPt=10;

	int zoneCount=0;

	int nextPtx;
	int nextPty;
	int ceiling=6;
	int newSize;

	//float playerPosition;


	GameObject Play;
	GameObject floor;
	GameObject Platform;
	GameObject nextNormalPlatform;
	GameObject nextHorizontalPlatform;
	GameObject nextVerticalPlatform;
	GameObject nextEnemyPlatform;
	// Use this for initialization

	private int platformSize()
	{
		return (Random.Range(3, 6));
	}

	void newScene(int nextx,int nexty, int end)
    {

		while (nextx < end) {

		if (Random.Range (1, 20) == 2) {
			Instantiate (Resources.Load ("Powerup"), new Vector3 (nextx, 2, 0), Quaternion.identity);
		}

		if (Random.Range (1, 20) == 2) {
			Instantiate (Resources.Load ("Collectible"), new Vector3 (nextx, 2, 0), Quaternion.identity);
		}

        int choosePlatform = Random.Range(1, 10);

		if (Random.Range (1, 10) == 2) {
			newSize = platformSize();
			nextHorizontalPlatform=(GameObject)	Instantiate (Resources.Load ("horizontalPlatform"), new Vector3 (nextx + (newSize), nexty, 0), Quaternion.identity);
			nextHorizontalPlatform.AddComponent<level1OutOfBounds> ();
			nextHorizontalPlatform.transform.localScale = new Vector3 (newSize, 1, 10);
		//	Instantiate (Resources.Load ("horizontalPlatform"), new Vector3 (nextx, nexty, 0), Quaternion.identity);
		} else if (Random.Range (1, 10) == 3) {
			newSize = platformSize();
			nextVerticalPlatform=(GameObject)	Instantiate (Resources.Load ("verticalPlatform"), new Vector3 (nextx + (newSize), nexty, 0), Quaternion.identity);
			nextVerticalPlatform.AddComponent<level1OutOfBounds> ();
			nextVerticalPlatform.transform.localScale = new Vector3 (newSize, 1, 10);
			//Instantiate (Resources.Load ("VerticalPlatform"), new Vector3 (nextx, nexty, 0), Quaternion.identity);
		} else if (Random.Range (1, 5) == 4) {		
			newSize = platformSize();
			nextEnemyPlatform=(GameObject)Instantiate (Resources.Load ("EnemySpawnPlatform"), new Vector3 (nextx, nexty, 0), Quaternion.identity);
			nextEnemyPlatform.AddComponent<level1OutOfBounds> ();
			nextEnemyPlatform.transform.localScale = new Vector3 (platformSize(), 1, 10);
		} else {
			newSize = platformSize();
			nextNormalPlatform=(GameObject)	Instantiate (Resources.Load ("Plat"), new Vector3(nextx+newSize,nexty,0), Quaternion.identity);
			nextNormalPlatform.AddComponent<level1OutOfBounds> ();
			nextNormalPlatform.transform.localScale = new Vector3 (platformSize(), 1, 10);
		}

		nextx += Random.Range (spawnPt, spawnPt + (jumpDist+newSize*2));
			nexty = Random.Range (1, nexty + 4);
			if (nexty >= ceiling - 2) {
				nextPty = 5;
			}

		}
		nextPtx=nextx;
		nextPty=nexty;
		endPt+=10;
		floor.transform.position+=new Vector3(10,0,0);
		zoneCount++;

		if (zoneCount == 10) {
			Instantiate(Resources.Load("levelComplete"), new Vector3(105, 1, 0), Quaternion.identity);
		}

	}
	void Start () 
    {
	    endPt = 10;

		Play=(GameObject.FindGameObjectWithTag("Player"));
		floor=(GameObject) Instantiate(Resources.Load("Floor"),new Vector3(-5,0,0), Quaternion.identity);

		nextPtx = spawnPt;
		nextPty = Random.Range (1, 3);

		newScene(nextPtx,nextPty,endPt);
	}

	// Update is called once per frame
	void Update ()
    {
		Play=(GameObject.FindGameObjectWithTag("Player"));

		if (zoneCount < 10 && Play.transform.position.x > (endPt - 13)) {
			newScene (nextPtx, nextPty, endPt);
		}
	}
}