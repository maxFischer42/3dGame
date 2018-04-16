using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableAudioSources : MonoBehaviour {

	void OnTriggerEnter(Collider Coll)
	{
		if (Coll.transform.gameObject.tag == "Enemy" && Coll.GetComponent<AudioSource>())
		{
			Coll.GetComponent<AudioSource> ().enabled = true;
		}
	}
	void OnTriggerStay(Collider Coll)
	{
		if (Coll.transform.gameObject.tag == "Enemy" && Coll.GetComponent<AudioSource>())
		{
			Coll.GetComponent<AudioSource> ().enabled = true;
		}
	}
	void OnTriggerExit(Collider Coll)
	{
		if (Coll.transform.gameObject.tag == "Enemy" && Coll.GetComponent<AudioSource>())
		{
			Coll.GetComponent<AudioSource> ().enabled = false;
		}
	}


}
