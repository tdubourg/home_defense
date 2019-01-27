using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JumpAnimationBehavior : StateMachineBehaviour {

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    float animationStartTime;
    public float initialWaitTimeBeforeMotion = 0.15f;
    public GameObject frog;
    float originalSpeed;
    NavMeshAgent navMeshAgent;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Entering jumping frog animation state");
        if (navMeshAgent == null)
        {
            navMeshAgent = frog.GetComponentInParent<NavMeshAgent>();
            originalSpeed = navMeshAgent.speed;
        }
        animationStartTime = Time.time;
        Debug.Log("Setting speed to zero at the beginning of the frog jump");
        //navMeshAgent.speed = 0;
        navMeshAgent.isStopped = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	    if (Time.time - animationStartTime > initialWaitTimeBeforeMotion)
        {
           // Debug.Log("Setting speed back to original speed after" + (Time.time - animationStartTime).ToString() + " sec");
            //navMeshAgent.speed = originalSpeed;
            
            if (stateInfo.normalizedTime >= 0.40)
            {
                navMeshAgent.isStopped = true;
            }
            else if (navMeshAgent != null) { navMeshAgent.isStopped = false; }
            // Debug.LogWarning("Normalized time jump" + stateInfo.normalizedTime);
        } else
        {
            navMeshAgent.isStopped = true;

        }
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Debug.Log("Exiting jump frog animation state");
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
