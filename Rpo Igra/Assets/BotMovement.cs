using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BotMovement : MonoBehaviour {

	private UnityEngine.AI.NavMeshAgent mNavMeshAgent;
	private Transform mPlayer;
	private Animator mAnimator;

	void OnEnable(){
		mNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		mPlayer = GameObject.FindGameObjectWithTag ("MainCamera").transform;
		float randomSpeed = 0.5f;
		mNavMeshAgent.avoidancePriority = Random.Range (1, 99);
		mNavMeshAgent.speed = randomSpeed;
		mNavMeshAgent.stoppingDistance = 0.5f;
		mAnimator = GetComponent<Animator> ();
	}

	void Update(){
		float Distance = Vector3.Distance (mPlayer.position, transform.position);
		mNavMeshAgent.SetDestination (mPlayer.position);
	}
		

}
