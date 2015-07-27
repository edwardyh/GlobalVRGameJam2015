using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour
{

	ItemManager itemManager;
	ParticleSystem particleSystem;
	// Use this for initialization
	void Start ()
	{
		if (itemManager == null)
			itemManager = GameObject.Find ("ItemManager").GetComponent<ItemManager> ();
		if (particleSystem == null)
			particleSystem = GetComponent<ParticleSystem> ();
		particleSystem.startDelay = Random.Range (60, 100); // start emission after 1 min
		particleSystem.Play ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.name == ("Player")) {
			itemManager.FoodCollected ();
			gameObject.SetActive (false);
		}
	}
}
