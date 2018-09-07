using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class GroundBlockController : MonoBehaviour {

   private Rigidbody rb;
    Color purple = new Color32(153, 50, 204, 255);
    public Texture walkedTexture;
    public GameObject coinObj;
    public int walkValue = 1;
    public int findValue = 5;

    private AudioSource audioSource;
    public AudioClip Crash;
    
   // ScoreController scoreController;

     void Start()
    {
        rb = GetComponent<Rigidbody>();

        //scoreController = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();


    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Meteor") {
            rb.isKinematic = false;
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = Crash;
            audioSource.Play();
        }

        if (collision.gameObject.tag == "Player") {
                GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>().Score += walkValue;
            
            gameObject.GetComponent<Renderer>().material.mainTexture = walkedTexture;
            //Givepoints

           

            int GemItem = Random.Range(0, 50);

            if (GemItem % 10 == 0) {
                /// THIS IS WHERE YOU INSTANTIATE THE GEM ITEMS THAT ARE FOUND ON THE GROUND!!!!
               
                Vector3 nVector3 = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>().Score += findValue;
                Quaternion rotationL = Quaternion.Euler(0, 0, 90);
                Instantiate(coinObj, nVector3, rotationL);
            }

        }
            if (collision.gameObject.tag == "Finish")
            {
                Destroy(gameObject);
            }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            rb.isKinematic = false;
        }
    }
}
