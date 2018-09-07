using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighScore : MonoBehaviour {

    public float score = 0;
    public float highscore = 0;
    string highscoreText = "HighScore";
    public Text highscoreGO;

    CharacterMotor CM;

	// Use this for initialization
	void Start () {
        CM = GetComponent<CharacterMotor>();
        highscore = PlayerPrefs.GetFloat(highscoreText);
		
	}
	
	// Update is called once per frame
	void Update () {
        score = (float)CM.playersMoney;
        highscoreGO.text = "Your Score : " + score.ToString() + " $";

        if (score > highscore)
        {
            PlayerPrefs.SetFloat(highscoreText, score);
            PlayerPrefs.Save();

        }

    }

     void OnDisable()
    {
        if (score > highscore) {
            PlayerPrefs.SetFloat(highscoreText, score);
            PlayerPrefs.Save();

        }
    }
}
