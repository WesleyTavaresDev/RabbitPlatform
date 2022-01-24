using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class PlayerLife : MonoBehaviour
{
    public delegate void OnPlayerDeath();
    public static event OnPlayerDeath playerDeath;

    public delegate void PlayerPointsOnDie(int points);
    public static event PlayerPointsOnDie playerPoints;

    Rigidbody2D rb;
    Animator anim;
    Collider2D collider;

    void OnEnable() => playerDeath += OnDie;
    
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
        playerPoints?.Invoke(-2);
    }

    void DisableCollider() => collider.enabled = false;

    void OnDisable() => playerDeath -= OnDie;
}
