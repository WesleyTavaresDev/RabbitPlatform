using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerLife : MonoBehaviour
{
    public delegate void OnPlayerDeath();
    public static event OnPlayerDeath playerDeath;

    Rigidbody2D rb;
    Animator anim;
    Collider2D collider;

    void OnEnable()
    {
        playerDeath += OnDie;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Spikes"))
            playerDeath?.Invoke();
    }

    void OnDie()
    {
        anim.SetBool("Hit", true);
        DisableCollider();
    }

    void DisableCollider() => collider.enabled = false;
}
