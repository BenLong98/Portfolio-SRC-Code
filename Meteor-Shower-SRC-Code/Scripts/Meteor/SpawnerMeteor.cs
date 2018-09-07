using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMeteor : MonoBehaviour {

    public GameObject Meteor;
    public GameObject MeteorMed;
    public GameObject MeteorLarge;
    public GameObject[] spawners;
    public bool spawning = false;
    public float timer = 0.0f;
    private GameObject MeteorChosenSize;

	void Start () {
        spawners = GameObject.FindGameObjectsWithTag("Spawn");
	}

    IEnumerator Spawn() {
        spawning = true;

        timer = 0;


        // int spawnerID = 0;
        //  spawnerID = Random.RandomRange(0, 80);
        //   Instantiate(Meteor, spawners[spawnerID].gameObject.transform.position, Quaternion.identity);

        

      // for (int i = 0; i < 5; i++) {
            int sPX = Random.Range(-20, 50);
            int sPY = Random.Range(10, 20);
            int spZ = Random.Range(-20, 30);

            Vector3 SP = new Vector3(sPX, sPY, spZ);

            int mSize = Random.Range(0, 3);

            if (mSize == 0) {
                MeteorChosenSize = Meteor;
            }
            if (mSize == 1) {
                MeteorChosenSize = MeteorMed;
            }
            if (mSize == 2) {
                MeteorChosenSize = MeteorLarge;
            }
           

            Instantiate(MeteorChosenSize, SP, Quaternion.identity);
     //   }
       
       

        yield return new WaitForSeconds(.0002f);

        spawning = false;
    }

    IEnumerator DestroyObject() {

        yield return new WaitForSeconds(2);

        Destroy(Meteor);

    }


	
	// Update is called once per frame
	void Update () {

        if (!spawning) {
            timer += Time.deltaTime;
        }

        if (timer >= .1) {
            StartCoroutine("Spawn");
        }

  

       
	}
}
