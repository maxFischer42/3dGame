using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipShoot : MonoBehaviour {

	public Transform[] guns;
	public GameObject objToSpawn;
	public AudioSource audi;
	public AudioClip sound;
	public float gunSpeed;
	public GameObject target;
	public LineRenderer laserLine;
	public Camera fpsCam;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetAxisRaw ("Fire1") > 0) {
			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (.5f, .5f, 0));
			for (int i = 0; i < guns.Length; i++) {
				RaycastHit hit;
				laserLine.SetPosition (0, guns [i].position);
				if (Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit, 100)) {

					laserLine.SetPosition (1, hit.point);
					Debug.Log (hit.collider.gameObject.name);
					if (hit.collider.GetComponent<enemyHealthHandler> ()) {
						hit.collider.GetComponent<enemyHealthHandler> ().maxHP--;
					}
				} else {
					laserLine.SetPosition (1, fpsCam.transform.forward * 100);
				}
			}
		}
	}


}