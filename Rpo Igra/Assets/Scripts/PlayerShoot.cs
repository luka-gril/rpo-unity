using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	[SerializeField]
	private GameObject BulletPrefab;
	private float mTimer = 0f;
	private float mShootTime = 0.1f;

	void Update(){
		mTimer += Time.deltaTime;

		if (Input.GetMouseButtonDown (0) && mTimer >= mShootTime) {
			Shoot ();
			mTimer = 0f;
		}
	}

	private void Shoot(){
		Instantiate (BulletPrefab, gameObject.transform.position, Quaternion.identity);
	}

}
