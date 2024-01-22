using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;
    
    
    public void SetScoreText(int Score)
    {
        scoreText.text = Score.ToString();
    }
}
