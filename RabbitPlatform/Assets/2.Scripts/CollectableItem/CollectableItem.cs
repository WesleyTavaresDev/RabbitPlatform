using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CollectableItem : MonoBehaviour, ICollectable
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
            Collected();
    }

    public void Collected()
    {
        anim.SetTrigger("Collected");
    }

    void DestroyAfterCollected() => Destroy(this.gameObject);
}
