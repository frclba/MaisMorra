using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformController : MonoBehaviour {
	public GameObject platformPrefab;
	public float width = 10;
	public float height = 5;
	public float speed = 5.0f;
	public float padding = 0.1f;
	
	private int direction = 1;
	private float boundaryRightEdge, boundaryLeftEdge;
	
	void Start () {
		Camera camera = Camera.main;
		float distance = transform.position.z - camera.transform.position.z;
		
		boundaryLeftEdge = camera.ViewportToWorldPoint(new Vector3(0,0,distance)).x + padding;
		boundaryRightEdge = camera.ViewportToWorldPoint(new Vector3(1,1,distance)).x - padding;
		
		foreach( Transform child in transform){
			GameObject platform = Instantiate(platformPrefab, child.transform.position, Quaternion.identity) as GameObject;
			platform.transform.parent = child;
		}
	}
	
	void OnDrawGizmos(){
		float xmin,xmax,ymin,ymax;

		xmin = transform.position.x - 0.5f * width;
		xmax = transform.position.x + 0.5f * width;
		ymin = transform.position.y - 0.5f * height;
		ymax = transform.position.y + 0.5f * height;
		
		Gizmos.DrawLine(new Vector3(xmin,ymin,0), new Vector3(xmin,ymax));
		Gizmos.DrawLine(new Vector3(xmin,ymax,0), new Vector3(xmax,ymax));
		Gizmos.DrawLine(new Vector3(xmax,ymax,0), new Vector3(xmax,ymin));
		Gizmos.DrawLine(new Vector3(xmax,ymin,0), new Vector3(xmin,ymin));
	}
	
	//do the movimentation
	void Update () {
		float formationRightEdge = transform.position.x + 0.5f * width;
		float formationLeftEdge = transform.position.x - 0.5f * width;
		
		if (formationRightEdge > boundaryRightEdge){
			direction = -1;
		}
		if (formationLeftEdge < boundaryLeftEdge){
			direction = 1;
		}
		
		transform.position += new Vector3(direction * speed * Time.deltaTime,0,0);
	}
}
