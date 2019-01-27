using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectVrClick : MonoBehaviour {

// For reference, here are some other collision-related functions:
// void OnCollisionEnter(Collision other)
// 	void OnCollisionStay(Collision other)
// 	void OnTriggerStart(Collider other)

	void OnTriggerStay(Collider other)
    {
		if (other.transform.name.StartsWith("Laser pointer")) {
			if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.Active)) {
				// user is pressing the trigger while pointing at us
				Clicked();
			}
		}
    }

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast (ray, out hit))
			{
				if (null != hit.transform) {
					Debug.Log("Click on " + hit.transform.name);
				}
				if (hit.transform == this.transform) {
					// user clicked us with an actual mouse
					Clicked();
				}
			}
       }
	}

	// We call this when we detect the user clicked on us.
	public virtual void Clicked() {}

	public void log(string msg) {
		LogSingleton.Instance.Log(msg);
	}

	
}

