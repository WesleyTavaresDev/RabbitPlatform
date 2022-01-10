using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class TransitionFX : MonoBehaviour
{
    [SerializeField] private CanvasGroup transition;
    [SerializeField] [Range(0, 10)] private float transitionDuration;

    void Awake() => Transition(0);  

    void Transition(float endFadeValue) => DOTweenModuleUI.DOFade(transition, endFadeValue, transitionDuration);

    void OnEnable() => SceneLoader.transition += Transition;

    void OnDisable() => SceneLoader.transition -= Transition;
}
