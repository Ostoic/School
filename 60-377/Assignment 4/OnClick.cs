using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour {

	Button button;

	void Start()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(loadScene);
	}

	void loadScene()
	{
		SceneManager.LoadScene ("level1");
	}
}
