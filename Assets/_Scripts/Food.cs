using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour
{

	ItemManager itemManager;
	// Use this for initialization
	void Start ()
	{
		if (itemManager == null)
			itemManager = GameObject.Find ("ItemManager").GetComponent<ItemManager> ();
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
