using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseCollider : MonoBehaviour {
	private LevelMananger mananger;

	void OnTriggerEnter2D(Collider2D collider){
		print("Perdeu");
		mananger = GameObject.FindObjectOfType<LevelMananger>();
		mananger.LoadLevel("Loose");
	}
}
