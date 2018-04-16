using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDestroyOnTime : MonoBehaviour {

	public float timeTill;
	float timer;
	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= timeTill) {
			Destroy (gameObject);
		}
	}


}
