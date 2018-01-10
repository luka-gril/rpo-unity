using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour {

	[SerializeField]
	private GameObject PrefabEffect;

	private float mZombieHealth = 100f;

	public void LowerHealth(float value){
		mZombieHealth -= value;
		if (mZombieHealth <= 0) {
			
			GameObject effect = (GameObject) Instantiate (PrefabEffect, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2f, gameObject.transform.position.z), Quaternion.identity);
			Destroy (effect, 0.2f);
			Destroy (gameObject);
		}
	}

}
