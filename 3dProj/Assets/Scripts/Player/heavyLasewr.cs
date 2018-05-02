using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavyLasewr : MonoBehaviour {

	void OnTriggerEnter(Collider Coll)
	{
		if (Coll.GetComponent<enemyHealthHandler> ()) {
			Coll.GetComponent<enemyHealthHandler> ().maxHP = 0;
		}
	}
}
