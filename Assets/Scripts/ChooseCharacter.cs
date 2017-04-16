using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacter : MonoBehaviour {

	public GameObject player;

	public int id = 0;
	public string select1 = "Jump_P1";
	public string select2 = "Jump_P2";

	public bool isOnGame1 = false;
	public bool isOnGame2 = false;

	public bool isSelected1 = false;
	public bool isSelected2 = false;

	public string horizontal1 = "Horizontal_P1";
	public string horizontal2 = "Horizontal_P2";

	public Sprite sp1;
	public Sprite sp2;
	public Sprite sp3;

	public Sprite dp1;
	public Sprite dp2;
	public Sprite dp3;


	public int spritesCinza = 0;
	public int spritesColor = 0;

	public GameObject p1;
	public GameObject p2;
	public GameObject p3;
	public GameObject p4;
	public float delay = 0f;
	public int i = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		delay += Time.deltaTime;

		if (Input.GetButtonDown (select1) && isOnGame1 == false) {
			p1.GetComponent<SpriteRenderer> ().sprite = sp1;
			isOnGame1 = true;
			Debug.Log ("Cinza");
		}

		select ();
	
	}

	void select(){
		if (Input.GetButtonDown (select1) && isOnGame1 == true && delay > 2f) {
			p1.GetComponent<SpriteRenderer> ().sprite = dp1;
			Debug.Log ("Colorido");
			delay = 0;
		}
	}
}
