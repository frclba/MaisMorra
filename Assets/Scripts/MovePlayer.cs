using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	public Rigidbody2D rd2;
	public float maxSpeed = 5f;
	public float moveForce = 365f;
	public float jumpForce = 750f;
	public float dashForce = 1000f;
	public bool estaNoSolo;
	public bool canDoubleJump = true;
	public Transform testSolo;
	public string horizontalCtrl= "Horizontal_P1";
	public string jump = "Jump_P1";
	public bool canDash = true;
	public string dash = "Dash_P1";
	public float dashDelay = 0f;

	//Set on player in hierarchy
	public bool faceRight = true;

	// Use this for initialization
	void Start () {
		rd2 = GetComponent<Rigidbody2D> ();	
	}
	 
	// Update is called once per frame
	void FixedUpdate () {

		float moveHorizontal = Input.GetAxis (horizontalCtrl);

		if (moveHorizontal < 0 && !faceRight) {
			flip ();

		} else if (moveHorizontal > 0 && faceRight){
			flip ();
		}
			
		if (moveHorizontal * rd2.velocity.x < maxSpeed) {
			rd2.AddForce (Vector2.right * moveHorizontal * moveForce);
		}

		if(Mathf.Abs(rd2.velocity.x) > maxSpeed)
			rd2.velocity = new Vector2(Mathf.Sign(rd2.velocity.x) * maxSpeed, rd2.velocity.y);

		estaNoSolo = Physics2D.Linecast(transform.position, testSolo.position, 1 << LayerMask.NameToLayer("Water"));  

		if (Input.GetButtonDown (jump)) {
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

		if (Input.GetButtonDown (dash)) {
			if (canDash) {
				if (faceRight) {
					rd2.AddForce (new Vector2 (-dashForce, 0));
					canDash = false;
				} else {
					rd2.AddForce (new Vector2 (dashForce, 0));
					canDash = false;
				}
			}
		}

		dashDelay += Time.deltaTime;

		if (dashDelay > 2) {
			canDash = true;
			dashDelay = 0;
		}
			
	}

	void flip(){
		faceRight = !faceRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
