using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour {

	private float mZombieHealth = 100f;

	public void LowerHealth(float value){
		mZombieHealth -= value;
		if (mZombieHealth <= 0) {
			Destroy (gameObject);
		}
	}

}
