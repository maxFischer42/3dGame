using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passThroughActivate : MonoBehaviour {

	public Behaviour[] behaviours;
	public GameObject[] GO;
	public string tagToEnter;

	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == tagToEnter) {
			for (int i = 0; i < behaviours.Length; i++) {
				behaviours [i].enabled = true;
			}
			for (int i = 0; i < GO.Length; i++) {
				GO [i].SetActive (true);
			}
		}
	}

}
