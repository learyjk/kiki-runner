using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    
    public float jumpForce;
    public bool is_grounded;
    public bool has_jumped;
    public Transform groundCheck;
    public float groundCheckRadius;

    public float jumpTime;
    public float jumpTimeCounter;

    private Rigidbody2D rb;
    public LayerMask whatIsGround;
    private Collider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        jumpTimeCounter = jumpTime;
        has_jumped = false;
    }

    // Update is called once per frame
    void Update()
    {
        is_grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            if (is_grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                has_jumped = true;
            }
        }

        if (Input.GetButton("Jump"))
        {
            if (jumpTimeCounter > 0 && has_jumped)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;
            has_jumped = false;
        }

        if (is_grounded)
        {
            jumpTimeCounter = jumpTime;
        }
    }
}
