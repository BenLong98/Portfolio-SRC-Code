using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunks : MonoBehaviour {

    /**
     * This class will be used to create chunks of ground, forever so the player
     * can gather as many materials as they can in the alloted time
     * 
     */

    public int WIDTH;
    public float HeightAM, smoothnessLevel;
    public int heightADD;
    [HideInInspector]
    public float seedNumber;

    //Basic Map Elements
    public GameObject Toplayer, Dirtfiller, Stone, BedRock;
    //Ores
    public GameObject IronBlock, DiamondBlock, GoldBlock, CoalBlock;
    public float chanceI, chanceD, chanceG, chanceUB;

	void Start () {

        CreateGround();
        seedNumber = Random.Range(-10000, 10000);
		
	}

    public void CreateGround() {

        for (int i = 0; i < WIDTH; i++) {
            int HGT = Mathf.RoundToInt(Mathf.PerlinNoise(seedNumber, (i + transform.position.x) / smoothnessLevel) * HeightAM) + heightADD;
            for (int k = 0; k < HGT; k++){
                GameObject currentBlock;
                if (k < HGT - 47) {
                    currentBlock = BedRock;
                }else if (k < HGT - 4)
                {
                    currentBlock = Stone;
                }
                else if (k < HGT - 1)
                {
                    currentBlock = Dirtfiller;
                }
                else {
                    currentBlock = Toplayer;
                }

                GameObject _chunkGen = Instantiate(currentBlock, Vector3.zero, Quaternion.identity) as GameObject;
                _chunkGen.transform.parent = this.gameObject.transform;
                _chunkGen.transform.localPosition = new Vector3(i, k);
            }
        }

        OreGeneration();
      
    }


  

    public void OreGeneration() {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Stone_Block")) {
            if (o.transform.parent == this.gameObject.transform)
            {
                float r = Random.Range(0f, 100f);
                GameObject currentBlock = null;
                if (r <= chanceD)
                {
                    currentBlock = DiamondBlock;
                }
                else if (r <= chanceG)
                {
                    currentBlock = GoldBlock;
                }
                else if (r <= chanceI)
                {
                    currentBlock = IronBlock;
                }
                else if (r <= chanceUB)
                {
                    currentBlock = CoalBlock;
                }

                if (currentBlock != null)
                {
                    GameObject newOre = Instantiate(currentBlock, o.transform.position, Quaternion.identity) as GameObject;
                    Destroy(o);
                }
            }
            
        }
    }

}
