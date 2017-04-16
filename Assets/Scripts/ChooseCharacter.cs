using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacter : MonoBehaviour {

	public GameObject player;
	public GameObject instanciado;

	public int id = 0;
	public string select = "jump";

	// Use this for initialization
	void Start () {
		Debug.Log("Rodou");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown(select)){
			instanciado = Instantiate(player, new Vector2(0,0), Quaternion.identity) as GameObject;
			player.GetComponent<ChooserController>().id = id;
			id++;
		}
	}
}
