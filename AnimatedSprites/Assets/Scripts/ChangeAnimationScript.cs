using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeAnimationScript : MonoBehaviour
{
    SpriteRenderer mySpriteRenderer;
    Animator myAnimator;
    RuntimeAnimatorController idleAnimation;
    RuntimeAnimatorController walkAnimation;
    RuntimeAnimatorController shootAnimation;
    RuntimeAnimatorController dieAnimation;
    System.Boolean flipped = false;
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        idleAnimation = Resources.Load("Animations/Bobby_Idle_Controller") as RuntimeAnimatorController;
        walkAnimation = Resources.Load("Animations/Bobby_Walk_Controller") as RuntimeAnimatorController;
        shootAnimation = Resources.Load("Animations/Bobby_Shoot_Controller") as RuntimeAnimatorController;
        dieAnimation = Resources.Load("Animations/Bobby_Die_Controller") as RuntimeAnimatorController;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float runspeed = 0.25f; ;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical"); // not using this
        if (!Input.anyKey)
        {
            // if no keys are pressed do the idle animation
            myAnimator.runtimeAnimatorController = idleAnimation;
        }
        if (moveHorizontal < 0)
        {
            // walk left
            myAnimator.runtimeAnimatorController = walkAnimation;
            flipped = false;
            Vector3 currentPos = transform.position;
            currentPos.x -= 0.1f * runspeed;
            transform.position = currentPos;
        }
        if (moveHorizontal > 0)
        {
            // walk right, and flip the sprite in X
            myAnimator.runtimeAnimatorController = walkAnimation;
            flipped = true;
            Vector3 currentPos = transform.position;
            currentPos.x += 0.1f * runspeed;
            transform.position = currentPos;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            // shoot in the current direction
            myAnimator.runtimeAnimatorController = shootAnimation;
        }
        if (Input.GetKey(KeyCode.X))
        {
            // die, but make sure the Animation loop setting has been turned off
            myAnimator.runtimeAnimatorController = dieAnimation;

        }
        // set the sprite facing the correct way
        mySpriteRenderer.flipX = flipped;
    }
}