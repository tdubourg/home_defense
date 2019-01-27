using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAnimationControllerScript : MonoBehaviour {


    FrogIdleAnimationBehavior idle;
    JumpAnimationBehavior jump;

    FrogIdleAnimationBehavior getIdle()
    {
        if (idle == null)
        {
            idle = GetComponent<Animator>().GetBehaviours<FrogIdleAnimationBehavior>()[0];
        }
        return idle;
    }

    JumpAnimationBehavior getJump()
    {
        if (jump == null)
        {
            jump = GetComponent<Animator>().GetBehaviours<JumpAnimationBehavior>()[0];
        }
        return jump;
    }

    // Use this for initialization
    void Awake () {
        getIdle().frog = gameObject;
        getJump().frog = gameObject;
    }

    // Update is called once per frame
    void Update () {
        getIdle().frog = gameObject;
        getJump().frog = gameObject;
    }
}
