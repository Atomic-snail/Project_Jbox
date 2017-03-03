using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steering : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.A))
        {
            Vector3 newPos = transform.localPosition;
            if (newPos.x < 2.5f)
                newPos.x += .1f;
            transform.localPosition = newPos;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 newPos = transform.localPosition;
            if(newPos.x >-2.5f)
            newPos.x -= .1f;
            transform.localPosition = newPos;
        }
    }
}
