using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavyGun : MonoBehaviour {


	Animator anim;
	bool loaded;
	bool isFiring;
	bool isReloading;
	float timer;
	public ParticleSystem part;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!isFiring || !isReloading) {
			if (loaded != true && Input.GetButtonDown ("Fire1")) {
				Reload ();
			}

			if (loaded && Input.GetButtonDown ("Fire1")) {
				anim.SetBool ("m1", true);
				Fire ();

			}


		}
		if (isFiring) {
			timer += Time.deltaTime;
			part.transform.gameObject.SetActive (true);
			if (timer > 2) {
				isFiring = false;
				timer = 0;
				part.transform.gameObject.SetActive (false);
				loaded = false;
				anim.SetBool ("isCharged", false);
				anim.SetBool ("loaded", false);
				anim.SetBool ("m1", false);
			}
		}
		if (isReloading) {
			timer += Time.deltaTime;
			if (timer > 3) {
				isReloading = true;
				timer = 0;
				loaded = true;
				anim.SetBool ("reload", false);
				anim.SetBool ("loaded", true);
			}
		}

	}


	void Reload()
	{
		timer = 0;
		anim.SetBool ("reload", true);
		isReloading = true;
	}

	void Fire()
	{
		timer = 0;
		anim.SetBool ("isCharged", true);
		isFiring = true;
	}








}
