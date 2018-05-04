using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

	void Update()
	{
		if(Input.GetButtonDown("Submit"))
			{
			New ();
			}
	}



	public void New()
	{
		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene ("Area1");
	}

	public void Load()
	{
		string level = PlayerPrefs.GetString ("save");
		SceneManager.LoadScene (level);
	}

	public void exit()
	{
		Application.Quit ();
	}



}
