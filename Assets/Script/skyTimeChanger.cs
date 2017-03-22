using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyTimeChanger : MonoBehaviour {

    public float[] tilingPositions;
    public float[] tilingPositionsEnd;
    public Renderer rend;
    public int currentStage;
    public int prevStage;
    public bool isMidStage;

    public Color[] colours;
    public Color[] coloursEnd;
    public GameObject Sunlight;
    public Vector3[] sunRotations;
    public Vector3[] sunRotationsEnd;
    public GameObject stars;
    public Vector3[] StarScale;
    public Vector3[] StarScaleEnd;
    public GameObject sunObject;
    public Vector3[] sunObjRots;
    public Vector3[] sunObjRotsEnd;

    public float StageTransitionTimer;
    public float lerpSpeedChangeStage;
    public float lerpSpeedMidStage;
    public float lerpMidStageTimer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.T) && isMidStage)
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
            isMidStage = false;
        }
        if(isMidStage)
        {
            lerpMidStageTimer += Time.deltaTime;
            rend.material.mainTextureScale = new Vector2(Mathf.Lerp(tilingPositions[currentStage], tilingPositionsEnd[currentStage], lerpMidStageTimer / lerpSpeedMidStage), 1);
            Sunlight.GetComponent<Light>().color = Color.Lerp(colours[currentStage], coloursEnd[currentStage], lerpMidStageTimer / lerpSpeedMidStage);
            Sunlight.transform.rotation = Quaternion.Lerp(Quaternion.Euler(sunRotations[currentStage]), Quaternion.Euler(sunRotationsEnd[currentStage]), lerpMidStageTimer / lerpSpeedMidStage);
            stars.transform.localScale = Vector3.Lerp(StarScale[currentStage], StarScaleEnd[currentStage], lerpMidStageTimer / lerpSpeedMidStage);
            sunObject.transform.rotation = Quaternion.Lerp(Quaternion.Euler(sunObjRots[currentStage]), Quaternion.Euler(sunObjRotsEnd[currentStage]), lerpMidStageTimer / lerpSpeedMidStage);
            print("midstage code");
            
        }
        else
        {
            rend.material.mainTextureScale = new Vector2(Mathf.Lerp(rend.material.mainTextureScale.x, tilingPositions[currentStage], lerpSpeedChangeStage * Time.deltaTime), 1);
            Sunlight.GetComponent<Light>().color = Color.Lerp(Sunlight.GetComponent<Light>().color, colours[currentStage], lerpSpeedChangeStage * Time.deltaTime);
            Sunlight.transform.rotation = Quaternion.Lerp(Sunlight.transform.rotation, Quaternion.Euler(sunRotations[currentStage]), lerpSpeedChangeStage * Time.deltaTime);
            stars.transform.localScale = Vector3.Lerp(stars.transform.localScale, StarScale[currentStage], lerpSpeedChangeStage * Time.deltaTime);
            sunObject.transform.rotation = Quaternion.Lerp(sunObject.transform.rotation, Quaternion.Euler(sunObjRots[currentStage]), lerpSpeedChangeStage * Time.deltaTime);
            StageTransitionTimer += Time.deltaTime;
            if (StageTransitionTimer >= lerpSpeedChangeStage)
            {
                isMidStage = true;
                lerpMidStageTimer = 0;
                StageTransitionTimer = 0;
            }
            
        }
       
    }
}
