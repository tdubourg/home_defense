using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestDisableMeshNavForJump : MonoBehaviour {

    NavMeshAgent navAgent;

    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }
    // Use this for initialization
    void Start () {
		
	}

    private void performJump()
    {
        navAgent.isStopped = true;
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;
        rigidbody.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
//        yield return new WaitForSeconds(JUMP_DURATION * (1f - JUMP_HIT_TEST_PLAYER_FACTOR));

    }

    void endJump()
    {
        navAgent.isStopped = false;
    }

    private float jumpStartTime = 0f;
    public float timeToWaitToResumeNavMesh = 3f;

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown("s"))
        {
            performJump();
            jumpStartTime = Time.time;
        }
        if (Time.time - jumpStartTime > timeToWaitToResumeNavMesh)
        {
            endJump();
        }
	}
}
