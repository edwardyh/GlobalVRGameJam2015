using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDownTimerBN : MonoBehaviour {

	public int currentTime = 180;
	public Text text0;
	public Text text1;
	

	// Use this for initialization
	void Start () {
		StartCoroutine (TimerTick ());
	}
	
	// Update is called once per frame
	void Update () {
		text0.text = ""+currentTime.ToString();
		text1.text = ""+currentTime.ToString();
	}



	IEnumerator TimerTick(){
		while (currentTime > 0) {
			currentTime--;
			yield return new WaitForSeconds(1);
		}
	}
}
