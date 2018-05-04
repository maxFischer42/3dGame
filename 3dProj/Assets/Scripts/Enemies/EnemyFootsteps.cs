using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFootsteps : MonoBehaviour {
	
	public AudioSource audi;
	public AudioClip[] footSteps;
	public float timeBetweenSteps;
	float timer;

	void Start()
	{
		audi = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (GetComponent<Rigidbody> ().velocity.x != 0 || GetComponent<Rigidbody> ().velocity.z != 0) {
			timer += Time.deltaTime;
			if (timer >= timeBetweenSteps) {
				int soundToPlay = Random.Range (0, footSteps.Length);
				audi.PlayOneShot (footSteps [soundToPlay]);
				timer = 0;
			}
		}
	}
}
