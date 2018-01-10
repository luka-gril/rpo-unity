using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	[SerializeField]
	private GameObject BulletPrefab;
	private float mTimer = 0f;
	private float mShootTime = 0.2f;

	void Update(){
		mTimer += Time.deltaTime;

		if (Input.GetMouseButton (0) && mTimer >= mShootTime) {
			Shoot ();
			mTimer = 0f;
		}
	}

	private void Shoot(){
		Instantiate (BulletPrefab, gameObject.transform.position, Quaternion.identity);
		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioSource> ().Play ();
	}

}
