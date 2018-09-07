using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAudioSource : MonoBehaviour {

    public GameObject source;

	// Use this for initialization
	void Start () {
        Instantiate(source, Vector3.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {

        if (GameObject.FindGameObjectsWithTag("Music").Length == 0)
        {
            Instantiate(source, Vector3.zero, Quaternion.identity);
        }
		
	}
}
