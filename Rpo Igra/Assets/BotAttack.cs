using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotAttack : MonoBehaviour {

	private int Power;
	private float AttackTime;
	private GameObject Player;
	private PlayerHealth PlayerHealthComponent;
	private float Timer = 0f;

	void OnEnable(){
		Power = Random.Range (5, 10);
		AttackTime = 3f;
		Player = GameObject.FindGameObjectWithTag ("MainCamera");
		PlayerHealthComponent = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<PlayerHealth> ();
	}

	void Update(){
		float Distance = Vector3.Distance (Player.transform.position, transform.position);
		Timer += Time.deltaTime;
		if (Timer >= AttackTime && Distance <= 0.6f) {
			Debug.Log (Distance);
			PlayerHealthComponent.LowerHealth (Power);
			Timer = 0f;
		}
	}

}
