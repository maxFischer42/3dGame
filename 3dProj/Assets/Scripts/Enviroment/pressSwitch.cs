using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pressSwitch : MonoBehaviour {

	public Text textObj;
	public GameObject[] objectsToDeactivate;
    public GameObject[] objectsToActivate;
    public string textToDisplay;

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.tag == "Player") {
			textObj.enabled = true;
			textObj.text = textToDisplay;
		}
	}

	void OnTriggerExit(Collider coll)
	{
		if (coll.gameObject.tag == "Player") {
			textObj.enabled = false;
			textObj.text = " ";
		}
	}


	void OnTriggerStay(Collider coll)
	{
		if (coll.gameObject.tag == "Player" && Input.GetButtonDown("Interact"))
		{

			textObj.enabled = false;
			textObj.text = " ";

			for(int i = 0;i < objectsToDeactivate.Length; i++)
			{
				objectsToDeactivate [i].SetActive (false);
			}
            for (int i = 0; i < objectsToActivate.Length; i++)
            {
                objectsToActivate[i].SetActive(true);
            }
            Destroy (transform.parent.gameObject);
		}
	}
}
