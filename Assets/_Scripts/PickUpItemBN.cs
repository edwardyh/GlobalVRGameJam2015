using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PickUpItemBN : MonoBehaviour {
	private GameObject gameManager;

	private GameObject canvas;
	public Image[] images;
	public Sprite sprite;
	private Collectable collectable;
	private bool hasItem = false;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindWithTag ("GameManager");
		canvas = GameObject.FindGameObjectWithTag ("Canvas");
	}
	
	// Update is called once per frame
	void Update () {
		//NEED CARDBOARDHEAD / Magnetic trigger
		if (collectable != null && !hasItem) {
			PickUpItem();
		}
	}

	void PickUpItem(){
		gameManager.GetComponent<ItemManager> ().setItem (collectable);
		hasItem = true;
		images = canvas.GetComponentsInChildren<Image> ();
		Image imageToPut = images [0];
		Image imageToPut2 = images [1];
		imageToPut.sprite = imageToPut2.sprite =  getCorrectSprite(collectable.itemType);
		//Renderer rend = collectable.GetComponent<Renderer> ();
		//Collider col = collectable.GetComponent<Collider> ();
		// rend.enabled = false;
		//col.enabled = false;
		//GameObject.DestroyObject (collectable);
		collectable = null;
	}

	void UseItem(){
		gameObject.GetComponent<ItemManager> ().useItem();
		hasItem = false;
	}

	void OnTriggerEnter(Collider other){
		var coll = other.gameObject.GetComponent<Collectable> ();
		if (coll != null) {
			collectable = coll;
		} else {
			collectable = null;
		}
	}

	void onTriggerExit(Collider other){
		var coll = other.gameObject.GetComponent<Collectable> ();
		if (coll == null) {
			collectable = null;
		} else {
			// is this okay?
			collectable = null;
		}
	}

	Sprite getCorrectSprite(string spriteType){
		Debug.Log ("SPRITE TYPE: " + spriteType);
		if (spriteType == "cheeseSprite")
			return gameManager.GetComponent<ItemManager>().cheeseSprite;
		if (spriteType == "friesSprite")
			return gameManager.GetComponent<ItemManager>().friesSprite;
		if (spriteType == "forkSprite")
			return gameManager.GetComponent<ItemManager> ().forkSprite;
		else
			return gameManager.GetComponent<ItemManager> ().blankSprite;
	}
}
