using UnityEngine;
using System.Collections;

public class ParticleBehavior : MonoBehaviour
{

	ParticleSystem ps;

	// Use this for initialization
	void Start ()
	{
		if (ps == null)
			ps = GetComponent<ParticleSystem> ();
		ps.startDelay = Random.Range (0, 10); // start emission after 10-10 sec
		ps.Play ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
