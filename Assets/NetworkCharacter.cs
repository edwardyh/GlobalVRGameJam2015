﻿using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {

	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (photonView.isMine) {
			// Do nothing, character input is moving us
		} else {
			transform.position = Vector3.Lerp(transform.position, realPosition, 0.1f);
			transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 0.1f);
		}
	}

	public void OnPhotonSerializedView(PhotonStream stream, PhotonMessageInfo info){
		if (stream.isWriting) {
			// our player, send actual position to network
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		} else {
			// different player, we need to receive position as of a few milliseconds ago, 
			//and update our version of that player
			transform.position = (Vector3) stream.ReceiveNext();
			transform.rotation = (UnityEngine.Quaternion) stream.ReceiveNext();
			
		}
	}
}