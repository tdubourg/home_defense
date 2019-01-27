using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.UI.HUD;
using TowerDefense.Towers;
using TowerDefense.Towers.Placement;
using Core.Utilities;

/*
 * Player can use the touchpad on the Go controller to move
 */
public class TouchpadMovement : DetectVrClick {

	private GameObject camera;
	// Use this for initialization
	void Start () {
		camera = GameObject.Find("OVRCameraRig");
	}


	override public void ExtraUpdate() {

		if (OVRInput.Get(OVRInput.Button.DpadUp, OVRInput.Controller.Active) || Input.GetKey("right")) {
			camera.transform.Translate(Vector3.forward);
		}

		if (OVRInput.Get(OVRInput.Button.DpadDown, OVRInput.Controller.Active) || Input.GetKey("left")) {
			camera.transform.Translate(Vector3.back);
		}

		/* we can't (easily) do left/right because it gets confused with swipes.
		if (OVRInput.Get(OVRInput.Button.TouchpadRight, OVRInput.Controller.Active) || Input.GetKey("left")) {
			camera.transform.Translate(Vector3.right);
		}

		if (OVRInput.Get(OVRInput.Button.TouchpadLeft, OVRInput.Controller.Active) || Input.GetKey("left")) {
			camera.transform.Translate(Vector3.left);
		}
		*/
	}


	override public void Clicked() {
		
	}

}
