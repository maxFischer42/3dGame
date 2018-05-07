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
	public Transform sightLine;

	void Start ()
	{
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		check ();
		if (!priorityPlayer) {
			if (!isChasingPoint) {
				player = points [Random.Range (0, points.Length)];
				isChasingPoint = true;
				Vector3 targetDir = player.position - transform.position;
				float step = lookSpeed * Time.deltaTime;
				Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0f);
               

            }
            agent.destination = player.position;
            if (agent.destination == null)
            {
                agent.destination = points[0].position;
            }
        }
		if (priorityPlayer) {
			player = null;
			agent.destination = transform.position;
		}


        
	}


	void OnTriggerEnter(Collider Coll)
	{
		if (Coll.transform == player) {
			player = points [Random.Range (0, points.Length)];
		}
	}

	void OnTriggerStay(Collider Coll)
	{
		if (Coll.transform == player) {
			player = points [Random.Range (0, points.Length)];
		}
	}

	void OnTriggerExit(Collider Coll)
	{
		if (Coll.transform.name == "footStepRadius") {
			isChasingPoint = false;
		}
	}



	void check()
	{
		Vector3 rayOrigin = transform.position;
		rayOrigin = new Vector3 (rayOrigin.x, rayOrigin.y + 1, rayOrigin.z);
		RaycastHit hit;
        Vector3 dir = GameObject.Find("Player").transform.position - transform.position;
        laserLine.SetPosition(0, rayOrigin);
		if (Physics.Raycast(rayOrigin,transform.forward, out hit, 200f))
		{
			laserLine.SetPosition (1, hit.point);
			//Debug.Log (hit.collider.gameObject.name);
			if (hit.collider.transform.gameObject.tag == "Player") {
				priorityPlayer = true;
				shootScript.enabled = true;
				GetComponent<Rigidbody> ().velocity = Vector3.zero;
                Vector3 targetDir = player.position - transform.position;
                float step = lookSpeed * 2 * Time.deltaTime;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, hit.collider.transform.position, step, 0.0f);
            } else {
				priorityPlayer = false;
				shootScript.enabled = false;
			}
		}
	}
}
