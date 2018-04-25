using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JuggernautMovement : MonoBehaviour {

	public Transform target;
	public Transform[] points;
	public bool isChasingPoint;
	public float lookSpeed;
	NavMeshAgent agent;
	public LineRenderer laserLine;
	public bool playerVisible;
	public LineRenderer beam;
	public LineRenderer bigBeam;
	Transform prevPoint;
	float timer = 0;

	// Use this for initialization
	void Start ()
	{
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		timerPlus ();
		playerVisible = checkForPlayer ();
		if (playerVisible) {
			Stop ();

		} else {
			timer = 0;
			if (target == null) {
				target = points [0];
			}
			agent.destination = target.position;
		}

	}


	void timerPlus()
	{
		timer += Time.deltaTime;
	}



	//is called when the player is seen
	void Stop()
	{
		agent.destination = transform.position;
		target = null;
		Vector3 targetDir = GameObject.Find("Player").transform.position - transform.position;
		float step = lookSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0f);
		//wait 1 second
		if (timer > 5) {
			timer = 0;
			Debug.Log ("Target Acquired");
			Arm ();
		}
	}

	//is called when player is visible for more than 1 second
	void Arm()
	{
		Vector3 rayOrigin = transform.position;
		RaycastHit hit;
		beam.SetPosition(0, rayOrigin);
		if (Physics.Raycast(rayOrigin,GameObject.Find("Player").transform.position - transform.position, out hit, 250f))
		{
			beam.SetPosition (1, hit.point);
			if (hit.transform.gameObject.tag == "Player") {
				Debug.Log ("Arming...");
			
				//wait 1 second
				if (timer > 9) {
					timer = 0;
					shoot ();
				}

			} else {
				playerVisible = false;
			}
		}
	}

	//is called when the object reaches it's target
	void changeTarget()
	{
		//GetComponent<Rigidbody> ().velocity = Vector3.zero;
		//transform.rotation = Quaternion.identity;
		int rand = Random.Range (0, points.Length - 1);
		if (points [rand] != prevPoint) {
			target = points [rand];
		} else {
			changeTarget ();
		}
	}

	//is called when the object reaches a movement point
	void OnTriggerEnter(Collider coll)
	{
		if (!playerVisible && coll.gameObject.transform == target.gameObject.transform) {
			changeTarget ();
		}
	}


	void shoot()
	{
		
	}

	bool checkForPlayer()
	{
		Vector3 rayOrigin = transform.position;
		RaycastHit hit;
		laserLine.SetPosition(0, rayOrigin);
		if (Physics.Raycast (rayOrigin, GameObject.Find ("Player").transform.position - transform.position, out hit, 250f)) {
			laserLine.SetPosition (1, hit.point);
			if (hit.transform.gameObject.tag == "Player") {
				return true;
				Debug.Log ("Player Noticed");
			} else {
				return false;
			}
		} else {
			return false;
		}
	}




}
