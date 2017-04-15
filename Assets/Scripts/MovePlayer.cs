using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	public Rigidbody2D rd2;
	public float maxSpeed = 5f;
	public float moveForce = 365f;
	public float jumpForce = 750f;
	public bool estaNoSolo;
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

		if(Input.GetButtonDown("Jump") && (estaNoSolo || jumps < 2)) {
			rd2.AddForce (transform.up * jumpForce);
			jumps = jumps + 1;
		}

			jumps = 0;
	}
}
