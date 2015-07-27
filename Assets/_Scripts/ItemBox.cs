using UnityEngine;
using System.Collections;

public class ItemBox : MonoBehaviour
{

	private ItemManager itemManager;
	private int randomNum;
	private Item boxItem;
	private Item inventory;
	public GameObject[] itemType;
	private Renderer rend;
	private Collider colli;

	// Use this for initialization
	void Start ()
	{
		itemManager = GameObject.Find ("ItemManager").GetComponent<ItemManager> ();
		if (gameObject.transform.childCount > 0)
			Destroy (gameObject.transform.GetChild (0).gameObject);
		GenerateItem ();
	}
	void GenerateItem ()
	{
		boxItem = itemManager.GenerateItem ();
		GameObject newObject;
		newObject = Instantiate (itemType [boxItem.GetNumber ()]) as GameObject;
		newObject.transform.SetParent (gameObject.transform, false);
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.name == "Player") {
			//Destroy (gameObject);
			itemManager.SwitchItem (boxItem);
			Debug.Log ("Inventory now has " + itemManager.GetInventoryName ());
			StartCoroutine (HideUnhide ());
		}
	}

	IEnumerator HideUnhide ()
	{
		colli = GetComponent<Collider> ();
		colli.enabled = false;
		if (gameObject.transform.GetChild (0).gameObject != null)
			Destroy (gameObject.transform.GetChild (0).gameObject);
		yield return new WaitForSeconds (5.0f);
		colli.enabled = true;
		GenerateItem ();
	}
}
