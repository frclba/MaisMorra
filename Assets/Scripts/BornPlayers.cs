using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornPlayers : MonoBehaviour {

//	public GameObject p1v;
//	public GameObject p2v;

	ChoosedPlayer[] players;


	public GameObject prefab1;
	public GameObject prefab2;

	// Use this for initialization
	void Start () {

		players = FindObjectsOfType<ChoosedPlayer> ();

		if (players[0].isOnGame == true) {
		//	switch (players[0].id) {
		//	case 1:
				Instantiate (prefab1, new Vector2 (0, 0), Quaternion.identity);
				//Azul
		//		break;

		//	case 2:
		//		Instantiate (prefab2, new Vector2 (0 5), Quaternion.identity);
				//Laranja
		//		break;
		//	}
		}

		if (players[1].isOnGame == true) {
		//	switch (players[1].id) {
		//	case 1:
		//		Instantiate (prefab1, new Vector2 (0, 0), Quaternion.identity);
				//Azul
		//		break;

		//	case 2:
				Instantiate (prefab2, new Vector2 (0, 5), Quaternion.identity);
				//Laranja
		//		break;
		//	}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
