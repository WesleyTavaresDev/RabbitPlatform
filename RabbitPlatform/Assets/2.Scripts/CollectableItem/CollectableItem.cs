using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CollectableItem : MonoBehaviour, ICollectable
{
    public delegate void OnCollect(int point);
    public static event OnCollect onCollected;
    
    [SerializeField] private int itemPoints;

    Animator anim;

    void Start() => anim = GetComponent<Animator>();
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            onCollected?.Invoke(itemPoints);
            Collected();
        }
    }
    public void Collected() => anim.SetTrigger("Collected");
    
    void DestroyAfterCollected() => Destroy(this.gameObject); 
}
    
