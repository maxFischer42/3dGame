using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour {
    public bool move;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody>().AddTorque(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100));
        if (move)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Random.Range(0, 40), Random.Range(0, 40), Random.Range(0, 40));
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
