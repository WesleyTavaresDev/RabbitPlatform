using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;

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
        float horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontalInput * Time.fixedDeltaTime * horizontalSpeed, rb.velocity.y);
        anim.SetInteger("Moving", (int)rb.velocity.x);
        
        HandleFlip();
    }

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