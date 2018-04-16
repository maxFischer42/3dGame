using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthHandler : MonoBehaviour {

	public int maxHP;
	public GameObject wreckage;

	
	// Update is called once per frame
	void Update ()
	{
		if (maxHP <= 0) {
			GameObject wreck = (GameObject) Instantiate (wreckage, transform.position, Quaternion.identity);
			wreck.transform.parent = null;
			Destroy (gameObject);
		}
	}



}
