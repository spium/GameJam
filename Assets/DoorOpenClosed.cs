using UnityEngine;
using System.Collections;

public class DoorOpenClosed : MonoBehaviour {


	private Collider colliderDoor;

	// Use this for initialization
	void Start () {
	
		colliderDoor = GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OpenDoor(){
	
		colliderDoor.enabled = false;
	//TODO animazione
	
	}

	void CloseDoor(){
	
		colliderDoor.enabled = true;
	//TODO animazione
	
	}
}
