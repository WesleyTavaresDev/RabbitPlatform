using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CollectableItem : MonoBehaviour, ICollectable
{
    [SerializeField] private int itemPoints;

    public delegate void OnCollect(int point);
    public static event OnCollect onCollected;

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

    /**
    *! f/void OnEnable() => onCollected += Collected;
    *!void OnDisable() => onCollected -= Collected;
    */

}
    
