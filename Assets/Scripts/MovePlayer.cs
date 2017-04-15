using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	public Rigidbody2D rd2;
	public float maxSpeed = 5f;
	public float moveForce = 365f;
	public float jumpForce = 750f;
	public bool estaNoSolo;
	public bool canDoubleJump = true;
	public Transform testSolo;
	public int jumps = 0;

	// Use this for initialization
	void Start () {
		rd2 = GetComponent<Rigidbody2D> ();	
		//groundCheck = transform.Find ("grounded");
	}

//	void FixedUpdate(){
		
	
//	}
	 
	// Update is called once per frame
	void Update () {

		float moveHorizontal = Input.GetAxis ("Horizontal");

		if (moveHorizontal * rd2.velocity.x < maxSpeed) {
			rd2.AddForce (Vector2.right * moveHorizontal * moveForce);
		}

		if(Mathf.Abs(rd2.velocity.x) > maxSpeed)
			rd2.velocity = new Vector2(Mathf.Sign(rd2.velocity.x) * maxSpeed, rd2.velocity.y);

		estaNoSolo = Physics2D.Linecast(transform.position, testSolo.position, 1 << LayerMask.NameToLayer("Water"));  

	//	if (Input.GetButtonDown ("Jump")) {
	//		if (estaNoSolo) {
	//			rd2.AddForce (transform.up * jumpForce);
	//			canDoubleJump = true;
	//		} else {
	//			if (canDoubleJump) {
	//				canDoubleJump = false;
	//				//rd2.velocity.y = 0;
	//				rd2.AddForce (transform.up * jumpForce);
	//			}
	//		}
	//	}

		if (Input.GetButtonDown ("Jump")) {
			if (estaNoSolo) {
				rd2.velocity = new Vector2(rd2.velocity.x, 0);
				rd2.AddForce (new Vector2(0, jumpForce));
				canDoubleJump = true;
			} else {
				if (canDoubleJump) {
					canDoubleJump = false;
					rd2.velocity = new Vector2(rd2.velocity.x, 0);
					rd2.AddForce (new Vector2(0, jumpForce));
				}
			}
		}
			
	}
}
