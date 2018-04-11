using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockShip : MonoBehaviour {

	public Vector3 shipVelocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		shipVelocity = GetComponent<Rigidbody> ().velocity;
		float currAngle = transform.rotation.eulerAngles.x;
		if (currAngle >= 45 && currAngle < 150) {
			transform.Rotate (-3, 0, 0);
		}
		else if(currAngle <= 315 && currAngle > 150)
		{
			transform.Rotate (3, 0, 0);
		}
		

	}
}
