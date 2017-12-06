using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewAndZoom : MonoBehaviour {

	void Update () {
		DetectKeyboardPresses ();
	}


	private void DetectKeyboardPresses(){
		if (Input.GetKeyDown (KeyCode.C)) {
			Vector3 trenutniPogled = gameObject.transform.localScale;
			trenutniPogled.x = -trenutniPogled.x;
			gameObject.transform.localScale = trenutniPogled;
		}
			
		if (Input.GetMouseButtonDown (1)) {
			if (gameObject.GetComponent<Camera> ().fieldOfView == 80) {
				gameObject.GetComponent<Camera> ().fieldOfView = 50;
			} else {
				gameObject.GetComponent<Camera> ().fieldOfView = 80;

			}

		}
	}



}
