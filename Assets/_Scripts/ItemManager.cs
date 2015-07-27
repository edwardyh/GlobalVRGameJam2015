using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
	private GameObject[] allFood;
	private AutoWalk playerAutoWalk;
	private List<NavMeshAgent> catMeshAgents;
	private List<Item> itemDataBase;
	private Item newItem;
	private Item inventory = null;
	private int r;
	private int foodRemaining;
	private	bool trigger = false;

	// Use this for initialization
	void Awake ()
	{
		itemDataBase = new List<Item> ();
		itemDataBase.Add (new Item ("Haste", Color.red, 0));
		itemDataBase.Add (new Item ("Slow", Color.green, 1));
		itemDataBase.Add (new Item ("Stun", Color.black, 2));
	}

	void Start ()
	{
		GameObject[] allFood = GameObject.FindGameObjectsWithTag ("Food");
		foodRemaining = allFood.Length;
		Debug.Log ("There are " + foodRemaining + " food in this game.");
		if (playerAutoWalk == null)
			playerAutoWalk = GameObject.Find ("Player").GetComponent<AutoWalk> ();
		if (catMeshAgents == null) {
			catMeshAgents = new List<NavMeshAgent> ();
			GameObject[] cats = GameObject.FindGameObjectsWithTag ("Cat");
			foreach (GameObject cat in cats) {
				catMeshAgents.Add (cat.GetComponent<NavMeshAgent> ());
			}
		}
	}

	void Update ()
	{
		if (Cardboard.SDK.Triggered && inventory != null) {
			UseItem (inventory.GetName ());
			Debug.Log ("Use " + inventory.GetName () + "!");
			SwitchItem (null);
			Debug.Log ("Inventory now has " + GetInventoryName ());
		}
	}

	private void UseItem (string itemName)
	{
		switch (itemName) {
		case "Haste":
			StartCoroutine ("UseHaste");
			break;
		case "Slow":
			StartCoroutine ("UseSlow");
			break;
		case "Stun":
			StartCoroutine ("UseStun");
			break;
		default:
			Debug.Log ("Error! Item  is used");
			break;
		}
	}

	private IEnumerator UseHaste ()
	{
		Debug.Log ("using haste");
		float defaultSpeed = playerAutoWalk.speed;
		playerAutoWalk.speed = defaultSpeed * 2;
		yield return new WaitForSeconds (5f);
		playerAutoWalk.speed = defaultSpeed;
		Debug.Log ("haste effect ends");
	}

	private IEnumerator UseSlow ()
	{
		Debug.Log ("using slow");
		foreach (NavMeshAgent catMeshAgent in catMeshAgents) {
			catMeshAgent.speed = 0.5f;
		}
		yield return new WaitForSeconds (10f);
		foreach (NavMeshAgent catMeshAgent in catMeshAgents) {
			catMeshAgent.speed = 3.5f;
		}
		Debug.Log ("slow effect ends");
	}

	private IEnumerator UseStun ()
	{
		Debug.Log ("using stun");
		foreach (NavMeshAgent catMeshAgent in catMeshAgents) {
			catMeshAgent.speed = 0;
		}
		yield return new WaitForSeconds (5f);
		foreach (NavMeshAgent catMeshAgent in catMeshAgents) {
			catMeshAgent.speed = 3.5f;
		}
		Debug.Log ("stun effect ends");
	}

	public Item GenerateItem ()
	{
		r = Random.Range (0, itemDataBase.Count);
		return itemDataBase [r];
	}

	public void SwitchItem (Item item)
	{
		inventory = item;
	}

	public string GetInventoryName ()
	{
		if (inventory != null) 
			return inventory.GetName ();
		return "Empty";
	}

	public void FoodCollected ()
	{

		if (foodRemaining > 1) {
			GameObject[] allFood = GameObject.FindGameObjectsWithTag ("Food");
			if (foodRemaining < 15 && trigger == false) {
				foreach (GameObject food in allFood) {
					if (food)
						food.transform.GetChild (5).gameObject.SetActive (true);
				}
				trigger = true;
			}
			foodRemaining -= 1;
			Debug.Log ("A food is eaten, there are " + foodRemaining + " food in this game now.");
		} else
			Application.LoadLevel ("Win");
	}
}