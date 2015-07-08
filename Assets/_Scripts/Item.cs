using UnityEngine;
using System.Collections;

public class Item {

	private string itemName;
	private Color itemColor;

	public Item(string name, Color color) {
		itemName = name;
		itemColor = color;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string GetName() {
		return itemName;
	}

	public Color GetColor() {
		return itemColor;
	}
}
