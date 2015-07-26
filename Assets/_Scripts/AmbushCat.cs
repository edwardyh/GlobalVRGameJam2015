using UnityEngine;
using System.Collections;

public class AmbushCat : MonoBehaviour {

	public Transform player;
	public float walkSpeed = 2f;
	private NavMeshAgent ambushCat;

	// Use this for initialization
	void Start () {
		ambushCat = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
}