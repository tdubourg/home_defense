using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FrogIdleAnimationBehavior : StateMachineBehaviour {
    public GameObject frog;
    float originalSpeed;
    NavMeshAgent navMeshAgent;
    NavMeshAgent getNavMeshAgent()
    {
        if (navMeshAgent == null)
        {
            navMeshAgent = frog.GetComponentInParent<NavMeshAgent>();

        }
        return navMeshAgent;
    }

    Rigidbody rigidbody;
    void dontMove()
    {
        JumpAnimationBehavior.DontMove(getNavMeshAgent(), rigidbody, frog);

    }

    void moveAgain()
    {
        JumpAnimationBehavior.MoveAgain(getNavMeshAgent(), rigidbody, frog);
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        navMeshAgent = frog.GetComponentInParent<NavMeshAgent>();
        rigidbody = frog.GetComponentInParent<Rigidbody>();
        originalSpeed = navMeshAgent.speed;

        //Debug.Log("Entering Idle frog animation state, setting speed to 0");
        //navMeshAgent.speed = 0;
        dontMove();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        // Debug.Log("Speed of meshAgent on idle animation update:" + navMeshAgent.speed.ToString());
        // navMeshAgent.speed = 0;
        //Debug.Log("idle frog animation update");
        dontMove();

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //Debug.Log("Exiting idle frog animation state");
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
