using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public float howLongToLook;
	
	private CardboardHead head;
	
	private float delay = 0.0f; 	
	public GameObject startButton;
	
	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		
		startButton = GameObject.FindGameObjectWithTag("Start");
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		GetComponent<Renderer>().material.color = isLookedAt ? Color.grey : Color.clear;
		
		if (!isLookedAt) {
			delay = Time.time + howLongToLook;
		}
		
		if ((Cardboard.SDK.Triggered && isLookedAt) || (Time.time>delay && isLookedAt) ) {
			// Do Stuff black if looked at for now
			GetComponent<Renderer>().material.color = isLookedAt ? Color.black : Color.red;
			//startButton = GameObject.FindGameObjectWithTag("Start");
			if (Cardboard.SDK.CardboardTriggered && isLookedAt || Time.time > delay && isLookedAt){
				//Debug.Log("Load level Demo");
				Application.LoadLevel("MainScene");
			}
		}
	}
}
