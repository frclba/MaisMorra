using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosedPlayer : MonoBehaviour {

	public int id = 0;
	public string select = "Jump_P1";
	public string horizontal = "Horizontal_P1";
	public int[] characters = { 1, 2, 3, 4 };
	public int choosed = 0;
	public int i = 0;

	// Use this for initialization
	void Start () {
		id = GameObject.FindGameObjectWithTag ("Manager").GetComponent<ChooseCharacter> ().id;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown (select)) {
			choosed = characters [i];
			Debug.Log ("Character choose :" + choosed);
		}

		if (Mathf.Abs(Input.GetAxis (horizontal)) > 0) {
			Debug.Log ("Character choose :" + choosed);
			i++;
		}
	}
}
