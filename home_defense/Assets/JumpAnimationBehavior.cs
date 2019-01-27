using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JumpAnimationBehavior : StateMachineBehaviour {


    public static void DontMove(NavMeshAgent navMeshAgent, Rigidbody rigidbody, GameObject frog)
    {
        if (!navMeshAgent.enabled || !navMeshAgent.isActiveAndEnabled)
        {
            // Nothing to do
            return;
        }
        navMeshAgent.isStopped = true;
        //rigidbody.isKinematic = false;
        //navMeshAgent.nextPosition = frog.transform.position;
        navMeshAgent.enabled = false;
       // rigidbody.AddForce(Vector3.zero);
       // rigidbody.velocity = Vector3.zero;
    }

    public static void MoveAgain(NavMeshAgent navMeshAgent, Rigidbody rigidbody, GameObject frog)
    {
        if (navMeshAgent.enabled && navMeshAgent.isActiveAndEnabled)
        {
            return;
        }
        navMeshAgent.enabled = true;
        navMeshAgent.isStopped = false;
        //rigidbody.isKinematic = true;

    }

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

        DontMove(getNavMeshAgent(), rigidbody, frog);

    }

    void moveAgain()
    {
        MoveAgain(getNavMeshAgent(), rigidbody, frog);
    }
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
           // rigidbody = frog.GetComponentInParent<Rigidbody>();
         //   originalSpeed = getNavMeshAgent().speed;

        animationStartTime = Time.time;
        Debug.Log("Setting speed to zero at the beginning of the frog jump");
        //navMeshAgent.speed = 0;
        dontMove();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	    if (Time.time - animationStartTime > initialWaitTimeBeforeMotion)
        {
           // Debug.Log("Setting speed back to original speed after" + (Time.time - animationStartTime).ToString() + " sec");
            //navMeshAgent.speed = originalSpeed;
            
            if (stateInfo.normalizedTime >= 0.65)
            {
                dontMove();
            }
            else if (navMeshAgent != null) { moveAgain(); }
            // Debug.LogWarning("Normalized time jump" + stateInfo.normalizedTime);
        } else
        {
            dontMove();

        }
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Debug.Log("Exiting jump frog animation state");
        dontMove();
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
