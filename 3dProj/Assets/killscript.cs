using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class killscript : MonoBehaviour {

	private float playerHp;
	public playerHealthHandler hpScript;


	void Update () {
		playerHp = hpScript.HP;
		if (playerHp <= 0 && PlayerPrefs.GetString ("save") != "") {
			SceneManager.LoadScene (PlayerPrefs.GetString ("save"));
		} else if (playerHp <= 0) {
			SceneManager.LoadScene ("MainMenu");
		}
	}


}
