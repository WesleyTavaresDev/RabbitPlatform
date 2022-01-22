using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public delegate void OnRestart(int sceneIndex);
    public static event OnRestart restart;

    public void Restart() => restart?.Invoke(SceneManager.GetActiveScene().buildIndex);

}
