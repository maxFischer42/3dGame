using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCheckJuggernaut : MonoBehaviour {

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Player") {
			transform.parent.GetComponent<JuggernautMovement> ().playerInRange = true;
		}
	}
		
}
