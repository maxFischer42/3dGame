using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAnimationHandler : MonoBehaviour {

	private Animator anim;
	private enemyShoot enShoot;
	private EnemyNavFollow enNav;


	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		enNav = GetComponent<EnemyNavFollow> ();
		enShoot = GetComponentInChildren<enemyShoot> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (enNav.player != null) {
			anim.SetBool ("isWalking", true);
			anim.SetBool ("firing", false);
		}
		if (enShoot.enabled == true) {
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			anim.SetBool ("isWalking", false);
			anim.SetBool ("firing", true);

		}
	}
}
