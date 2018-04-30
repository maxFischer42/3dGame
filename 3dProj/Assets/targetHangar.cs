using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetHangar : MonoBehaviour {


	public Camera fpsCam;
	public LineRenderer laserLine;
	public Transform shipEnd;
	public Transform hangarPos;
	
	// Update is called once per frame
	void Update ()

	{
		Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (.5f, .5f, 0));
		RaycastHit hit;
		laserLine.SetPosition(0, shipEnd.position);
		laserLine.SetPosition (1, hangarPos.position);
	}


}
