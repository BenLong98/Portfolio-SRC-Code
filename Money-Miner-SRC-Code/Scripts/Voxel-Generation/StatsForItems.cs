using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatsForItems : MonoBehaviour {

   
    public Text stoneWorth;
    public Text IronWorth;
    public Text GoldWorth;
    public Text DiamondWorth;
    public Text CoalWorth;


    public float moneyForStone = 0f;
    public float moneyForCoal = 0f;
    public float moneyForIron = 0f;
    public float moneyForGold = 0f;
    public float moneyForDiamond = 0f;

  

    void Update()
    {
      //  GatherResources();
    }

    public void GatherResources() {

        //Stone
        stoneWorth.color = Color.red;
        stoneWorth.text = "- " + moneyForStone.ToString() + " $";

        //Coal
        CoalWorth.color = Color.green;
        CoalWorth.text = "+ " + moneyForCoal.ToString() + " $";

        //Iron
        IronWorth.color = Color.green;
        IronWorth.text = "+ " + moneyForIron.ToString() + " $";

        //Gold
        GoldWorth.color = Color.green;
        GoldWorth.text = "+ " + moneyForGold.ToString() + " $";

        //Diamond
        DiamondWorth.color = Color.green;
        DiamondWorth.text = "+ " + moneyForDiamond.ToString() + " $";

        

    }


}
