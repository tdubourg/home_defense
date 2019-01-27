using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAnimationControllerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("a"))
        {
            GetComponent<Animator>().SetBool("IsAttacking", true);
            GetComponent<Animator>().SetBool("IsDead", false);
            GetComponent<Animator>().SetBool("IsMoving", false);
        } else if (Input.GetKeyDown("m")) {
            GetComponent<Animator>().SetBool("IsAttacking", false);
            GetComponent<Animator>().SetBool("IsDead", false);
            GetComponent<Animator>().SetBool("IsMoving", true);
        }
        else if (Input.GetKeyDown("d"))
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
            GetComponent<Animator>().SetBool("IsDead", true);
            GetComponent<Animator>().SetBool("IsMoving", false);
        }
    }
}
