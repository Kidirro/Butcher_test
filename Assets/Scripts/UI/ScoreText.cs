using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    private void Start()
    {
        ScoreManager.OnScoreChanged -= OnScoreChanged; 
        ScoreManager.OnScoreChanged += OnScoreChanged; 
        
        text.text = ScoreManager.Instance.CurrentScore.ToString();
    }

    private void OnDestroy()
    {
        ScoreManager.OnScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(float score)
    {
        text.text = score.ToString();
    }
}
