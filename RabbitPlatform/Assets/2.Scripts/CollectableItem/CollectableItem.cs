using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour, ICollectable
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
            Collected();
    }

    public void Collected()
    {
        Destroy(this.gameObject, 0.5f);
    }
}
