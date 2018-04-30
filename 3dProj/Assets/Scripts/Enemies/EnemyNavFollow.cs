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
		}
	}

	void OnTriggerExit(Collider Coll)
	{
		if (Coll.transform.name == "footStepRadius") {
			isChasingPoint = false;
		}
	}
}
