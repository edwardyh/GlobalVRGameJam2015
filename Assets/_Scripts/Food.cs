using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.name == ("Player")) {
			ItemManager itemManager = GameObject.Find ("ItemManager").GetComponent<ItemManager> ();
			itemManager.FoodCollected ();
			DestroyObject (gameObject);
		}
	}
}
