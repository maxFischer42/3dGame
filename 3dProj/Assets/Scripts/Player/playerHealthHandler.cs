using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealthHandler : MonoBehaviour {

	public int HP;
	public Text hpText;


	void Update ()
	{
		PlayerPrefs.SetInt ("HP", HP);
		hpText.text = PlayerPrefs.GetInt ("HP").ToString();
	}


}
