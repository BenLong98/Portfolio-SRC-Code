using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SplashScreen : MonoBehaviour {

    public float timer = 2f;
    public string mainmenu = "Main_Menu";
    public Image blackbox;
    public Animator anim;

    // Use this for initialization
    void Start () {

        StartCoroutine("Splash");
		
	}

    IEnumerator Splash() {
        yield return new WaitForSeconds(timer);
        StartCoroutine("Fade");
        
    }


    IEnumerator Fade()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => blackbox.color.a == 1);
       SceneManager.LoadScene(mainmenu);
    }

}
