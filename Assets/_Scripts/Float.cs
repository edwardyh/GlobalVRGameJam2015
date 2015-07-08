using UnityEngine;
using System.Collections;

public class Float : MonoBehaviour {

	float floatHeight = 0.75f;
	float floatRange = 0.25f;
	float floatSpeed = 200f;

	private float counter = 0f;
	
	void Start() {
	}

	void FixedUpdate () {
		counter += floatSpeed * Time.deltaTime;
		if (counter > 360)
			counter -= 360;
		transform.position = new Vector3(transform.position.x, floatHeight + (floatRange * Mathf.Sin (counter * Mathf.PI / 180)), transform.position.z);
	}
}
