using UnityEngine;
using System.Collections;

public class AutoWalk : MonoBehaviour {
	public bool isWalking = true;
	public float speed = 1.5f;
	private CardboardHead head = null;
	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if (isWalking) {
			Vector3 direction = new Vector3 (head.transform.forward.x, 0, head.transform.forward.z).normalized * speed * Time.deltaTime;
			Quaternion rotation = Quaternion.Euler (new Vector3 (0, -transform.rotation.eulerAngles.y, 0));
			transform.Translate (rotation * direction);
		}
	}
}
