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

	// Use this for initialization
	void Start ()
	{
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		playerVisible = checkForPlayer ();
		if (playerVisible)
		{
			Stop ();
		}


	}


	//is called when the player is seen
	private IEnumerator Stop()
	{
		target = null;
		yield return 1;
	}

	//is called when player is visible for more than 1 second
	private IEnumerator Arm()
	{

	}

	//is called when the object reaches it's target
	void changeTarget()
	{

	}

	//is called when the object reaches a movement point
	void OnTriggerEnter(Collider coll)
	{

	}

	void shoot()
	{

	}

	bool checkForPlayer()
	{
		Vector3 rayOrigin = transform.position;
		RaycastHit hit;
		laserLine.SetPosition(0, rayOrigin);
		if (Physics.Raycast(rayOrigin,GameObject.Find("Player").transform.position - transform.position, out hit, 250f))
		{
			laserLine.SetPosition (1, hit.point);
			if (hit.transform.gameObject.tag == "Player") {
				return true;
			}
		}
	}




}
