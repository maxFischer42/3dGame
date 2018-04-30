using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;

public class pauseMenu : MonoBehaviour {

	public bool ispaused = false;
	public GameObject pauseCanvas;


	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("pause")) {
			turnOn ();
		}
	}

	void turnOn()
	{
		ispaused = !ispaused;
		pauseCanvas.SetActive (ispaused);

		if (ispaused) {
			Time.timeScale = 0;

		}
		if (!ispaused) {
			
			Time.timeScale = 1;
		}
	}




}
