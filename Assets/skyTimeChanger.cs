using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyTimeChanger : MonoBehaviour {

    public float[] tilingPositions;
    public Renderer rend;
    public int currentStage;
    public int prevStage;
    public float lerpSpeed;
    public Color[] colours;
    public GameObject Sunlight;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.T))
        {
            currentStage++;
            prevStage++;
            if(currentStage>2)
            {
                currentStage = 0;
            }
            if (prevStage > 2)
            {
                prevStage = 0;
            }

        }
        rend.material.mainTextureScale = new Vector2(Mathf.Lerp(rend.material.mainTextureScale.x, tilingPositions[currentStage], lerpSpeed * Time.deltaTime), 1);
        Sunlight.GetComponent<Light>().color = Color.Lerp(Sunlight.GetComponent<Light>().color, colours[currentStage], lerpSpeed * Time.deltaTime);
    }
}
