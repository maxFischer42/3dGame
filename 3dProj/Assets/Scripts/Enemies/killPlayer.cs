﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour {

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.transform.GetComponentInChildren<playerHealthHandler> ().HP = 0;
		}
	}

}
