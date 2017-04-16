using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlataform : MonoBehaviour {

	public float platformSpeed = 0f;
	public float maximum_posY = 7f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector2(0, platformSpeed * Time.deltaTime));
	
		if (transform.position.y >= maximum_posY) {
			Destroy (gameObject);
		}
	}
}
