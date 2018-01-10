using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float mMovementSpeed;
	private float mRotationSpeed = 1.2f;
	private Transform mPlayerTransform;
	private Rigidbody mPlayerRigidbody;

	void OnEnable(){
		mPlayerTransform = GetComponent<Transform> ();
		mPlayerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		if (!Input.anyKey) {
			mPlayerRigidbody.velocity = Vector3.zero;
			GameObject.FindGameObjectWithTag ("Walking").GetComponent<AudioSource> ().volume = 0.0f;
		} else {
			Vector3 movementVector = Vector3.zero;
			GameObject.FindGameObjectWithTag ("Walking").GetComponent<AudioSource> ().volume = 1.0f;
			if (Input.GetKey (KeyCode.W)) {
				movementVector += (mPlayerTransform.forward);
			}
			if (Input.GetKey (KeyCode.S)) {
				movementVector += (-mPlayerTransform.forward);
			}
			if (Input.GetKey (KeyCode.D)) {
				movementVector += (mPlayerTransform.right);
			}
			if (Input.GetKey (KeyCode.A)) {
				movementVector += (-mPlayerTransform.right);
			}
			mPlayerRigidbody.MovePosition (mPlayerTransform.position + (movementVector * Time.deltaTime * mMovementSpeed));
		}
	}
		

}
