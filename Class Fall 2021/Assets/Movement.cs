using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float speed = 10.0f;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] bool isGrounded = true;
    [SerializeField] Animator anim;

    const int IDLE = 0;
    const int RUN = 1;
    const int JUMP = 2;
 
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if (anim == null)
            anim = GetComponent<Animator>();
        anim.SetInteger("motion", IDLE);
   
    }

    // Update is called once per frame; best for user input
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;
    }

    //FixedUpdate is called potentially multiple times per frame; best for physics and movement
    private void FixedUpdate()
    {
        if (isGrounded)
        {
            rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
            if (movement > .01 || movement < -.01)
            {
                anim.SetInteger("motion", RUN);
            }
            else
            {
                anim.SetInteger("motion", IDLE);
            }
            if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
                Flip();

            if (jumpPressed && isGrounded) //only allow Mario to jump if he is on the ground -- no double jumps 
                Jump();
        }
    }

    private void Flip()
    {
        //Vector3 playerScale = transform.localScale;
        //playerScale.x = playerScale.x * -1;
        //transform.localScale = playerScale;

        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;

    }

    private void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        jumpPressed = false;
        isGrounded = false;
        anim.SetInteger("motion", JUMP);
    }

    //when we collide with the ground (here our ramp), we want to note that Mario is grounded
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }


}
