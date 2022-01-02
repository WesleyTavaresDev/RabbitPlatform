using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerJump : MonoBehaviour
{
    enum JUMP_STATES { Idle, Jumping };
    [SerializeField] JUMP_STATES jumpStates;
    [SerializeField] private float jumpForce;

    [SerializeField] private float checkDistance;
    [SerializeField] private const int GROUND_LAYER = 8;

    Rigidbody2D rb;
    Animator anim;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Jump();
        JumpAnimation();

        GroundCheck();
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") &&  !IsJumping())
        {
            rb.velocity = new Vector2(rb.velocity.x, Time.fixedDeltaTime * jumpForce);
        }
    }

    void JumpAnimation()
    {
        anim.SetBool("Jumping", IsJumping());
        anim.SetFloat("Jump", rb.velocity.y);
    }

    void GroundCheck()
    {
        RaycastHit2D ray = Physics2D.Raycast(rb.worldCenterOfMass, Vector2.down, checkDistance, 1 << GROUND_LAYER);
        Debug.DrawRay(rb.worldCenterOfMass, Vector2.down * checkDistance, Color.blue);

        jumpStates = ray.collider != null ? JUMP_STATES.Idle : JUMP_STATES.Jumping;
    }

    bool IsJumping() => jumpStates == JUMP_STATES.Jumping;
}
