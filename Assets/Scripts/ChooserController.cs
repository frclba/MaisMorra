using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooserController : MonoBehaviour {

	public GameObject p1;
	public GameObject p2;

	public string start;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (p1);
		DontDestroyOnLoad (p2);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown (start)) {
			SceneManager.LoadScene ("Game");
			p1.GetComponent<SpriteRenderer> ().enabled = false;
			p2.GetComponent<SpriteRenderer> ().enabled = false;
		}

		//else {
		//	p1.GetComponent<SpriteRenderer> ().enabled = true;
		//	p2.GetComponent<SpriteRenderer> ().enabled = true;
		//}
	}
}
