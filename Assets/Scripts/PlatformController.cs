using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

	public GameObject platformPrefab_2;
	public GameObject platformPrefab_6;
	public GameObject platformPrefab_8;
	public GameObject platformPrefab_10;

	public float platformSpeed;
	public float delay = 0f;
	public float delay_Instant = 2f;

	void movePlatformUp(GameObject platform){
		platform.GetComponent<Rigidbody2D>().velocity = new Vector3(0, platformSpeed, 0);
	}

	//do the movimentation
	void Update () {

		if (delay > delay_Instant) {
			int value = Random.Range (1, 4);

			switch (value) {
			case 1:
				Instantiate (platformPrefab_2, transform.position, Quaternion.identity);
				break;
			case 2:
				Instantiate (platformPrefab_6, transform.position, Quaternion.identity);
				break;
			case 3:
				Instantiate (platformPrefab_8, transform.position, Quaternion.identity);
				break;
			case 4:
				Instantiate (platformPrefab_10, transform.position, Quaternion.identity);
				break;
			}

		}


	}
}
