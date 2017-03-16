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
    public Vector3[] sunRotations;
    public GameObject stars;
    public Vector3[] StarScale;
    public GameObject sunObject;
    public Vector3[] sunObjRots;

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
        Sunlight.transform.rotation = Quaternion.Lerp(Sunlight.transform.rotation, Quaternion.Euler(sunRotations[currentStage]), lerpSpeed * Time.deltaTime);
        stars.transform.localScale = Vector3.Lerp(stars.transform.localScale, StarScale[currentStage], lerpSpeed * Time.deltaTime);
        sunObject.transform.rotation = Quaternion.Lerp(sunObject.transform.rotation, Quaternion.Euler(sunObjRots[currentStage]), lerpSpeed * Time.deltaTime);
    }
}
