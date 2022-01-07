using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StrawberryPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointText;
    int points;

    void UpdateScore(int point)
    {
        points += point;
        pointText.text = 'x' + points.ToString();
    }

    void OnEnable() => CollectableItem.onCollected += UpdateScore;

    void OnDisable() => CollectableItem.onCollected -= UpdateScore;
}

