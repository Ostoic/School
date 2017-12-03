using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Objects
{
	public class Scoreboard : MonoBehaviour
	{
		private int itemsCollected = 0;
		public Text collectibleText;

		private int currentLevel = 0;
		public Text currentLevelText;

		private int kills = 0;
		public Text enemyDestroyedText;

		public int GetKills()
		{
			return this.kills;
		}

		public int GetItemsCollected()
		{
			return this.itemsCollected;
		}

		public int GetCurrentLevel()
		{
			return this.currentLevel;
		}

		public void AdvanceLevel()
		{
			this.currentLevel++;
		}

		public void RegisterKill()
		{
			this.kills++;
		}

		public void RegisterItemCollected()
		{
			this.itemsCollected++;
		}

		void SetCollectibleText()
		{
			collectibleText.text = "Collectibles: " + GetItemsCollected().ToString ();
        }
        void SetEnemyDestroyedText()
		{
			enemyDestroyedText.text = "Enemies Destroyed: " + GetKills ().ToString ();
		}
		void SetCurrentLevelText()
		{
            currentLevelText.text = "Current Level: " + GetCurrentLevel ().ToString ();
		}

		void Update () {
			SetCollectibleText ();
			SetEnemyDestroyedText ();
			SetCurrentLevelText ();
		}
	}
}