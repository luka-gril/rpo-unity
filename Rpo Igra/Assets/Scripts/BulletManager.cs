﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

	[SerializeField]
	private GameObject explosionParticle;
	private float BulletForce = 220f;

	void Start(){
		InstantiateExplosion(explosionParticle);
		GameObject Camera = GameObject.FindGameObjectWithTag ("MainCamera");
		GetComponent<Rigidbody> ().AddForce (Camera.transform.forward * BulletForce);
	}

	private void InstantiateExplosion(GameObject explosion){	
		GameObject spawnedExplosion = (GameObject) Instantiate (explosion, gameObject.transform.position,  gameObject.transform.rotation);
		Destroy (spawnedExplosion, 0.1f);
	}

	void OnCollisionEnter(Collision collision){
		InstantiateExplosion (explosionParticle);
		if (collision.gameObject.tag.Equals ("Zombie")) {
			collision.gameObject.GetComponent<ZombieHealth> ().LowerHealth (15f);
		}
		if (collision.gameObject.tag.Equals ("StaticObject")) {
			Debug.Log ("");
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().playingTime -= 3f;
		}
		Destroy (gameObject);
	}

	void PlayBulletSound(){
		// Ko bodo uvoženi zvoki
		// Find Audio Source
		// AudioSource.Play();
	}
		
}
