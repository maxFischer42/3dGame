using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_volume : MonoBehaviour {

	public float volumeSet = 0.0f;


	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.GetComponent<AudioSource> () && gameObject.tag != "Player") {
			coll.gameObject.GetComponent<AudioSource> ().volume += volumeSet;
		}
	}

	void OnTriggerExit(Collider coll)
	{
		if (coll.gameObject.GetComponent<AudioSource> () && gameObject.tag != "Player") {
			coll.gameObject.GetComponent<AudioSource> ().volume -= volumeSet;
		}
	}
}
