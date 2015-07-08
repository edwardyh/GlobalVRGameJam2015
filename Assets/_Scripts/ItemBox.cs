using UnityEngine;
using System.Collections;

public class ItemBox : MonoBehaviour {

	private ItemManager itemManager;
	private int randomNum;
	private Item boxItem;
	private Item inventory;
	private Renderer rend;
	private Collider colli;

	// Use this for initialization
	void Start () {
		itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
		GenerateItem ();
	}
	void GenerateItem () {
		boxItem = itemManager.GenerateItem ();
		RenderBox ();
	}

	void RenderBox (){
		rend = GetComponent<Renderer> ();
		rend.material.SetColor("_Color", boxItem.GetColor());
	}
	
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.name == "Player") {
			//Destroy (gameObject);
			itemManager.SwitchItem(boxItem);
			Debug.Log ("Inventory now has " + itemManager.GetInventoryName());
			GenerateItem();
			StartCoroutine(HideUnhide(2f));
		}
	}

	IEnumerator HideUnhide(float waitTime) {
		while (true) {
			colli = GetComponent<Collider>();
			colli.enabled = false;
			rend.enabled = false;
			yield return new WaitForSeconds(2);
			colli.enabled = true;
			rend.enabled = true;
			break;
		}
	}
}
