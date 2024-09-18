using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameProgressBarUI : MonoBehaviour
{
    [SerializeField]
    private Gradient _gradient;
    
    [SerializeField]
    private Image progressBarImage;
    
    [Space, Min(0), SerializeField]
    private float minValue;

    [Min(0), SerializeField]
    private float maxValue;
    
    [Space, Min(0), SerializeField]
    private float poorValue;

    [SerializeField]
    private TMP_Text textValue;

    [SerializeField]
    private string poorString;

    [SerializeField]
    private string richString;


    private void Start()
    {
        ScoreManager.OnScoreChangedNewValue -= OnScoreChangedNewValue;
        ScoreManager.OnScoreChangedNewValue += OnScoreChangedNewValue;
        OnScoreChangedNewValue(ScoreManager.Instance.CurrentScore);
    }

    private void OnDestroy()
    {
        ScoreManager.OnScoreChangedNewValue -= OnScoreChangedNewValue;
    }

    private void OnScoreChangedNewValue(float score)
    {
        textValue.text = score > poorValue ? richString : poorString;

        float progressValue = Mathf.Clamp(score, minValue, maxValue)/maxValue;
        Color currentColor = _gradient.Evaluate(progressValue);

        progressBarImage.color = currentColor;
        textValue.color = currentColor;

        progressBarImage.fillAmount = progressValue;
    }
}
