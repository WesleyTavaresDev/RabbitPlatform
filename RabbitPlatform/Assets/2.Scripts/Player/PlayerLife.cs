using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerLife : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    Collider2D collider;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Spikes"))
        {
            anim.SetBool("Hit", true);
            DisableCollider();
        }
    }

    void DisableCollider() => collider.enabled = false;

}
