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
	public bool playerInRange = false;
	public bool beingUsed;
	bool step1;
	bool step2;
	bool step3;
	public GameObject[] beamOBJ;
	public Light[] lights;


	// Use this for initialization
	void Start ()
	{
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log (step1 +"" + step2 + "" + step3);
		timerPlus ();
		if (!beingUsed) {
			GetComponentInChildren<Animator> ().SetBool ("iswalking", true);
			playerVisible = checkForPlayer ();
			if (playerVisible && playerInRange) {
				timer = 0;
				Stop ();				
			} else {
				timer = 0;
				if (target == null) {
					target = points [0];
				}
				
			}
            agent.destination = target.position;
        } else {
			GetComponentInChildren<Animator> ().SetBool ("iswalking", false);

			for (int i = 0; i < lights.Length; i++) {
				lights [i].intensity += 0.1f;
			}



			Vector3 targetDir = GameObject.Find("Player").transform.position - transform.position;
			float step = lookSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0f);

			if (!playerVisible) {
				beingUsed = false;
				step1 = false;
				step2 = false;
				step3 = false;
			}

			if (!step1) {
				Debug.Log ("Target Acquired");
				//wait 1 second
				if (timer > 1) {
					timer = 0;

					Arm ();
				}
			} else if (!step2) {
				//wait 1 second
				if (timer > 2) {
					timer = 0;
					shoot ();
				}
			} else if (!step3) {
				if (timer > 3) {
					for (int i = 0; i < 4; i++) {
						beamOBJ [i].SetActive (false);
					}
					Debug.Log ("deacticating");
					step1 = false;
					step2 = false;
					beingUsed = false;
					playerVisible = false;
					playerInRange = false;
					timer = 0;
					for (int i = 0; i < lights.Length; i++) {
						lights [i].intensity = 1f;
					}
				}
			}




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
		beingUsed = true;
		step1 = false;
		step2 = false;
		step3 = false;
	}

	//is called when player is visible for more than 1 second
	void Arm()
	{
		step1 = true;

		Debug.Log ("Arming...");
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
		if (!beingUsed) {
			if (coll.gameObject.transform == target.gameObject.transform) {
				changeTarget ();
			}
		}

	}
    //is called when the object reaches a movement point
    void OnTriggerStay(Collider coll)
    {
        if (!beingUsed)
        {
            if (coll.gameObject.transform == target.gameObject.transform)
            {
                changeTarget();
            }
        }

    }


    void shoot()
	{
		step2 = true;
		for (int i = 0; i < 4; i++) {
			beamOBJ [i].SetActive (true);
		}
	}

	public bool checkForPlayer()
	{
		Vector3 rayOrigin = transform.position;
		RaycastHit hit;
		laserLine.SetPosition(0, rayOrigin);
		if (Physics.Raycast (rayOrigin, GameObject.Find ("Player").transform.position - transform.position, out hit)) {
			laserLine.SetPosition (1, hit.point);
			if (hit.transform.gameObject.tag == "Player") {
				return true;
				Debug.Log ("Player Noticed");
			} else {
				playerInRange = false;
				return false;
			}
		} else {
			playerInRange = false;
			return false;
		}
	}




}
