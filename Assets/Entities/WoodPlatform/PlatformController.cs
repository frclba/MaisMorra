using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {
	public GameObject platformPrefab;
	public float platformSpeed;

	GameObject CreatePlatform () {
		GameObject platform = Instantiate(platformPrefab, transform.position, Quaternion.identity) as GameObject;
		return platform;
	}

	void movePlatformUp(GameObject platform){
		platform.GetComponent<Rigidbody2D>().velocity = new Vector3(0, platformSpeed, 0);
	}

	//do the movimentation
	void Update () {
		if(Input.GetKeyDown(KeyCode.G)){
			print("instantiating platform 1");
			movePlatformUp(CreatePlatform());
		}
	}
}
