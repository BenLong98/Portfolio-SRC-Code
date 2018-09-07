using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGen : MonoBehaviour {

    public int chuckNumber;
    int chunkW;
    float seedValue;
    public GameObject chunk;

    void Start () {
        chunkW = chunk.GetComponent<Chunks>().WIDTH;
        seedValue = Random.Range(-100000f, 100000);
        Gen();
	}


    public void Gen() {
        int prevX =  -chunkW;
        for (int i = 0; i < chuckNumber; i++) {
            GameObject nextChunk = Instantiate(chunk, new Vector3(prevX + chunkW, 0f), Quaternion.identity) as GameObject;
            nextChunk.GetComponent<Chunks>().seedNumber = seedValue;
            prevX += chunkW;
        }
    }
}
