﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.UI.HUD;
using TowerDefense.Towers;
using TowerDefense.Towers.Placement;
using Core.Utilities;
using TowerDefense.Level;

public class TowerBuildOnVrClick : DetectVrClick {

	private int towerIdx = 0;

	// the "TowerList" thing doesn't have a length property... so we hardcode.
	private int towerLen = 4; // TowerDefense.Level.LevelManager.instance.towerLibrary.Length;

private int count = 0;

	private GameObject[] towerModels = new GameObject[4];

	// Use this for initialization
	void Start () {
		UpdateTowerModels();
	}

	private void UpdateTowerModels() {
		towerModels[0] = GameObject.Find("MachineGunTower_model");
		towerModels[1] = GameObject.Find("RocketTower_model");
		towerModels[2] = GameObject.Find("LaserTower_model");
		towerModels[3] = GameObject.Find("WallTower_model");
	}

	override public void ExtraUpdate() {

		if (OVRInput.Get(OVRInput.Button.Right, OVRInput.Controller.Active) || Input.GetKey("right")) {
			towerIdx++;
			//log("Next tower type");
		}

		if (OVRInput.Get(OVRInput.Button.Left, OVRInput.Controller.Active) || Input.GetKey("left")) {
			towerIdx--;
			//log("Previous tower type");
		}

		for (int i=0; i<towerModels.Length; i++) {
			if (null==towerModels[i]) {
				log("Missing: tower model " + i);
				continue;
			}
			towerModels[i].SetActive(i==(towerIdx % towerLen));
		}

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
	
	TowerDefense.Towers.Tower controller = TowerDefense.Level.LevelManager.instance.towerLibrary[towerIdx % towerLen];
	
	TowerFitStatus fits = area.Fits(pos, controller.dimensions);
	if (fits != TowerFitStatus.Fits) {
		//log("Doesn't fit");
		return;
	}

	if (!LevelManager.instance.currency.TryPurchase(controller.purchaseCost)) {
		log("Not enough money");
		return;
	} else {
		//log("buying. " + (LevelManager.instance.currency.currentCurrency) + " left");
	}

	TowerDefense.Towers.Tower createdTower = Instantiate(controller);
	createdTower.Initialize(area, pos);
}

	override public void Clicked() {
		Debug.Log("clicked, spawning tower.");
		IPlacementArea area = GameObject.Find("Grid").GetComponent<IPlacementArea>();
		IntVector2 pos = new IntVector2(3, 10 + 2*count++);
		placeTower(area, pos);
	}

}
