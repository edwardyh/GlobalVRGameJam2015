using UnityEngine;
using System.Collections;

public class RandomWalk : MonoBehaviour {
	public float speed = 0.9f;
	private int count = 0;

	// Use this for initialization
	void Start () {
		var rand = Random.value;
		if (rand > 0.5f) {
			count = 51;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

		var xRand = Random.value;
		var zRand = Random.value;
		if (xRand >= 0.5f) {
			count++;
		}
		if (count < 50 && zRand >= 0.5f && xRand >= 0.5f) {
			Vector3 direction = new Vector3 (transform.position.x - 0.2f, 0, transform.position.z - 0.2f).normalized * speed * Time.deltaTime;
			Quaternion rotation = Quaternion.Euler (new Vector3 (0, -transform.rotation.eulerAngles.y, 0));
			transform.Translate (rotation * direction);
		} else if (count < 50 && zRand <= 0.5f && xRand >= 0.5f) {
			Vector3 direction = new Vector3 (transform.position.x + 0.2f, 0, transform.position.z - 0.2f).normalized * speed * Time.deltaTime;
			Quaternion rotation = Quaternion.Euler (new Vector3 (0, -transform.rotation.eulerAngles.y, 0));
			transform.Translate (rotation * direction);

		} else if (count < 50 && zRand >= 0.5f && xRand <= 0.5f) {
			Vector3 direction = new Vector3 (transform.position.x - 0.2f, 0, transform.position.z + 0.2f).normalized * speed * Time.deltaTime;
			Quaternion rotation = Quaternion.Euler (new Vector3 (0, -transform.rotation.eulerAngles.y, 0));
			transform.Translate (rotation * direction);
			
		} else if (count < 50 && zRand <= 0.5f && xRand <= 0.5f) {
			Vector3 direction = new Vector3 (transform.position.x + 0.2f, 0, transform.position.z + 0.2f).normalized * speed * Time.deltaTime;
			Quaternion rotation = Quaternion.Euler (new Vector3 (0, -transform.rotation.eulerAngles.y, 0));
			transform.Translate (rotation * direction);
			
		}

		if (count > 100) {
			count = 0;

		}
	}
}
