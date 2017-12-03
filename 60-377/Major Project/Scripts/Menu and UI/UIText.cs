using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIText : MonoBehaviour {

	public Text collectibleText;
	private int collectibleCount;

	public Text enemyDestroyedText;
	private int enemyDestroyedCount;

	public Text currentLevelText;
	private int currentLevel;

	//scriptA scriptAInstance = GetComponent<scriptA>();

	// Use this for initialization
	void Start () {
		collectibleCount = 0;
		enemyDestroyedCount = 0;
		currentLevel = 0;
	}

	void SetCollectibleText()
	{
		collectibleText.text = "Collectibles: " + collectibleCount.ToString ();
	}
	void SetEnemyDestroyedText()
	{
		enemyDestroyedText.text = "Enemies Destroyed: " + enemyDestroyedCount.ToString ();
	}
	void SetCurrentLevelText()
	{
		currentLevelText.text = "Current Level: " + currentLevel.ToString ();
	}

	// Update is called once per frame
	void Update () {
		SetCollectibleText ();
		SetEnemyDestroyedText ();
		SetCurrentLevelText ();

//		Scoreboard other = gameObject.GetComponent<Scoreboard> ();
//		other.GetItemsCollected ();

	}
}
