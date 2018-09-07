using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    void Update() {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Music");
        if (obj.Length > 1) {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        
    }

    
}
