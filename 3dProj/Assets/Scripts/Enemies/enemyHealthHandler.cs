using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthHandler : MonoBehaviour {

	public int maxHP;
	public GameObject wreckage;
	public bool isShield;
	public shieldHealth shieldScript;

	
	// Update is called once per frame
	void Update ()
	{
		if (maxHP <= 0 && !isShield) {
			GameObject wreck = (GameObject)Instantiate (wreckage, transform.position, Quaternion.identity);
			wreck.transform.parent = null;
			Destroy (gameObject);
		} else if (maxHP <= 0 && isShield) {
			shieldScript.hp--;
			GameObject wreck = (GameObject)Instantiate (wreckage, transform.position, Quaternion.identity);
			wreck.transform.parent = null;
			Destroy (gameObject);
		}
	}



}
