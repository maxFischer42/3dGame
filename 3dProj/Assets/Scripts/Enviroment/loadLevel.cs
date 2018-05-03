using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour {

	public string level;
	public string GO;
	public string good;

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == good) {
			SceneManager.LoadScene (level);	
		} else {
			SceneManager.LoadScene (GO);	
		}
	}

}
