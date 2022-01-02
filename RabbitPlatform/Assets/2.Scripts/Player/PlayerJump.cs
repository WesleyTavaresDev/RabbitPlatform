using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    enum JUMP_STATES { Idle, Jumping };
    [SerializeField] JUMP_STATES jumpStates;
    [SerializeField] private float jumpForce;

    [SerializeField] private float checkDistance;
    [SerializeField] private const int GROUND_LAYER = 8;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Jump();
        GroundCheck();
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") &&  jumpStates == JUMP_STATES.Idle)
        {
            rb.velocity = new Vector2(rb.velocity.x, Time.fixedDeltaTime * jumpForce);
        }
    }

    void GroundCheck()
    {
        RaycastHit2D ray = Physics2D.Raycast(rb.worldCenterOfMass, Vector2.down, checkDistance, 1 << GROUND_LAYER);
        Debug.DrawRay(rb.worldCenterOfMass, Vector2.down * checkDistance, Color.blue);
        jumpStates = ray.collider != null ? JUMP_STATES.Idle : JUMP_STATES.Jumping;
    }
}
