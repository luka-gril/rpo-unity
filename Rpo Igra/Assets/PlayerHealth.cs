using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	private int Health = 100;
	[SerializeField]
	private Text HealthText;

	public void LowerHealth(int value){
		Health -= value;
		HealthText.text = Health.ToString ();
		if (Health <= 0) {
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().PlayerKilled ();
		}
	}
}
