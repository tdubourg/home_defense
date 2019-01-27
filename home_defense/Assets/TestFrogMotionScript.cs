using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFrogMotionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    protected Animator animator = null;

    Animator getAnimator()
    {
        if (this.animator == null)
        {
            this.animator = GetComponent<Animator>();

        }
        return this.animator;
    }

    public float TIME_BETWEEN_JUMPS_IN_SEC = 10.00f;
    protected float timeSinceLastJump = 10f;
    protected bool isJumping = false;
    public float JUMP_DISTANCE_FORWARD = 3f;
    protected Vector3 destination;
    protected float jumpStartTime = 0.0f;
    public float speed = 2f;
    protected Vector3 jumpStartPosition;
    public float initialMovementDelayForJumpPreparation = 0.15f;
	// Update is called once per frame
	void Update () {
        var animator = getAnimator();
        this.timeSinceLastJump += Time.deltaTime;
        if (timeSinceLastJump > TIME_BETWEEN_JUMPS_IN_SEC)
        {
            Debug.Log("Time to jump");
            timeSinceLastJump = 0f;
            performJump();
            jumpStartTime = Time.time;
            isJumping = true;
            destination = this.transform.position + (new Vector3(JUMP_DISTANCE_FORWARD, 0, 0));
            jumpStartPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
        if (isJumping && timeSinceLastJump >= initialMovementDelayForJumpPreparation)
        {
            float distCovered = (Time.time - jumpStartTime - initialMovementDelayForJumpPreparation) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / JUMP_DISTANCE_FORWARD;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(jumpStartPosition, destination, fracJourney);

            //Debug.Log(fracJourney);
            
            if (fracJourney >= 0.99f)
            {
                // Got to destination (kinda)
                isJumping = false;
                getAnimator().SetTrigger("Idle");

            }
        }
	}

    void performJump()
    {
        Debug.Log("Triggering jump");
        getAnimator().SetTrigger("Jump");
    }
}
