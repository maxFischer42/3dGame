using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour {

	public Transform barrelEnd;

	public LineRenderer laserLine;

	public float range = 10f;

	public GameObject bullet;

	public float bulletSpeed = 5f;

	public float coolDown = 2f;
	float cooldowntimer = 0;
	public AudioSource audi;

	
	// Update is called once per frame
	void Update ()
	{
		cooldowntimer += Time.deltaTime;
		Vector3 rayOrigin = barrelEnd.position;
		RaycastHit hit;
		laserLine.SetPosition(0, barrelEnd.position);
		if (Physics.Raycast(rayOrigin,barrelEnd.transform.forward, out hit, range))
		{
			laserLine.SetPosition (1, hit.point);
			//Debug.Log (hit.collider.gameObject.name);
			if (hit.transform.gameObject.tag == "Player" && coolDown <= cooldowntimer)
			{
				audi.Play ();
				cooldowntimer = 0f;
				Vector3 direction = GameObject.FindGameObjectWithTag ("Player").transform.position - transform.position;
				direction *= bulletSpeed;
				GameObject bulletToSpawn = (GameObject) Instantiate (bullet, transform.position, transform.rotation);
				bulletToSpawn.GetComponent<Rigidbody> ().velocity = direction;
				Vector3 newDir = Vector3.RotateTowards (transform.forward, direction, 1f, 0.0f);
				bulletToSpawn.transform.rotation = Quaternion.LookRotation (newDir);
				Destroy (bulletToSpawn, 5f);
			}
		}
	}
}
