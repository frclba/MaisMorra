using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlador : MonoBehaviour {

	private MovePlayer[] players;

	// Use this for initialization
	void Start () {
		players = FindObjectsOfType<MovePlayer> ();
	}
	
	// Update is called once per frame
	void Update () {
		int count = 0;
		int i = 0;
		foreach (MovePlayer player in players) {
			if (player.isAlive == true) {
				i++;
			}
		}

		if (i == 1) {
			foreach (MovePlayer player in players) {

				if (player.isAlive == true) {
					count++;
				}

				Debug.Log ("Win :" + player);
				count++;
			
				SceneManager.LoadScene ("Win");
			}
		}

		i = 0;

	}
}
