using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class killscript : MonoBehaviour {

	private float playerHp;
	public playerHealthHandler hpScript;
	public string sceneToLoad;


	void Update () {
		playerHp = hpScript.HP;
		if (playerHp <= 0) {
			SceneManager.LoadScene (sceneToLoad);
		}
	}


}
