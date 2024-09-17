using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : BaseSingleton<ScoreManager>
{
    public static event Action<float> OnScoreChanged = delegate(float f) {  }; 

    public float CurrentScore { private set; get; }

    private void Start()
    {
        CurrentScore = 0;
    }

    public void AddScore(float score)
    {
        CurrentScore += score;
        OnScoreChanged.Invoke(CurrentScore);
    }
}
