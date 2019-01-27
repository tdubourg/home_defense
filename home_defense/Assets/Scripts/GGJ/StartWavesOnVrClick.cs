using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Level;
public class StartWavesOnVrClick : DetectVrClick {

	// Use this for initialization
	void Start () {
		
	}

	override public void Clicked() {
		if (TowerDefense.Level.LevelManager.instanceExists)
				{
					TowerDefense.Level.LevelManager.instance.BuildingCompleted();
				}
	}

}
