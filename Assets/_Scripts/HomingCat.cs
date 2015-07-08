using UnityEngine;
using System.Collections;

public class HomingCat : MonoBehaviour {

	public Transform player;
	NavMeshAgent navAgent;

	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		navAgent.SetDestination (player.position);
	}
}
