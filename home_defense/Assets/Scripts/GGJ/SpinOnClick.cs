using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinOnClick : MonoBehaviour {

public float speed = -20;
private bool spinning = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
         RaycastHit hit;
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if (Physics.Raycast(ray, out hit))
         {
			 if (null != hit.transform) {
				 Debug.Log("Click on " + hit.transform.name);
			 }
			 if (hit.transform == this.transform) {
				 Debug.Log("You clicked on me, now I'm spinning!", this);
				 spinning = !spinning;
			 }
         }
     }
	 if (spinning) {
	 	transform.Rotate(Vector3.up, speed * Time.deltaTime);
	 }
	}
}
