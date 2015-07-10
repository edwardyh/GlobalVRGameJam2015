using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PickUpItemBN : MonoBehaviour {
	private GameObject gameManager;

	public Canvas canvas;
	public Image[] images;
	public Sprite sprite;
	private Collectable collectable;
	private bool hasItem = false;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindWithTag ("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
		//NEED CARDBOARDHEAD / Magnetic trigger
		if (collectable != null && !hasItem) {
			PickUpItem();
		}
	}

	void PickUpItem(){
		gameManager.GetComponent<GameManagerBN> ().setItem (collectable);
		hasItem = true;
		images = canvas.GetComponentsInChildren<Image> ();
		Image imageToPut = images [0];
		Image imageToPut2 = images [1];
		imageToPut.sprite = collectable.sprite;
		imageToPut2.sprite = collectable.sprite;
		Renderer rend = collectable.GetComponent<Renderer> ();
		Collider col = collectable.GetComponent<Collider> ();
		rend.enabled = col.enabled = false;
		collectable = null;
	}

	void UseItem(){
		gameObject.GetComponent<GameManagerBN> ().useItem();
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
}
