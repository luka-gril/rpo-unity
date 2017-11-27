using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocksAtStart : MonoBehaviour {

	[SerializeField]
	private GameObject mRockPrefab;

	void Start () {
		for (int i = 0; i < 2000; i++) {
			Instantiate (mRockPrefab, new Vector3 (Random.Range (1f, 9f), 0.3f, Random.Range (1f, 9f)), Quaternion.identity);
		}

	}

}
