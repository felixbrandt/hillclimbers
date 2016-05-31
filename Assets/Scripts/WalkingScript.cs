using UnityEngine;
using System.Collections;

public class WalkingScript : MonoBehaviour {

    public Animator animator;
    public float speed = 10f;

    public int jumpHeight = 300;

    Rigidbody2D rb2d;
    bool jumping = false;

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (!jumping)
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
        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            jumping = true;
            animator.SetBool("Jumping", true);
            //transform.Translate(Vector3.up * Time.deltaTime * jumpHeight);
            rb2d.AddForce(new Vector2(0, jumpHeight));
        }

        if (Input.GetMouseButton(0))
        {
            animator.SetTrigger("Attacking");
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        // TODO check if other object is a platform, only reset then.
        jumping = false;
        animator.SetBool("Jumping", false);
    }

}