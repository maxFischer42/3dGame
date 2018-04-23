﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldHealth : MonoBehaviour {

	public GameObject part;
	public int hp;
	public GameObject[] newStuff;
	public GameObject[] destroyStuff;

	public void Update()
	{
		if (hp <= 0) {
			explosion();
		}
	}

	public void explosion()
	{
		part.SetActive (true);
		for(int i = 0; i < newStuff.Length; i++)
		{
			newStuff[i].SetActive(true);
		}
		for(int i = 0; i < destroyStuff.Length; i++)
		{
			destroyStuff[i].SetActive(false);
		}
		enabled = false;
	}


}
