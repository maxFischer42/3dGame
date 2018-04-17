using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldMovement : MonoBehaviour {

	[Tooltip("The locations the object will move towards")]
	public Transform[] pointsToMove;

	public Transform target;

	public int targetNum = 0;

	public float speed;

	private Rigidbody rig;

	void Start()
	{
		rig = GetComponent<Rigidbody> ();
		target = pointsToMove [targetNum];
	}
	// Update is called once per frame
	void Update ()
	{
		Vector3 dir = target.position - transform.position;
		dir.Normalize ();
		dir = dir * speed;
		rig.velocity = dir;
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "ShieldGenPoint") {
			targetNum++;
			if (targetNum == pointsToMove.Length) {
				targetNum = 0;
			}
			target = pointsToMove [targetNum];

		}
	}
}
