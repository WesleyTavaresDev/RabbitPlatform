using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;

    private bool isFacingLeft;

    Rigidbody2D rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontalInput * Time.fixedDeltaTime * horizontalSpeed, rb.velocity.y);
    
        Flip(horizontalInput);
    }

    void Flip(float horizontalInput)
    {
        if(horizontalInput == 0)
        {
            return;
        }
        
        isFacingLeft = !isFacingLeft;

        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        
    
        if(horizontalInput > 0)
        {
            if(isFacingLeft)
                Flip(horizontalInput);
        }

        else
        {
            if(!isFacingLeft)
                Flip(horizontalInput);
        }
    }
}