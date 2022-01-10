using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public delegate void TransitionEffect(float fadeValue);
    public static event TransitionEffect transition;

    void LoadScene() => StartCoroutine(LoadScreenScene());

    IEnumerator LoadScreenScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transition?.Invoke(1);

        yield return null;
    }

    void OnEnable() => NextScenePoint.changeScene += LoadScene;
    void OnDisable() => NextScenePoint.changeScene -= LoadScene;
}
