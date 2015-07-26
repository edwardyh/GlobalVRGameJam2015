using UnityEngine;
using System.Collections;

public class AmbushCat : MonoBehaviour {

	public Transform player;
	public float walkSpeed = 2f;
	public Transform[] checkPoints;
	public float homingAllowedTime = 10f;

	private bool arrived;
	private NavMeshAgent ambushCat;
	private bool homingOn = false;
	private HomingCat home;
	private Vector3 dest;
	private float homingTimer;

	// Use this for initialization
	void Start () {
		ambushCat = GetComponent<NavMeshAgent> ();
		home = GetComponent<HomingCat>();
		home.enabled = false;
		arrived = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!homingOn) {
			if (arrived) {
				int nextToDo = Random.Range (0, 100);
				print ("NEXT TO DO: " + nextToDo);
				if (nextToDo >= 66) {
					arrived = false;
					int index = Random.Range (0, checkPoints.Length - 1);
					print ("GOING TO: " + index);
					dest = checkPoints [index].position;
					ambushCat.SetDestination (dest);
				} else {
					print("HOMING ON");
					homingOn = true;
					home.enabled = true;
					homingTimer = 0f;
				}
			} else {
				float distance = Vector3.Distance (dest, transform.position);
				if (distance <= 3f) {
					print ("ARRIVED");
					arrived = true;
				}
			}
		} else {
			homingTimer += Time.deltaTime;

			if (homingTimer >= homingAllowedTime) {
				print ("HOMING OFF");
				homingOn = false;
				arrived = true;
				home.enabled = false;
			}
		}
	}
}