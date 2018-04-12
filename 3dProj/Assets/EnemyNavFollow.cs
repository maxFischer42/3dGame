using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavFollow : MonoBehaviour {

    // Use this for initialization
    public Transform player;
	public Transform[] points;
	public bool isChasingPoint;
	public float lookSpeed;
	public bool priorityPlayer;
    NavMeshAgent agent;
	public LineRenderer laserLine;
	public enemyShoot shootScript;

	void Start ()
	{
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!priorityPlayer) {
			if (!isChasingPoint) {
				player = points [Random.Range (0, points.Length)];
				isChasingPoint = true;
			}
		}
		if (priorityPlayer) {
			player = GameObject.Find ("Player").GetComponent<Transform> ();
		}
		Vector3 targetDir = player.position - transform.position;
		float step = lookSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0f);

        agent.destination = player.position;
	}

	void OnTriggerEnter(Collider Coll)
	{
		if (Coll.transform == player) {
			isChasingPoint = false;
		} else if (Coll.transform.name == "PlayerVisionCone" || Coll.transform.name == "footStepRadius") {

			Vector3 rayOrigin = transform.position;
			RaycastHit hit;
			laserLine.SetPosition(0, rayOrigin);
			if (Physics.Raycast(rayOrigin,GameObject.Find("Player").transform.position - transform.position, out hit, 999f))
			{
				laserLine.SetPosition (1, hit.point);
				if (hit.transform.gameObject.tag == "Player") {
					priorityPlayer = true;
					shootScript.enabled = true;
				}
			}


		}
	}

	void OnTriggerExit(Collider Coll)
	{
		if (Coll.transform.name == "footStepRadius") {
			priorityPlayer = false;
			shootScript.enabled = false;
		}
	}
}
