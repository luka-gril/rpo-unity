using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour {

	private Vector3 Offset = new Vector3(0f,0f,0.05f);
	private GameObject MainCamera;

	void OnEnable () {
		MainCamera = Camera.main.gameObject;
	}

	void LateUpdate () {
		Vector3 newPostition = new Vector3 (MainCamera.transform.position.x + Offset.x, transform.position.y, MainCamera.transform.position.z + Offset.z);
		transform.position = newPostition;
		transform.rotation = MainCamera.transform.rotation;
	}

}
