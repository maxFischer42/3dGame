using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipController : MonoBehaviour {

	public float speed;
	public Vector3 startPos;
	public float xIn;
	public float yIn;


	void Start()
	{
		startPos = transform.position;
	}


	// Update is called once per frame
	void Update ()
	{
		GetComponent<Rigidbody>().AddForce(new Vector3(0,0,speed));
		xIn = GetX();
		yIn = GetY();
		GetComponent<Rigidbody>().AddForce(new Vector3(xIn * speed,0,0));
		GetComponent<Rigidbody>().AddForce(new Vector3(0,yIn * speed,0));
	}

	float GetX()
	{
		return Input.GetAxis ("Horizontal");
	}

	float GetY()
	{
		return Input.GetAxis ("Vertical");
	}
		








}
