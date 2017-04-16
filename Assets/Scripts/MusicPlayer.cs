using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	// Use this for initialization
	void Start () {
		if(instance != null){
			Destroy(gameObject);
			Debug.Log("Self Destructing music object");
		}
		else{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}
