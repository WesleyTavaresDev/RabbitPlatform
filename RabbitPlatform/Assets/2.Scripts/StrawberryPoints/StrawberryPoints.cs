using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StrawberryPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointText;
    int points;

    void OnEnable() 
    {
        PlayerLife.playerPoints += UpdateScore;
        CollectableItem.onCollected += UpdateScore;
    } 
        

    public void UpdateScore(int point)
    {
        points += point;
        PointText();
    }
    
    void PointText() => pointText.text = 'x' + points.ToString();

    void OnDisable()
    {
        PlayerLife.playerPoints -= UpdateScore;
        CollectableItem.onCollected -= UpdateScore;
    } 
}

