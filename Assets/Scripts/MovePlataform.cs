using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlataform : MonoBehaviour {

	public float platformSpeed;
	public float maximum_posY = 7f;
	private PlatformController[] controller;

	// Use this for initialization
	void Start () {
		controller = FindObjectsOfType <PlatformController> ();

	}
	
	// Update is called once per frame
	void Update () {

		platformSpeed = controller[0].plataformSpeed;

		transform.Translate(new Vector2(0, platformSpeed * Time.deltaTime));
	
		if (transform.position.y >= maximum_posY) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Death") {
			Destroy(gameObject);
		}
	}
}
