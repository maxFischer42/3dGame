using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipExceeds : MonoBehaviour {

	public Vector2 X;
	public Vector2 Y;
	public float pushForce;


	// Update is called once per frame
	void Update ()
	{
		Vector2 pos = gameObject.transform.position;
		Vector3 vel = GetComponent<Rigidbody> ().velocity;
		vel.Normalize ();
		vel *= -1;
		if (pos.x > X.y) {
			GetComponent<Rigidbody> ().AddForce (pushForce * vel);
		}
		else if (pos.x < X.x) {
			GetComponent<Rigidbody> ().AddForce (-pushForce * vel);
		}
		if (pos.y > Y.y) {
			GetComponent<Rigidbody> ().AddForce (pushForce * vel);
		}
		else if (pos.y < Y.x) {
			GetComponent<Rigidbody> ().AddForce (-pushForce * vel);
		}
	}
}
