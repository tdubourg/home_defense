using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinOnVrClick : DetectVrClick {

   public float speed = 33f;

   private bool spinning = false;

   private bool has_clicked = false;


	// We called when we detect the user clicked on us.
	override public void Clicked() {
		has_clicked = true;
		spinning = !spinning;
	}
	
	// Update is called once per frame
	void Update () {
		if (has_clicked) {
			log("Clicked the roof!");
		} else {
			log("Click the roof!");
		}
		if (spinning) {
			transform.Rotate(Vector3.up, speed * Time.deltaTime);
		}
	}
}

