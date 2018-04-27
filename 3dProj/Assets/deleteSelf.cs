using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteSelf : MonoBehaviour {

	void Awake()
	{
		Destroy (gameObject.transform.parent.gameObject);
	}
}
