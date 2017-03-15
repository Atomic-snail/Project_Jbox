using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beat : MonoBehaviour {
    AudioSource source;

    float[] spectrum = new float[64];
    Material mat;
    public GameObject car;
    public float smoothValue;
    public float smoothValue2;

   public bool pulse = false;
   public bool pulse2 = false;

    public int index = 0;



    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        mat = car.GetComponent<Renderer>().material;
        float scale = car.transform.lossyScale.z;
        scale = scale / 2;
        //mat.SetFloat("_Scale",scale);
	}
	
	// Update is called once per frame
	void Update () {
        source.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);
        //Vector3 pos = transform.position;
        //pos.y = pos.y*0.9f + spectrum[0]*0.1f;
        //transform.position = pos;

        if (spectrum[1] > 0.05 && !pulse)
        {
            pulse = true;
            smoothValue = 0;
        }
        if (pulse)
        {
            smoothValue += Time.deltaTime * 4.0f;
            if (smoothValue > 1.8f)
            {
                pulse = false;
                smoothValue = 0;
            }
        }

        mat.SetFloat("_Music", smoothValue);




        if (spectrum[10] > 0.1f && !pulse2)
        {
            pulse2 = true;
            smoothValue2 = 0;
        }
        if (pulse2)
        {
            smoothValue2 += Time.deltaTime * 20.0f;
            if (smoothValue2 > 5.0f)
            {
                pulse2 = false;
                smoothValue2 = 0;
            }
        }
        //smoothValue = smoothValue * 0.9f + spectrum[0] * 0.1f;
        //mat.SetFloat("_Music", Mathf.Sin (smoothValue));
      
        //mat.SetFloat("_Music2", smoothValue2);
        for (int i = 1; i<64; ++i)
        {
            Debug.DrawLine(new Vector3((i - 1)/100f, spectrum[i - 1],0), new Vector3(i/100, spectrum[i], 0), Color.red);
        }
	}
}
