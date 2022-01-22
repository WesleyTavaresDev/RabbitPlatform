using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup gameOverComponents;
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private GraphicRaycaster gameOverRaycaster;

    void OnEnable() => PlayerLife.playerDeath += ActiveGameOver;

    void ActiveGameOver()
    {
        gameOverCanvas.enabled = true;
        gameOverRaycaster.enabled = true;
        gameOverComponents.enabled = true;

        StartCoroutine(GameOverAnimation());
    }

    IEnumerator GameOverAnimation() 
    {
        yield return new WaitForSeconds(0.5f);
        DOTweenModuleUI.DOFade(this.gameOverComponents, 1f, 1f);
    }

    void OnDisable() => PlayerLife.playerDeath -= ActiveGameOver;
}
