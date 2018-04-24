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
        Debug.Log(gameObject.transform.GetComponent<Rigidbody>().velocity.y);
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (gameObject.transform.localScale.z > 0.5f)
                gameObject.transform.localScale.Set(gameObject.transform.localScale.x, gameObject.transform.localScale.y - 0.03f, gameObject.transform.localScale.z);
        }
        }
}
