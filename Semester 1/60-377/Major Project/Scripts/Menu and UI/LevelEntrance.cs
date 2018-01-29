using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

namespace MenuUI
{
    [RequireComponent(typeof(Collider))]
    public class LevelEntrance : MonoBehaviour
    {
        public string levelName = "TitleScreen";

        void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Player"))
                SceneManager.LoadScene(this.levelName);
        }
    }
}