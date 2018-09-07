using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour {

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish") {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }

    void Update () {
        transform.Translate(new Vector3(0f, -40f * Time.deltaTime, 0f));
	}
}
