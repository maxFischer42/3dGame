using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Timeline;


public class levelEnd : MonoBehaviour {

	public Behaviour dir;
	public Camera cam;
	public GameObject group;


	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.name == "Player")
			{
			coll.gameObject.SetActive (false);
			group.SetActive (true);
			cam.enabled = true;
			dir.enabled = true;
			}
	}


}
