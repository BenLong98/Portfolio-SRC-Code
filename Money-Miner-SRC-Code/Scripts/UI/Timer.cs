using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

    //2 minutes
    public int currentTime = 120;
    public Text counter;
    public bool hasRunOutOfTime;

    public GameObject FailureScreen;
    HighScoreDisplay HSD;

	
	void Start () {
        StartCoroutine("TimerGO");
        hasRunOutOfTime = false;

	}
	
	// Update is called once per frame
	void Update () {

        counter.text = "Time Left: " + currentTime;

        if (currentTime <= 0)
        {
            StopCoroutine("TimerGO");
            counter.text = "Time's Up!";
            hasRunOutOfTime = true;
            //Open death menu here to restart or go back to the main screen
            FailureScreen.SetActive(true);
          //  HSD.UpdateHighscore();


        }
        else {
            FailureScreen.SetActive(false);
        }
		
	}

    IEnumerator TimerGO() {
        while (true) {
            yield return new WaitForSeconds(1);
            currentTime--;
        }
    }
}
