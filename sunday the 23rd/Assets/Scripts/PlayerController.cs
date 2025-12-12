using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script NEEDS a mover and a jumper to work. This will automatically add them if there isn't one of each
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]

public class PlayerController : MonoBehaviour
{
    [Tooltip("How well we can control ourselves in the air. 1 = same as on ground")]
    public float airControl = 0.5f;

    //these are all just references to the various components attached to this object to make
    //our lives easier
    private Mover mover;
    private Jumper jumper;
    public Animator animator;
    public ProjectileShooter projectileShooter1;
    public ProjectileShooter projectileShooter2;

    void Start()
    {
        //Find all the componenets attached to this object and save them to references
        mover = gameObject.GetComponent<Mover>();
        jumper = gameObject.GetComponent<Jumper>();
        //animator = gameObject.GetComponent<Animator>();

        //If we have a projectile shooter, we need to set it facing the right direction
        if (projectileShooter1 != null)
        {
            projectileShooter1.SetDirection(new Vector2(1, 0));
        }
        if (projectileShooter2 != null)
        {
            projectileShooter2.SetDirection(new Vector2(1, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If we have an animator...
        if (animator != null)
        {
            //Tell the animator that we are not currently walking
            animator.SetBool("Walking", false);
            //Tell the animator whether or not we're in the air
            animator.SetBool("IsOnGround", jumper.GetIsOnGround());
            //Tell the animator our current y velocity
            animator.SetFloat("YVelocity", gameObject.GetComponent<Rigidbody2D>().velocity.y);
            //It uses all these things to decide which animation to play
        }

        //Ask the jumper if we're in the air. If we are, apply the air control modifier
        float airControlModifier = jumper.GetIsOnGround() ? 1f : airControl;

        //Moving Right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //When right key is pressed, accelerate towards the right...
            mover.AccelerateInDirection(new Vector2(airControlModifier, 0f));

            if (animator != null)
            {
                //and tell the animator we are walking after all...
                animator.SetBool("Walking", true);
                Debug.Log("Walk animation");
            }

            //And flip our entire body to face the right
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.z);

            //If we have a projectile shooter, we also need it to face the right
            if (projectileShooter1 != null)
            {
                projectileShooter1.SetDirection(new Vector2(1f, 0.1f));
            }
            if (projectileShooter2 != null)
            {
                projectileShooter2.SetDirection(new Vector2(1f, 0.1f));
            }
        }

        //Moving Left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //When left key is pressed, accelerate towards the left...
            mover.AccelerateInDirection(new Vector2(-airControlModifier, 0f));

            if (animator != null)
            {
                //and tell the animator we are walking after all...
                animator.SetBool("Walking", true);
                Debug.Log("Walk animation");
            }

            //And flip our entire body to face the left
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180f, transform.rotation.z);

            //If we have a projectile shooter, we also need it to face the left
            if (projectileShooter1 != null)
            {
                projectileShooter1.SetDirection(new Vector2(-1f, 0.1f));
            }
            if (projectileShooter2 != null)
            {
                projectileShooter2.SetDirection(new Vector2(-1f, 0.1f));
            }
        }


        //When Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //If the jump key is pressed... jump!
            jumper.Jump();
        }

        //When shooting
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                // ?
                //If we have a projectile shooter...
                if (projectileShooter1 != null)
                {
                    //Shoot!
                    projectileShooter1.Fire();
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //If we have a projectile shooter...
                if (projectileShooter2 != null)
                {
                    //Shoot!
                    projectileShooter2.Fire();
                }
            }
        }
    }

    public void UnlockDoubleJump()
    {
        if (jumper != null)
        {
            jumper.doubleJumpAllowed = true;
        }
    }

    public void UnlockWeapon(GameObject projectilePrefab)
    {
        if (projectileShooter1 != null)
        {
            projectileShooter1.projectilePrefab = projectilePrefab;
        }
    }
}