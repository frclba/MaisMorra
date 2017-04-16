using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

	public GameObject pp1;
	public GameObject pp2;
	public GameObject pp3;
	public GameObject pp4;

	public float delay = 0f;
	public float delay_Instant = 2f;

	public float minimium_posX = -9.5f;
	public float maximum_posX = 9.5f;
	private float y = -8f;

	public float plataformSpeed = 5f;
	public float contador =0;

	void Start(){
	}

	//do the movimentation
	void Update () {

		contador += Time.deltaTime;

		if (contador > 10) {
			plataformSpeed = plataformSpeed * 2;
			delay_Instant = delay_Instant / 2;
			Debug.Log (plataformSpeed);
			contador = 0;
		}
			
		float x = Random.Range (-9f, 9f);
		delay += Time.deltaTime;

		if (delay > delay_Instant) {
			int value = Random.Range (1, 4);

			switch (value) {
			case 1:
				Instantiate (pp1, new Vector2(x,y), Quaternion.identity);
				break;
			case 2:
				Instantiate (pp2, new Vector2(x,y), Quaternion.identity);
				break;
			case 3:
				Instantiate (pp3, new Vector2(x,y), Quaternion.identity);
				break;
			case 4:
				Instantiate (pp4, new Vector2(x,y), Quaternion.identity);
				break;
			
			}

			delay = 0;

		}


	}
}
	