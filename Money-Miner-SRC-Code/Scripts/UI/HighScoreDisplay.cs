using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour {

    public float highScore;
    string highscoreText = "HighScore";
    public Text HighScoreText;

    // Use this for initialization
    void Start () {
        highScore = PlayerPrefs.GetFloat(highscoreText, 0);

        // HighScoreText = GetComponent<Text>();

    }

   public void UpdateHighscore() {
        highScore = PlayerPrefs.GetFloat(highscoreText, 0);
        HighScoreText.text = "Your Personal Best: " + highScore.ToString() + " $";
    }
	
	// Update is called once per frame
	void Update () {
        highScore = PlayerPrefs.GetFloat(highscoreText, 0);
        HighScoreText.text = "Your Personal Best: " + highScore.ToString() + " $";
		
	}
}
