using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

	public GameObject platformPrefab_2;
	public GameObject platformPrefab_6;
	public GameObject platformPrefab_8;
	public GameObject platformPrefab_10;

	public float delay = 0f;
	public float delay_Instant = 0.05f;

	public float minimium_posX = -9.5f;
	public float maximum_posX = 9.5f;
	private float y = -7f;


	void Start(){
	}

	//do the movimentation
	void Update () {

		delay += Time.deltaTime;

		if (delay > delay_Instant) {
			int value = Random.Range (1, 4);
			float x = Random.Range (-9.5f, 9.5F);

			switch (value) {
			case 1:
				Instantiate (platformPrefab_2, new Vector2(x,y), Quaternion.identity);
				break;
			case 2:
				Instantiate (platformPrefab_6, new Vector2(x,y), Quaternion.identity);
				break;
			case 3:
				Instantiate (platformPrefab_8, new Vector2(x,y), Quaternion.identity);
				break;
			case 4:
				Instantiate (platformPrefab_10, new Vector2(x,y), Quaternion.identity);
				break;
			}

			delay = 0;

		}


	}
}
