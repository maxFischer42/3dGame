using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour {

	public bool isColl;
	public Animator anim;
	// Update is called once per frame

	void Update()
	{
//		Debug.Log(Input.GetButtonDown("Interact"));
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Player" && Input.GetButtonDown ("Interact")) {
			
			if (isColl) {
				anim.SetBool ("character_nearby", false);
				isColl = !isColl;
			} else {
				anim.SetBool ("character_nearby", true);
				isColl = !isColl;
			}

		}
	}

	void OnTriggerStay(Collider coll){
		
		if (coll.gameObject.tag == "Player" && Input.GetButtonDown ("Interact")) {

			if (isColl) {
				anim.SetBool ("character_nearby", false);
				isColl = !isColl;
			} else {
				anim.SetBool ("character_nearby", true);
				isColl = !isColl;
			}
		}
		
	}


}
