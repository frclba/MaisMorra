using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayer2 : MonoBehaviour {

	public string punch = "Punch_P1";

	public GameObject player1;
	public GameObject player2;

	//Distancia para ataque
	private float distancia;
	public float distancia_attack = 0.6f;

	public float attackForce = 500f;
	public bool canAttack = true;
	private float delayAttack = 0f;


	// Use this for initialization
	void Start () {
		distancia = 0;
	}

	// Update is called once per frame
	void Update () {
		distancia = Vector3.Distance (player1.transform.position, player2.transform.position);

		if (distancia < distancia_attack && Input.GetButtonDown (punch) && canAttack) {
			//other.gameObject.GetComponent<MovePlayer> ().rd2.AddForce (new Vector2 (attackForce, 0));
		}

	}

}
