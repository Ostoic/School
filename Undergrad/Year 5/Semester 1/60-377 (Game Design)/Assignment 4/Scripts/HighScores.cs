using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScores : MonoBehaviour {
    public Text level1Boss;
    public Text level2Boss;
    public Text level3Boss;

    public Text level1Party;
    public Text level2Party;
    public Text level3Party;


    // Use this for initialization
    void Start () {
          level1Boss.text = ("100");//just add high scores
      //  level1Boss.text = ("100");
      //  level2Boss.text = ("100");
      //  level3Boss.text = ("100");
        level1Party.text = ("100");
       // level2Party.text = ("100");
       // level3Party.text = ("100");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
