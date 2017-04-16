using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour {

	public AudioClip Dash;
	public AudioClip LandingJump;
	public AudioClip PlayerDying;
	public AudioClip Push;
	public AudioClip ToTheGround;
	public AudioClip Jump1;
	public AudioClip Jump2;
	public AudioClip NaoPodePular;

	public void playJumpSound(){
		AudioSource.PlayClipAtPoint(Jump1, transform.position);
	}

}
