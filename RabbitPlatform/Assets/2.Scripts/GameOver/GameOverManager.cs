using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    } 

    void OnDisable() => PlayerLife.playerDeath -= ActiveGameOver;
}
