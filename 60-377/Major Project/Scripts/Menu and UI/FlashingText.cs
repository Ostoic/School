using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FlashingText : MonoBehaviour {

	Text flashingText;

	void Start () {
		flashingText = GetComponent<Text> ();
		StartCoroutine(BlinkText());
	}

	public IEnumerator BlinkText(){
		//blink it forever. You can set a terminating condition depending upon your requirement
		while(true){
			//set the Text's text to blank
			flashingText.text= "";
			//display blank text for 0.5 seconds
			yield return new WaitForSeconds(.5f);
			//display “I AM FLASHING TEXT” for the next 0.5 seconds
			flashingText.text= "PRESS ANY BUTTON";
			yield return new WaitForSeconds(.5f);
		}
	}
}
