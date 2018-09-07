using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningCoin : MonoBehaviour {

    public float speed = 10f;
    public int coinValue = 25;

	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(new Vector3(1, 0 , 0), speed * Time.deltaTime);
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>().Score += coinValue;
          Destroy(gameObject);
        }
    }
}
