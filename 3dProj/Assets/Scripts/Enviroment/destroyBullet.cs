using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBullet : MonoBehaviour {


	
	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.isStatic)
		{
			Destroy(gameObject);
		}
	}
}
