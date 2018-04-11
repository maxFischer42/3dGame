using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundRadius : MonoBehaviour {

	public AudioSource audi;
	[Tooltip("1-3 normal walking, 4 running")]
	public AudioClip[] footSteps;
	public SphereCollider radius;
	public float walkSize = 5f;
	public float runSize = 10f;
	public bool isRunning;

	float timer;
	[Tooltip("time inbetween step sounds")]
	public float timeTillStep = 3f;
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.LeftShift)) {
			radius.radius = runSize;
			isRunning = true;
			timer += Time.deltaTime;
		} else if(GetComponent<Rigidbody>().velocity != new Vector3(0,0,0)) {
			radius.radius = walkSize;
			isRunning = false;
			timer += Time.deltaTime;
		}

		if (timer >= timeTillStep && !isRunning) {
			int selectedSound = Random.Range (0, 3);
			playSound (footSteps [selectedSound]);
			timer = 0;
		} else if (timer >= (timeTillStep / 2) && isRunning) {
			playSound (footSteps [3]);
			timer = 0;
		}
	}

	void playSound(AudioClip sound)
	{
		audi.PlayOneShot (sound);
	}
}
