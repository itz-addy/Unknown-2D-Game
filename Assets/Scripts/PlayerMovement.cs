using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private BoxCollider2D coll;

    private float dirX = 0f;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float speed = 7f;
    [SerializeField] private AudioSource jumpSound;
    private enum MovementState
    {
        idle, running, jumping, falling
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSound.Play();
        }

        AnimationStates();
    }

    private void AnimationStates()
    {
        MovementState state;

        if (dirX > 0f)
        {   
            state = MovementState.running;
            sr.flipX = false;
        }
        
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sr.flipX = true;
        }

        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > .01f)
        {
            state = MovementState.jumping;
        }

        else if (rb.velocity.y < -.01f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
    
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}