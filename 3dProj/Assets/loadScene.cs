using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {

	public string scene;
	public bool end;
	public bool gameOver;

	void Awake()
	{
		if (end) {
			PlayerPrefs.DeleteAll ();
		}
		SceneManager.LoadScene (scene);
	}
}
