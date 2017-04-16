using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
	Linear Path
		* Isolate player input to player select panel
		* Join Game by pressing A
		* Select player style
*/

public class PlayerSelectionController : MonoBehaviour {
	public int playerId = 0;
	public int characterChoosed;
	private string select;
	private string horizontal;

	int[] characters = {1,2,3,4};

	void start(){
		//player = GetComponent<Animator> ();
	}

	void update(){
		// Join game by pressing A
		if(Input.GetButtonDown(select) && !isOnGame){
			isOnGame = true;
			playerId++;
			Debug.Log("O player" + playerId + "entrou no jogo");
		}

	}

	void choosePlayer(){
		int i = 0;

		player = characters[0];

		if(Input.GetKeyDown("select") && isOnGame){
			characterChoosed = player;
		}

		if(Input.GetKeyDown("horizontal") && isOnGame){
			if(i==3){
				i = 0;
			}else{
				i++;
			}

			player = characters[i];
		}
	}

	void handleCurrentStates(){
		
	}
}
