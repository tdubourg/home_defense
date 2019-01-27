using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.UI.HUD;
using TowerDefense.Towers;
using TowerDefense.Towers.Placement;
using Core.Utilities;
public class TestTowerBuildOnVrClick : DetectVrClick {

private int count  = 0;

	// Use this for initialization
	void Start () {
		
	}


override public void ExtraUpdate() {
	Transform laserPointer = GameObject.Find("laser ray source").GetComponent<Transform>();
	if (null==laserPointer) {
		log("laser pointer not found.");
		return;
	}
	RaycastHit objectHit;
	// layer 8 is where the grid lives
	if (!Physics.Raycast(laserPointer.position, laserPointer.forward, out objectHit, 100, 1<<8)) {
		//log("we hit nothing");
		return;
	}
	log("Hit " + objectHit.collider.name + " at " + objectHit.point);
	IPlacementArea area = GameObject.Find("Grid").GetComponent<IPlacementArea>();
	IntVector2 pos = area.WorldToGrid(objectHit.point, new IntVector2(1,1));
	if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.Active)) {
		// let's go ahead and place it
		placeTower(area, pos);
	}
     //Debug.Log("Raycast hitted to: " + objectHit.collider);
    // targetEnemy = objectHit.collider.gameObject;
   
}

private void placeTower(IPlacementArea area, IntVector2 pos) {
	Debug.Log("Creating a tower now");
	
	TowerDefense.Towers.Tower controller = TowerDefense.Level.LevelManager.instance.towerLibrary[0];
	
	TowerFitStatus fits = area.Fits(pos, controller.dimensions);
	if (fits != TowerFitStatus.Fits) {
		log("Doesn't fit");
		return;
	}

	Debug.Log("Tower data: " + controller + " dimensions: " + controller.dimensions + " configuration:" + controller.configuration + " levels:" + controller.levels);
	Debug.Log("Level[0]: " + controller.levels[0]);
	TowerDefense.Towers.Tower createdTower = Instantiate(controller);
	createdTower.Initialize(area, pos);
}

	override public void Clicked() {
		IPlacementArea area = GameObject.Find("Grid").GetComponent<IPlacementArea>();
		IntVector2 pos = new IntVector2(3, 10 + 2*count++);
		placeTower(area, pos);
	}

}
