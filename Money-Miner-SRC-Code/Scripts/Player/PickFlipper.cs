using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFlipper : MonoBehaviour {


    public GameObject player;
    Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }
	
	void Update () {
        CharacterMotor CM = player.GetComponent(typeof(CharacterMotor)) as CharacterMotor;
        if (!CM.towardRight)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        anim.SetBool("IsMining", CM.isMining);

	}
}
