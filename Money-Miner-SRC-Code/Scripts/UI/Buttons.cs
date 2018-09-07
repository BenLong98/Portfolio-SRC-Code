using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour {

    CharacterMotor CM;

    public void ClickPlayButton() {
        SceneManager.LoadScene("World");
    }

    public void ClicktoPlayAgain() {
     
        SceneManager.LoadScene("World");
    }
    public void ClickBackButton()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public  void ClickQuitButton()
    {
        Application.Quit();
    }

}
