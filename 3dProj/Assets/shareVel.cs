using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shareVel : MonoBehaviour {

	public Rigidbody vel;
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody> ().velocity = vel.velocity;
	}
}
