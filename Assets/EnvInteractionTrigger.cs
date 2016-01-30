using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class EnvInteractionTrigger : MonoBehaviour {
	public UnityEvent Entrata;
	public UnityEvent Uscita;
	// Use this for initialization

	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
	
		Entrata.Invoke ();
	
	}

	void OnTriggerExit (Collider other){

		Uscita.Invoke();
	}
}
