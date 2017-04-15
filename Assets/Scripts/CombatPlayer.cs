using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayer : MonoBehaviour {

	public string punch = "Punch_P1";
	public bool contact = false;
	public Transform testContact;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		contact = Physics2D.Linecast(transform.position, testContact.position, 1 << LayerMask.NameToLayer("Player")); 

		if (Input.GetButtonDown (punch) && contact) {
			Debug.Log ("socou");
		}
	}

	//estaNoSolo = Physics2D.Linecast(transform.position, testSolo.position, 1 << LayerMask.NameToLayer("Player")); 
}
