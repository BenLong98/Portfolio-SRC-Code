using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class UIMoney : MonoBehaviour {

    public Text currentmoney;
    CharacterMotor CM;

	// Use this for initialization
	void Start () {

        CM = GetComponent<CharacterMotor>();
		
	}
	
	// Update is called once per frame
	void Update () {

        currentmoney.text = "Money: " + CM.playersMoney +" $";
		
	}
}
