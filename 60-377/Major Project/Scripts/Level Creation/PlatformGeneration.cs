using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour {

	int jumpDist=3;
	int spawnPt=0;

	int zoneCount=0;

	public static int endPt=10;
	int nextPtx;
	int nextPty;
	int ceiling=6;

	float playerPosition;
    int newSize;
    GameObject Play;
	GameObject floor;
	GameObject Platform;
    // Use this for initialization

    private int platformSize()
    {
        return (Random.Range(1, 3));
    }

    void newScene(int nextx,int nexty, int end){
		while (nextx < end) {
			if (Random.Range (1, 10) == 2) {
				Instantiate (Resources.Load ("horizontalPlatform"), new Vector3 (nextx, nexty, 0), Quaternion.identity);
			} else if (Random.Range (1, 10) == 3) {
				Instantiate (Resources.Load ("VerticalPlatform"), new Vector3 (nextx, nexty, 0), Quaternion.identity);
			} else if (Random.Range (1, 10)==4) {
				Instantiate (Resources.Load ("EnemTwoSpawn"), new Vector3 (nextx, nexty, 0), Quaternion.identity);
			}
            else Instantiate(Resources.Load("Plat"), new Vector3(nextx + (newSize), nexty, 0), Quaternion.identity);
            
            nextx += Random.Range (spawnPt, spawnPt + jumpDist);
			nexty = Random.Range (1, nexty + 4);
			if (nexty >= ceiling - 2) {
				nextPty = 5;
			}

		}
		nextPtx=nextx;
		nextPty=nexty;
		endPt+=10;
		Instantiate(floor, floor.transform.position += new Vector3 (10,0,0),Quaternion.identity);
		zoneCount++;

		if (zoneCount == 3) {
			Instantiate(Resources.Load("levelComplete"), new Vector3(35, 0, 0), Quaternion.identity);
		}

	}
	void Start () {
		Play=(GameObject.FindGameObjectWithTag("Player"));
		floor=(GameObject) Instantiate(Resources.Load("Plat"),new Vector3(-5,0,0), Quaternion.identity);
		floor.transform.localScale+=new Vector3 (10, 0, 0);
		nextPtx = spawnPt;
		nextPty = Random.Range (1, 3);
		Platform= (GameObject) Instantiate(Resources.Load("Plat"),new Vector3(3,3,0), Quaternion.identity);
//		nextPt = Random.Range (spawnPt, spawnPt + jumpDist);
		newScene(nextPtx,nextPty,endPt);
		print (nextPtx);
		print (nextPty);
		print (endPt);
	}

	// Update is called once per frame
	void Update () {
		Play=(GameObject.FindGameObjectWithTag("Player"));
	
		//if(Input.GetKeyDown("p")){//change to player x coordinate
		if (zoneCount<3&&Play.transform.position.x > (endPt - 13)) {
			newScene (nextPtx, nextPty, endPt);
		}
	}
}