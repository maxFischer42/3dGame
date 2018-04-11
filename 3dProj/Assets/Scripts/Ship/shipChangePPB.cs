using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class shipChangePPB : MonoBehaviour {

	public PostProcessingBehaviour PPB;
	public PostProcessingProfile normal;
	public PostProcessingProfile speed;


	
	// Update is called once per frame
	void Update ()
	{

		if (GetComponent<Rigidbody> ().velocity.z > 70) {
			PPB.profile = speed;
		} else {
			PPB.profile = normal;
		}


	}
}
