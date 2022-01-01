using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxHorizontalSpeed;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float timeMinimumToMaximumSpeed;
    private float refSpeed;

    private bool isFacingLeft;

    Rigidbody2D rb;
    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        horizontalSpeed = GetHorizontalInput() != 0 ? ChangeSpeed(maxHorizontalSpeed) : ChangeSpeed(0);
        rb.velocity = new Vector2(GetHorizontalInput() * Time.fixedDeltaTime * horizontalSpeed, rb.velocity.y);
        anim.SetInteger("Moving", (int)rb.velocity.x);
        
        HandleFlip();
    }

    float ChangeSpeed(float targetSpeed) => Mathf.SmoothDamp(horizontalSpeed, targetSpeed, ref refSpeed, timeMinimumToMaximumSpeed);

    void Flip()
    {     
        isFacingLeft = !isFacingLeft;

        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void HandleFlip()
    {
        if(GetHorizontalInput() == 0)
            return;
        
        else if(GetHorizontalInput() > 0)
        {
            if(isFacingLeft)
                Flip();
        }
        
        else
        {
            if(!isFacingLeft)
                Flip();
        }
    }
  
    float GetHorizontalInput() => Input.GetAxis("Horizontal");
}