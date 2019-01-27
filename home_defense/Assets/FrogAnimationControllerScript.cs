using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAnimationControllerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Animator>().GetBehaviours<FrogIdleAnimationBehavior>()[0].frog = gameObject;
        GetComponent<Animator>().GetBehaviours<JumpAnimationBehavior>()[0].frog = gameObject;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
