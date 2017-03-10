using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terraingenerating : MonoBehaviour {

    public GameObject[] CliffTiles;
    public GameObject[] HillsTimes = new GameObject[10];
    public GameObject newTile;
    public GameObject nextAnchor;
    public int loopStop;
    public int DeleteLoop;
    public bool deleteStart;
	// Use this for initialization
	void Start () {
        DeleteLoop = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //if(Input.GetKey(KeyCode.G))
        {
            if(deleteStart)
            Destroy(HillsTimes[DeleteLoop]);
            int Rand = Random.Range(0, CliffTiles.Length-2);
            int rand2 = Random.Range(0, 10);
            if(rand2 == 1 && loopStop == 0)
            {
                Rand = CliffTiles.Length - 1;
                loopStop = 10;
            }
            if(rand2 == 2 && loopStop == 0)
            {
                Rand = CliffTiles.Length-2;
                loopStop = 10;
            }
            newTile = Instantiate(CliffTiles[Rand], nextAnchor.transform.position, nextAnchor.transform.rotation);
            nextAnchor = newTile.transform.GetChild(1).gameObject;
            if(loopStop >0)
                loopStop--;
            HillsTimes[DeleteLoop] = newTile;
            DeleteLoop++;
            if(DeleteLoop > HillsTimes.Length-1)
            {
                DeleteLoop = 0;
                deleteStart = true;
            }
        }

    }
}
