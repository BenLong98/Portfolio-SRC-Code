using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreController : MonoBehaviour {


    public int Score;
    public Text scoreText;
    public Text highScoreText;

 

    // Use this for initialization
    void Start () {
        Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score : " + Score;
        highScoreText.text = "Highscore : " + PlayerPrefs.GetInt("Highscore", 0);


        int a = PlayerPrefs.GetInt("Highscore");

        if (Score > a)
        {
            PlayerPrefs.SetInt("Highscore", Score);
        }

    }


    public void SetScore(int p) {
        Score = p;
    }

    public void GivePoints(int p) {
        p += Score;
    }

    public void TakeAwayPoints(int p) {
        p -= Score;
    }
}
