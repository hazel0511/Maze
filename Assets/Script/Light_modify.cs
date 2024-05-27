using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_modify : MonoBehaviour {

	Light playerlight;
	//[Header("燈光亮度")]
	//[Range(0,2)]

	//float lightimer=0;
	// Use this for initialization
	void Start () {
		playerlight = GameObject.Find ("Directional Light").GetComponent<Light> ();
	}
	float lightstrengh=0;
	// Update is called once per frame
	void Update () {
		//lightimer += Time.deltaTime * 1;
		if (Input.GetAxis("Mouse ScrollWheel")!=0) 
		{

			playerlight.intensity += Input.GetAxis("Mouse ScrollWheel"); 

		}
		if (playerlight.intensity >= 8) {
			playerlight.intensity = 8;
		}
		if (playerlight.intensity <= -8) {
			playerlight.intensity = -8;
		}
	}
}
