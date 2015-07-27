using UnityEngine;
using System.Collections;

public class Item
{

	private string itemName;
	private Color itemColor;
	private int itemNumber;

	public Item (string name, Color color, int num)
	{
		itemName = name;
		itemColor = color;
		itemNumber = num;
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public string GetName ()
	{
		return itemName;
	}

	public Color GetColor ()
	{
		return itemColor;
	}

	public int GetNumber ()
	{
		return itemNumber;
	}
}
