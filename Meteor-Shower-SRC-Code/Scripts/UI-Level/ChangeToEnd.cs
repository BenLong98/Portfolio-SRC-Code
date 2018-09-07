using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToEnd : MonoBehaviour {


    public void GoToEnd() {
        SceneManager.LoadScene("EndMenu", LoadSceneMode.Single);
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void ExitApp() {
        Application.Quit();
    }

    public void PlayGame() {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);

    }
}
