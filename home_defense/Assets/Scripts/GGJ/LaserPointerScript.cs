using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//logButtonStatus();
	}

	/*
	 * Reads the status of the controller buttons, prints it out on the "debug_text" text canvas.
 	 * The text MUST be written using the "Text Mesh Pro" thingie for it to work,
	 * and you MUST have an OVRManager someplace else (typically in your OVRCameraRig).
	 */
	private void logButtonStatus() {
		// returns true if right-handed controller connected
		bool rt = OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote);
		
		bool lt = OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote);
		
		log("Active controller connected: " + OVRInput.IsControllerConnected(OVRInput.Controller.Active));
		if (rt) {
			log("Right remote connectd: " + rt);
		}
		if (lt) {
			log("Left remote connectd: " + lt);
		}

		// Shows up when the user presses down on the touchpad.
		if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.Active)) {
			log("button one is down");
		}
		if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.Active)) {
			log("PrimaryHandTrigger is down");
		}
		// Shows up when the user presses the trigger
		if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.Active)) {
			log("PrimaryIndexTrigger is down");
		}
	}

	private void log(string msg) {
		LogSingleton.Instance.Log(msg);
	}
	
}
