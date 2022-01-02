using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerJump : MonoBehaviour
{
    enum JUMP_STATES { Idle, Jumping};
    [SerializeField] JUMP_STATES jumpStates;

    [Header("Jump", order = 1)]
    [SerializeField] private float jumpForce;
    [Header("DoubleJump", order = 2)][SerializeField] private float doubleJumpForce;
    private bool doubleJumping;

    [Header("GroundCheck", order = 3)]
    [SerializeField] private float checkDistance;
    private const int GROUND_LAYER = 8;

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

        DoubleJump();
        DoubleJumpAnimation();

        StopJump();
        GroundCheck();
    }
    
    void Jump()
    {
        if(Input.GetButtonDown("Jump") &&  !IsJumping())
            Impulse(jumpForce); 
    }

    void JumpAnimation()
    {
        anim.SetBool("Jumping", IsJumping());
        anim.SetFloat("Jump", rb.velocity.y);
    }

    void DoubleJump()
    {
        if(Input.GetButtonDown("Jump") && IsJumping() && !doubleJumping)
        {
            Impulse(doubleJumpForce);
            doubleJumping = true;
        }
    }

    void DoubleJumpAnimation() => anim.SetBool("DoubleJumping", doubleJumping);

    void StopJump()
    {
        if( rb.velocity.y > 0 && Input.GetButtonUp("Jump"))
        {
            const float LIMITER = 0.25f;
            Impulse(rb.velocity.y * LIMITER * Time.deltaTime);
        }
    }
    
    void GroundCheck()
    {
        RaycastHit2D ray = Physics2D.Raycast(rb.worldCenterOfMass, Vector2.down, checkDistance, 1 << GROUND_LAYER);
        Debug.DrawRay(rb.worldCenterOfMass, Vector2.down * checkDistance, Color.blue);

        if(ray.collider != null)
        {
            jumpStates = JUMP_STATES.Idle;
            doubleJumping = false;
        }
        else
            jumpStates = JUMP_STATES.Jumping;
    }

    bool IsJumping() => jumpStates == JUMP_STATES.Jumping;
    void Impulse(float force) => rb.velocity = new Vector2(rb.velocity.x, Time.fixedDeltaTime * force);
}
