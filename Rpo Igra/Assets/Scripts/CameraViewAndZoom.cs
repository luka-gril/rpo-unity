using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewAndZoom : MonoBehaviour {

	void Update () {
		DetectKeyboardPresses ();
	}


	private void DetectKeyboardPresses(){
		// POGLED
		if (Input.GetKeyDown (KeyCode.C)) {
			Vector3 trenutniPogled = gameObject.transform.localScale;
			if (trenutniPogled.x == 0.4f) {
				trenutniPogled.x = -0.4f;
			} else {
				trenutniPogled.x = 0.4f;
			}

			gameObject.transform.localScale = trenutniPogled;
		}

		// ZOOM
		if (Input.GetMouseButtonDown (1)) {
			if (gameObject.GetComponent<Camera> ().fieldOfView == 80) {
				gameObject.GetComponent<Camera> ().fieldOfView = 50;
			}
			else{
				gameObject.GetComponent<Camera> ().fieldOfView = 80;

		}

	}



}
