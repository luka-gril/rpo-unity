using System.Collections;
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
		Destroy (gameObject);
	}

	void PlayBulletSound(){
		// Ko bodo uvoženi zvoki
		// Find Audio Source
		// AudioSource.Play();
	}
		
}
