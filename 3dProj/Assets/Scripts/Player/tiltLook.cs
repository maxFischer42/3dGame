using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiltLook : MonoBehaviour {
	public float leanAngle = 35;
	public float leanSpeed = 5;
	public float leanBackSpeed = 6;
	public float sneakBoost = 10f;
	int recent = 0;
	public Behaviour[] behavioursToDisable;

//	public Behaviour movementScript;

	bool isTilting = false;
	Vector3 rotationStart;


	void Update ()
	{
		float tilt = Input.GetAxisRaw ("Tilt");





		if (tilt > 0) {
			LeanLeft ();
		} else if (tilt < 0) {
			LeanRight ();
		} else if(tilt == 0){
			LeanBack ();
		}

	}





void LeanLeft() 
 {
		scriptActivate (false);
		GetComponent<Rigidbody> ().velocity = GetComponent<Rigidbody> ().velocity / 2;
     // current Z-rotation
    float currAngle = transform.rotation.eulerAngles.z;
     
     // target Z-rotation
     float targetAngle = leanAngle;
     
     if ( currAngle > 180.0 )
     {
         currAngle = 360 - currAngle;
     }
     
     //lerp value from current to target
     float angle = Mathf.Lerp( currAngle, targetAngle, leanSpeed * Time.deltaTime );
     
     
     // rotate char
		Quaternion rotAngle = Quaternion.Euler( transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle );
     transform.rotation = rotAngle;
 }

 void LeanRight() 
 {
		scriptActivate (false);
		GetComponent<Rigidbody> ().velocity = GetComponent<Rigidbody> ().velocity / 2;
     // current Z-rotation
     float currAngle = transform.rotation.eulerAngles.z;
     
     // target Z-rotation
     float targetAngle = leanAngle - 360.0f;
     
     if ( currAngle > 180.0 )
     {
         targetAngle = 360.0f - leanAngle;
     }
     
     //lerp value from current to target
     float angle = Mathf.Lerp( currAngle, targetAngle, leanSpeed * Time.deltaTime );
     
     
     // rotate char
	Quaternion rotAngle = Quaternion.Euler( transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle );
     transform.rotation = rotAngle;
     
 }


void LeanBack() 
 {
		scriptActivate (true);
     // current Z-rotation
     float currAngle = transform.rotation.eulerAngles.z;
     
     // target Z-rotation
     float targetAngle = 0.0f;
     
     if ( currAngle > 180.0 )
     {
         targetAngle = 360.0f;
     }
     
     //lerp value from current to target
     float angle =  Mathf.Lerp( currAngle, targetAngle, leanBackSpeed * Time.deltaTime );
     
     //Debug.Log ( "Center : currAngle " + currAngle + " : targetAngle " + targetAngle + " : angle " + angle );
     
	Quaternion rotAngle = Quaternion.Euler( transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle );
     transform.rotation = rotAngle;
 }


	void scriptActivate(bool active){
		for (int i = 0; i < behavioursToDisable.Length; i++) {
			behavioursToDisable [i].enabled = active;
		}
	}






}
