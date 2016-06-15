﻿using UnityEngine;
using System.Collections;

public class WalkingScript : MonoBehaviour {

    public Animator animator;
    public float speed = 10f;
    public int jumpHeight = 300;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public Grapplinghook hook;


    Rigidbody2D rb2d;

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        animator.SetBool("Jumping", !grounded);

        if (!hook.IsEnabled)
        {

            if (Input.GetAxis("Horizontal") != 0)
            {
                if (grounded)
                {
                    animator.SetBool("Walking", true);
                }
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                if (Input.GetAxis("Horizontal") < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else if (Input.GetAxis("Horizontal") > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
            else
            {
                animator.SetBool("Walking", false);
            }


        // Jump
        // TODO? only let player jump when standin on the ground
        //       currently jumping after falling down is possible
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            //transform.Translate(Vector3.up * Time.deltaTime * jumpHeight);
            rb2d.AddForce(new Vector2(0, jumpHeight));
        }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // TODO check if other object is a platform, only reset then.
        //jumping = false;
        //animator.SetBool("Jumping", false);
    }

}