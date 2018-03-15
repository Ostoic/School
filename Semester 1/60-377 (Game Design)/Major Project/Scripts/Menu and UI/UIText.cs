using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIText : MonoBehaviour {

	public Text collectibleText;
    private int collectibleCount = 0;

	public Text enemyDestroyedText;
    private int enemyDestroyedCount = 0;

	public Text currentLevelText;
    private int currentLevel = 0;

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
	void Update ()
    {
		SetCollectibleText ();
		SetEnemyDestroyedText ();
		SetCurrentLevelText ();
	}
}
