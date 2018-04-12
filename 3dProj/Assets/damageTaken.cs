using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageTaken : MonoBehaviour {


	public playerHealthHandler parentHP;


	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Damage") {
			parentHP.HP--;
		}
	}
}
