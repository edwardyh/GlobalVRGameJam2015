using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManagerBN : MonoBehaviour {

	public Collectable item;
	public Sprite blankSprite;

	public Sprite cheeseSprite, friesSprite, forkSprite;

	private Canvas canvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setItem(Collectable colItem){
		item = colItem;
	}

	public void useItem(){
		if (item != null) {
			Debug.Log("UseItemandSwitch");
			useItemAndSwitch();
			//GameObject.Destroy(item.gameObject);
		}
	}

	public void useItemAndSwitch(){
		Image[] images = canvas.GetComponentsInChildren<Image> ();
		Image imgToChange = images [0];
		Image imgToChange2 = images [1];
		imgToChange.sprite = blankSprite;
		imgToChange2.sprite = blankSprite;
	}
}
