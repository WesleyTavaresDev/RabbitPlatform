using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    enum JUMP_STATES { Idle, Jumping };
    [SerializeField] JUMP_STATES jumpStates;
    [SerializeField] private float jumpForce;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Jump();
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") &&  jumpStates == JUMP_STATES.Idle)
        {
            rb.velocity = new Vector2(rb.velocity.x, Time.fixedDeltaTime * jumpForce);
            jumpStates = JUMP_STATES.Jumping;
        }
    }
}
