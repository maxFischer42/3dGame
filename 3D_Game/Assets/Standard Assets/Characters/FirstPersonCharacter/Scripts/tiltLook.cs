using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiltLook : MonoBehaviour {
	/*
	[Tooltip("the transform of the object for tilting left")]
	public Transform leftTilt;

	[Tooltip("the transform of the object for tilting right")]
	public Transform rightTilt;

	[Tooltip("the transform of the object for the camera's original position")]
	public Transform camPos;

	public float _cameraRotationSpeed = 0.1f;
*/
	public float leanAngle = 35;
	public float leanSpeed = 5;
	public float leanBackSpeed = 6;
	public float sneakBoost = 10f;
	int recent = 0;

	public Behaviour movementScript;

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
		//transform.parent.GetComponent<Rigidbody> ().AddForce (new Vector3 (-sneakBoost, 0, 0));
		movementScript.enabled = false;
     // current Z-rotation
    float currAngle = transform.rotation.eulerAngles.z;
     //var rot : Quaternion = transform.rotation;
     
     // target Z-rotation
     float targetAngle = leanAngle;
     
     if ( currAngle > 180.0 )
     {
         //targetAngle = 0.0 - leanAngle;
         currAngle = 360 - currAngle;
     }
     
     //lerp value from current to target
     float angle = Mathf.Lerp( currAngle, targetAngle, leanSpeed * Time.deltaTime );
     
     //Debug.Log ( "Left : currAngle " + currAngle + " : targetAngle " + targetAngle + " : angle " + angle );
     
     // rotate char
		Quaternion rotAngle = Quaternion.Euler( transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle );
     transform.rotation = rotAngle;
 }

 void LeanRight() 
 {
		//transform.parent.GetComponent<Rigidbody> ().AddForce (new Vector3 (sneakBoost, 0, 0));
		movementScript.enabled = false;
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
     
     //Debug.Log ( "Right : currAngle " + currAngle + " : targetAngle " + targetAngle + " : angle " + angle );
     
     // rotate char
	Quaternion rotAngle = Quaternion.Euler( transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle );
     transform.rotation = rotAngle;
     
 }


void LeanBack() 
 {

		/*if (recent == 1) {
			transform.SetPositionAndRotation(new Vector3 (0, 0, 0), transform.rotation);
			recent = 0;
		}
			else if(recent == 2)
			{
			transform.SetPositionAndRotation(new Vector3 (0, 0, 0), transform.rotation);
			recent = 0;
			}*/



		movementScript.enabled = true;
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







	/*void onTiltStart(float dir)
	{
		movementScript.enabled = false;
		isTilting = true;

		float angle = transform.localRotation.eulerAngles.z;

		if(dir > 0 && angle < -15f)
		{
			//angle -= _cameraRotationSpeed;
			transform.SetPositionAndRotation(new Vector3(1, 0, 0), rightTilt.rotation);
		}
		else if(dir < 0 && angle < 15f)
		{
			//angle += _cameraRotationSpeed;
			transform.SetPositionAndRotation(new Vector3(-1, 0, 0), leftTilt.rotation);
		}
		//transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, angle);





	}


	void onTiltEnd()
	{
		movementScript.enabled = true;
		isTilting = false;
		transform.SetPositionAndRotation (camPos.position, camPos.rotation);
	}*/
}
