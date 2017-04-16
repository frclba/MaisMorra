using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	public Rigidbody2D rd2;
	public float maxSpeed = 5f;
	public float moveForce = 365f;
	public float jumpForce = 1000f;
	public float dashForce = 1000f;
	public bool estaNoSolo;
	public bool canDoubleJump = true;
	public Transform testSolo;
	public string horizontalCtrl= "Horizontal_P1";
	public string jump = "Jump_P1";
	public bool canDash = true;
	public string dash = "Dash_P1";
	public float dashDelay = 0f;
	public Animator anim;

	//Set on player in hierarchy
	public bool faceRight = true;

	// Use this for initialization
	void Start () {
		rd2 = GetComponent<Rigidbody2D> ();	
		anim = GetComponent<Animator> ();
	}
	 
	// Update is called once per frame
	void FixedUpdate () {

		float moveHorizontal = Input.GetAxis (horizontalCtrl);

		anim.SetFloat("move", Mathf.Abs(moveHorizontal));

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
					anim.Play ("dash");
					rd2.AddForce (new Vector2 (-dashForce, 0));
					canDash = false;
				} else {
					anim.Play ("dash");
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

	public void flip(){
		faceRight = !faceRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	/*void OnTriggerStay2D(Collider2D other){

		Debug.Log ("Está no chão");

		if (other.gameObject.tag == "Solo") {
			estaNoSolo = true;
			canDoubleJump = true;
		}

		if (Input.GetButtonDown (jump)) {
			if (estaNoSolo) {
				rd2.velocity = new Vector2(rd2.velocity.x, 0);
				rd2.AddForce (new Vector2(0, jumpForce));
				canDoubleJump = true;
				estaNoSolo = false;
			} else {
				if (canDoubleJump) {
					canDoubleJump = false;
					rd2.velocity = new Vector2(rd2.velocity.x, 0);
					rd2.AddForce (new Vector2(0, jumpForce));
				}
			}
		}


	}*/
}
