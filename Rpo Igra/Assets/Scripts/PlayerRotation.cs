using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

	private float mRotationSpeed = 1.2f;
	private Rigidbody mPlayerRigidbody;

	void OnEnable(){
		mPlayerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		float mouseInputX = Input.GetAxis("Mouse X") * mRotationSpeed;
		float mouseInputY = Input.GetAxis ("Mouse Y") * (-mRotationSpeed);
		Vector3 newRotation = new Vector3(mouseInputY, mouseInputX, 0);
		Quaternion currentRotation = mPlayerRigidbody.rotation;
		currentRotation.eulerAngles = new Vector3 (currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, 0f);
		mPlayerRigidbody.MoveRotation (currentRotation * Quaternion.Euler (newRotation));
	}

}
