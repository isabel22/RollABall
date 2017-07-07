using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		if (Input.mousePresent) {
			offset = transform.position - player.transform.position;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Input.mousePresent) {
			transform.position = player.transform.position + offset;
		}
	}
}
