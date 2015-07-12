using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	SpawnSpot[] spawnSpots;
	// Use this for initialization
	public GameObject standByCamera;


	void Start () {
		spawnSpots = GameObject.FindObjectsOfType<SpawnSpot> ();
		//standByCamera = GameObject.FindObjectOfType<Camera>();
		Connect ();
	}
	
	void Connect(){

		PhotonNetwork.ConnectUsingSettings ("1.0.0");
	}
	

	void OnJoinedLobby(){
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed() {
		Debug.Log ("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedRoom() {
		Debug.Log ("OnJoinedRoom");
		SpawnMyPlayer ();
	}

	void SpawnMyPlayer() {
		standByCamera.SetActive(false);
		SpawnSpot mySpawnSpot = spawnSpots [0];
		if (spawnSpots.Length == 0) {
			Debug.Log("No SpawnSpots");
		}
		if (Random.value > 0.70f) {
			GameObject myPlayerGo = (GameObject)PhotonNetwork.Instantiate ("CatPlayer", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
			myPlayerGo.GetComponent<AutoWalk> ().enabled = true;
			//myPlayerGo.GetComponent<PickUpItemBN> ().enabled = true;
			myPlayerGo.transform.FindChild ("CardboardMain").gameObject.SetActive (true);

		} else {
			GameObject myPlayerGo = (GameObject)PhotonNetwork.Instantiate ("Player", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
			myPlayerGo.GetComponent<AutoWalk> ().enabled = true;
			myPlayerGo.GetComponent<PickUpItemBN> ().enabled = true;
			myPlayerGo.transform.FindChild ("CardboardMain").gameObject.SetActive (true);
		}
	}

}
