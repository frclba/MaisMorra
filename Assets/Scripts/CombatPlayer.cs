using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayer : MonoBehaviour {

	public string punch = "Punch_P1";
	public bool contact = false;
	public GameObject testContact;
	public float attackForce = 2000f;
	public bool canAttack = true;
	private float delayAttack = 0f;
	public float maxSpeed = 5f;
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();	
	}
	
	// Update is called once per frame
	void Update () {
		//contact = Physics2D.Linecast(transform.position, testContact.position, 1 << LayerMask.NameToLayer("Player")); 

		delayAttack += Time.deltaTime;

		if (delayAttack > 1) {
			canAttack = true;
		}

		if (Input.GetButtonDown (punch) && canAttack) {
			anim.Play ("punch");
			canAttack = false;
			delayAttack = 0;
		}
	
	}

	void OnTriggerStay2D(Collider2D other){

		if (Input.GetButtonDown (punch) && contact && other.gameObject.tag == "Player" && canAttack) {
			anim.Play ("punch");
			//anim.SetBool("punch", true);
			if(GetComponent<MovePlayer>().faceRight == other.gameObject.GetComponent<MovePlayer>().faceRight){
				other.gameObject.GetComponent<MovePlayer> ().flip ();
			}

			other.gameObject.GetComponent<Animator> ().Play ("caindo");

			if (GetComponent<MovePlayer>().faceRight) {
				other.gameObject.GetComponent<MovePlayer> ().rd2.AddForce (new Vector2 (-attackForce, 0));
				//other.gameObject.GetComponent<MovePlayer>().rd2.velocity = new Vector2 (-attackForce, 0);
			} else {
				other.gameObject.GetComponent<MovePlayer> ().rd2.AddForce (new Vector2 (attackForce, 0));
				//other.gameObject.GetComponent<MovePlayer>().rd2.velocity = new Vector2 (attackForce, 0);
			}

			//other.gameObject.GetComponent<MovePlayer> ().rd2.AddForce (new Vector2(attackForce,0));

			//Setando velocidade máxima do empurrão
			if(Mathf.Abs(other.gameObject.GetComponent<MovePlayer>().rd2.velocity.x) > maxSpeed)
				other.gameObject.GetComponent<MovePlayer>().rd2.velocity = new Vector2(Mathf.Sign(other.gameObject.GetComponent<MovePlayer>().rd2.velocity.x) * maxSpeed, other.gameObject.GetComponent<MovePlayer>().rd2.velocity.y);

			canAttack = false;
			delayAttack = 0;
			//anim.SetBool("punch", false);
		}
	}
		
}
