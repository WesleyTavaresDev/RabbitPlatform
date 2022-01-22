using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public delegate void TransitionEffect(float fadeValue);
    public static event TransitionEffect transition;

    void LoadScene(int sceneIndex) => StartCoroutine(LoadScreenScene(sceneIndex));

    IEnumerator LoadScreenScene(int sceneIndex)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneIndex);
        transition?.Invoke(1);

        yield return null;
    }

    void OnEnable() 
    {
        RestartButton.restart += LoadScene;
        NextScenePoint.changeScene += LoadScene;
    } 
        
    void OnDisable()
    {
        RestartButton.restart -= LoadScene;
        NextScenePoint.changeScene -= LoadScene;
    }
}
