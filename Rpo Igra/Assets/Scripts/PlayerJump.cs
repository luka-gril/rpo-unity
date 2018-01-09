using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

	/*private Rigidbody mPlayerRigidbody;
	[SerializeField]
	private float mJumpForce;
	private bool isInAir = false;

	void OnEnable(){
		mPlayerRigidbody = GetComponent<Rigidbody> ();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space) && !isInAir) {
			mPlayerRigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
			mPlayerRigidbody.AddForce (Vector3.up * mJumpForce);
		}
	}
		
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Floor")) {
			mPlayerRigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ;
			isInAir = false;
		}
	}*/

}
