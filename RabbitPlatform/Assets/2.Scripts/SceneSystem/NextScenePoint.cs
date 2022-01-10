﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScenePoint : MonoBehaviour
{
    public delegate void ChangeScene();
    public static event ChangeScene changeScene;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
            changeScene?.Invoke();
        
    }
}
