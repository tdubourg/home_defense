using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnVrClick : DetectVrClick {

   public float speed = 33f;

   private bool spinning = false;

   private bool has_clicked = false;


	// We called when we detect the user clicked on us.
	override public void Clicked() {
		log("teleport");
		GameObject camera = GameObject.Find("OVRCameraRig");
		camera.transform.SetPositionAndRotation(this.gameObject.transform.position, this.gameObject.transform.rotation);
		camera.transform.Translate(new Vector3(0.0F,0.0F,2.0F));
	}
	
}

