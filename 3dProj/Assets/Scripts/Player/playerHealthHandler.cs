using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealthHandler : MonoBehaviour {

	public int HP;
	public Text hpText;
	public Image HPobj;


	void Update ()
	{
		PlayerPrefs.SetInt ("HP", HP);
		HPobj.gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (HP * 10f, HPobj.gameObject.GetComponent<RectTransform> ().sizeDelta.y);
	}


}
