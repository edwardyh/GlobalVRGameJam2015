using UnityEngine;
using System.Collections;

public class AmbushCat : MonoBehaviour {

	public Transform player;
	public Transform[] patrolRoute;
	public float walkSpeed = 2f;
	private NavMeshAgent ambushCat;
	private int patrolIndex;
	private float patrolTimer;
	private float patrolPauseTime = 3f;
	private float chaseTimer;
	private float chaseAllowedTime = 10f;
	private bool notSpotted = false;

	// Use this for initialization
	void Start () {
		ambushCat = GetComponent<NavMeshAgent> ();
		patrolIndex = 0;
		patrolTimer = 0f;
		chaseTimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (notSpotted) {
			Patrol();
		} else {
			Chase();
		}

		Scan ();
	}

	void Patrol () {
		patrolTimer += Time.deltaTime;
		ambushCat.speed = walkSpeed;
		
		if (patrolTimer >= patrolPauseTime) {
			
			if (patrolIndex == patrolRoute.Length - 1) {
				patrolIndex = 0;
			} else {
				patrolIndex++;
			}
			
			patrolTimer = 0f;
		}
		
		ambushCat.destination = patrolRoute [patrolIndex].position;
	}

	void Chase () {
		ambushCat.SetDestination (player.position);

		chaseTimer += Time.deltaTime;

		if (chaseTimer >= chaseAllowedTime) {
			notSpotted = true;
			patrolIndex = 0;
			patrolTimer = 0f;
			ambushCat.destination = patrolRoute [patrolIndex].position;
		}
	}

	void Scan () {

	}
}
