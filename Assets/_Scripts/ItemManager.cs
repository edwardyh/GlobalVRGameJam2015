using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour {

	private List<Item> itemDataBase = new List<Item> ();
	private Item newItem;
	private Item inventory = null;
	private int r;

	// Use this for initialization
	void Awake () {
		itemDataBase.Add (new Item ("Haste", Color.red));
		itemDataBase.Add (new Item ("Slow", Color.green));
		itemDataBase.Add (new Item ("Stun", Color.black));
	}
	
	// Update is called once per frame
	void Update () {
		if (Cardboard.SDK.Triggered && inventory != null) {
			Debug.Log ("Use " + inventory.GetName() + "!");
			SwitchItem(null);
			Debug.Log ("Inventory now has " + GetInventoryName());
		}
	}

	public Item GenerateItem(){
		r = Random.Range (0, itemDataBase.Count);
		return itemDataBase[r];
	}

	public void SwitchItem(Item item) {
		inventory = item;
	}

	public string GetInventoryName () {
		if (inventory != null) 
			return inventory.GetName();
		return "Empty";
	}
}
