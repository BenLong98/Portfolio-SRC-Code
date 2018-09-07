using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreEnd : MonoBehaviour {

    public Text highScoreText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        highScoreText.text = "Highscore : " + PlayerPrefs.GetInt("Highscore", 0);

    }
}
