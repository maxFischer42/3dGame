using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouch : MonoBehaviour {
    public bool debug;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (debug)
        {
            Debug.Log(gameObject.transform.GetComponent<Rigidbody>().velocity.y + " down");
            Debug.Log(gameObject.transform.GetComponent<Rigidbody>().velocity.magnitude + " mph");
        }
        if (Input.GetKey(KeyCode.C))
        {
            if (gameObject.transform.lossyScale.y > 0.5f)
                gameObject.transform.lossyScale.Set(gameObject.transform.lossyScale.x, gameObject.transform.lossyScale.y - 0.03f, gameObject.transform.lossyScale.z);
        }
        }
}
