using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class StrawberryPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointText;

    int points;

    void OnEnable() => CollectableItem.onCollected += UpdateScore;

    void UpdateScore(int point) => points += point;
    
    void PointText() => pointText.text = 'x' + points.ToString();

    void OnDisable() => CollectableItem.onCollected -= UpdateScore;
}

