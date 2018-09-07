using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public Text inv;
    public Text moneytext;
    int [] counts = new int[5];
    public float money;


    void Start()
    {
        moneytext.text = " ";

}

void Update () {
        inv.text = "Rocks/Ores/Gems Mined" 
            + "\n"+ " "+  "\n" +
            "Stone: " + counts[0]  +"\n" +
            "Coal: " + counts[4] + "\n" +
            "Iron: " + counts[1] + "\n" +
            "Gold: " + counts[2] + "\n" +
            "Diamond: " + counts[3] + "\n";
	}

    public void Add(int Blocktype, int count) {

        counts[Blocktype] += count;

    }

    public void AddMoneyToCounter(float amount, bool isAdding) {

        if (isAdding)
        {
            moneytext.color = Color.green;
            money = amount;
            moneytext.text = "+ " + money.ToString() + " $ \n";
           
           
        }
        else {
            moneytext.color = Color.red;
            money = amount;
            moneytext.text = "- " + money.ToString() + "$ \n";
        }

    }
}
