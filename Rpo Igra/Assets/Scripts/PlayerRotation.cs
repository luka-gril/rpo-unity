using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

	private float mRotationSpeed = 1.2f;

	void Update () {
		float mouseInputX = Input.GetAxis("Mouse X") * mRotationSpeed;
		float mouseInputY = Input.GetAxis ("Mouse Y") * (-mRotationSpeed);
		Vector3 newRotation = new Vector3(mouseInputY, mouseInputX, 0);
		transform.Rotate(newRotation);
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 0f);
	}
}
