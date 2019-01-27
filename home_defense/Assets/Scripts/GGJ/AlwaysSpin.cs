using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysSpin : MonoBehaviour {

public float speed = -20;
private bool spinning = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	 if (spinning) {
	 	transform.Rotate(Vector3.up, speed * Time.deltaTime);
	 }
	}
}
